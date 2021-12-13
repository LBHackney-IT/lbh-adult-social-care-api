using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LBH.AdultSocialCare.Functions.Payruns.Services
{
    public class PayrunGenerator
    {
        private const int PackageBatchSize = 500;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInvoiceGateway _invoiceGateway;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IFundedNursingCareGateway _fundedNursingCareGateway;
        private readonly IPayrunGateway _payrunGateway;
        private readonly ILogger<PayrunGenerator> _logger;
        private InvoiceGenerator _invoiceGenerator;

        public PayrunGenerator(
            IHttpContextAccessor httpContextAccessor, IInvoiceGateway invoiceGateway,
            ICarePackageGateway carePackageGateway, IFundedNursingCareGateway fundedNursingCareGateway,
            IPayrunGateway payrunGateway, ILogger<PayrunGenerator> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _invoiceGateway = invoiceGateway;
            _carePackageGateway = carePackageGateway;
            _fundedNursingCareGateway = fundedNursingCareGateway;
            _payrunGateway = payrunGateway;
            _logger = logger;
        }

        public async Task GenerateAsync()
        {
            await Task.Delay(45000);

            // TODO: VK: Handle payrun ID from SQS, add reprocessing for hang-up draft / in-progress payruns
            var draftPayruns = await _payrunGateway.GetDraftPayrunsAsync();
            if (draftPayruns.Count == 0) return;

            var fncPrices = await _fundedNursingCareGateway.GetFundedNursingCarePricesAsync();
            _invoiceGenerator = new InvoiceGenerator(_invoiceGateway, fncPrices);

            foreach (var payrun in draftPayruns)
            {
                try
                {
                    ImpersonateCurrentUser(payrun);

                    payrun.Status = PayrunStatus.InProgress;
                    await _payrunGateway.SaveAsync();

                    // 1. generate refund invoices
                    var packageIds = await _carePackageGateway.GetModifiedPackageIdsAsync();
                    await GenerateInvoices(packageIds, payrun, InvoiceTypes.Refund);

                    // save interim result to prevent any reprocessing of refunded items
                    await _payrunGateway.SaveAsync();

                    // 2. generate normal invoices
                    packageIds = await _carePackageGateway.GetUnpaidPackageIdsAsync(payrun.StartDate, payrun.EndDate);
                    await GenerateInvoices(packageIds, payrun, InvoiceTypes.Normal);

                    payrun.Status = PayrunStatus.WaitingForReview;
                    await _payrunGateway.SaveAsync();
                }
                catch (Exception ex)
                {
                    await ArchivePayrun(payrun, ex);
                    throw;
                }
            }
        }

        private async Task GenerateInvoices(IList<Guid> packageIds, Payrun payrun, InvoiceTypes invoiceType)
        {
            var lastInvoiceNumber = await _invoiceGateway.GetInvoicesCountAsync();
            var iterations = Math.Ceiling((double) packageIds.Count / PackageBatchSize);

            for (var i = 0; i < iterations; i++)
            {
                var batchIds = packageIds.Skip(i * PackageBatchSize).Take(PackageBatchSize).ToList();
                var packages = await _carePackageGateway.GetListAsync(batchIds);

                var invoices = await _invoiceGenerator.GenerateAsync(packages, payrun.EndDate, invoiceType, lastInvoiceNumber);

                _logger.LogDebug("Generated invoices: {Invoices}", JsonConvert.SerializeObject(invoices, Formatting.Indented));

                foreach (var invoice in invoices)
                {
                    if (!invoice.Items.Any()) continue;

                    var payrunInvoice = new PayrunInvoice
                    {
                        Payrun = payrun,
                        Invoice = invoice,
                        InvoiceStatus = InvoiceStatus.Accepted
                    };

                    payrun.PayrunInvoices.Add(payrunInvoice);
                }

                lastInvoiceNumber += invoices.Count;
            }
        }

        private async Task ArchivePayrun(Payrun payrun, Exception ex)
        {
            payrun.Status = PayrunStatus.Archived;
            payrun.Histories.Add(new PayrunHistory
            {
                PayRunId = payrun.Id,
                Status = PayrunStatus.Archived,
                Notes = ex.Message
            });

            await _payrunGateway.SaveAsync();
        }

        private void ImpersonateCurrentUser(Payrun payrun)
        {
            // Don't have a logged-in user in lambda, so impersonate it as a payrun creator
            // Database context will then use it as Creator / Updater
            var userIdClaim = new Claim(ClaimTypes.NameIdentifier, payrun.CreatorId.ToString());
            ((ClaimsIdentity) _httpContextAccessor.HttpContext.User.Identity).AddClaim(userIdClaim);
        }
    }
}
