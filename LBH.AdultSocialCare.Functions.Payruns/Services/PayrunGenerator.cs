using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Functions.Payruns.Services
{
    public class PayrunGenerator
    {
        private const int PackageBatchSize = 500;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IPayrunGateway _payrunGateway;
        private readonly InvoiceGenerator _invoiceGenerator;

        public PayrunGenerator(
            IHttpContextAccessor httpContextAccessor, ICarePackageGateway carePackageGateway,
            IFundedNursingCareGateway fncGateway, IPayrunGateway payrunGateway)
        {
            _httpContextAccessor = httpContextAccessor;
            _carePackageGateway = carePackageGateway;
            _payrunGateway = payrunGateway;

            _invoiceGenerator = new InvoiceGenerator(_carePackageGateway, fncGateway);
        }

        public async Task GenerateAsync()
        {
            // TODO: VK: Handle payrun types
            var draftPayruns = await _payrunGateway.GetDraftPayrunsAsync();

            foreach (var payrun in draftPayruns)
            {
                ImpersonateCurrentUser(payrun);

                // Generate invoices in batches, for up to 500 packages per batch
                var packageIds = await _carePackageGateway.GetUnpaidPackageIdsAsync(payrun.StartDate, payrun.EndDate);
                var iterations = Math.Ceiling((double) packageIds.Count / PackageBatchSize);

                for (var i = 0; i < iterations; i++)
                {
                    var batchIds = packageIds.Skip(i * PackageBatchSize).Take(PackageBatchSize).ToList();
                    var packages = await _carePackageGateway.GetListAsync(batchIds);

                    var invoices = await _invoiceGenerator.GenerateAsync(packages, payrun.EndDate);

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

                    payrun.Status = PayrunStatus.WaitingForReview;
                    await _payrunGateway.SaveAsync();
                }
            }
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