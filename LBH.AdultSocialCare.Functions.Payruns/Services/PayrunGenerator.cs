using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
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
        private readonly IPayrunGateway _payrunGateway;
        private readonly ILogger<PayrunGenerator> _logger;
        private readonly InvoiceGenerator _invoiceGenerator;

        public PayrunGenerator(
            InvoiceGenerator invoiceGenerator, IHttpContextAccessor httpContextAccessor, IInvoiceGateway invoiceGateway,
            ICarePackageGateway carePackageGateway, IPayrunGateway payrunGateway, ILogger<PayrunGenerator> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _invoiceGateway = invoiceGateway;
            _carePackageGateway = carePackageGateway;
            _payrunGateway = payrunGateway;
            _logger = logger;

            _invoiceGenerator = invoiceGenerator;
        }

        public async Task GenerateAsync()
        {
            // TODO: VK: Handle payrun ID from SQS, add reprocessing for hang-up draft / in-progress payruns
            var draftPayruns = await _payrunGateway.GetDraftPayrunsAsync();

            foreach (var payrun in draftPayruns)
            {
                ImpersonateCurrentUser(payrun);

                var packageIds = await _carePackageGateway.GetUnpaidPackageIdsAsync(payrun.StartDate, payrun.EndDate);

                await GenerateInvoices(
                    packageIds, payrun,
                    packages => _invoiceGenerator.GenerateAsync(packages, payrun.EndDate, InvoiceTypes.All));

                // save interim result to prevent any reprocessing of refunded items
                await _payrunGateway.SaveAsync();

                packageIds = await _carePackageGateway.GetModifiedPackageIdsAsync();

                await GenerateInvoices(
                    packageIds, payrun,
                    packages => _invoiceGenerator.GenerateAsync(packages, payrun.EndDate, InvoiceTypes.Refund));

                payrun.Status = PayrunStatus.WaitingForReview;
                await _payrunGateway.SaveAsync();
            }
        }

        private async Task<int> GenerateInvoices(IList<Guid> packageIds, Payrun payrun, Func<IList<CarePackage>, Task<IList<Invoice>>> generationFunc)
        {
            var iterations = Math.Ceiling((double) packageIds.Count / PackageBatchSize);

            for (var i = 0; i < iterations; i++)
            {
                var batchIds = packageIds.Skip(i * PackageBatchSize).Take(PackageBatchSize).ToList();
                var packages = await _carePackageGateway.GetListAsync(batchIds);

                var invoices = await generationFunc(packages);

                _logger.LogDebug("Generated invoices: {Invoices}", JsonConvert.SerializeObject(invoices, Formatting.Indented));

                foreach (var invoice in invoices)
                {
                    var payrunInvoice = new PayrunInvoice
                    {
                        Payrun = payrun,
                        Invoice = invoice,
                        InvoiceStatus = InvoiceStatus.Draft
                    };

                    payrun.PayrunInvoices.Add(payrunInvoice);
                }
            }

            return payrun.PayrunInvoices.Count;
        }

        private void ImpersonateCurrentUser(Payrun payrun)
        {
            // Don't have a logged-in user in lambda, so impersonate it as a payrun creator
            // Database context will then use it as Creator / Updater
            // TODO: VK: Consider having a dedicated user to run lambda functions
            var userIdClaim = new Claim(ClaimTypes.NameIdentifier, payrun.CreatorId.ToString());
            ((ClaimsIdentity) _httpContextAccessor.HttpContext.User.Identity).AddClaim(userIdClaim);
        }
    }
}
