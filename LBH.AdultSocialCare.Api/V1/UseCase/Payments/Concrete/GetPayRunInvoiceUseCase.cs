using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunInvoiceUseCase : IGetPayRunInvoiceUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public GetPayRunInvoiceUseCase(IPayRunGateway payRunGateway, IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _payRunGateway = payRunGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task<PayRunInvoiceDetailViewResponse> GetDetailsAsync(Guid payRunId, Guid invoiceId)
        {
            // Get pay run
            var payRun = await _payRunGateway
                .GetPayRunAsync(payRunId)
                .EnsureExistsAsync($"Pay Run with id {payRunId} not found");

            // Get pay run invoice
            var invoice = await _payRunInvoiceGateway.GetPayRunInvoiceDetailAsync(payRunId, invoiceId, false);

            return CreateResponse(payRun, invoice);
        }

        private static PayRunInvoiceDetailViewResponse CreateResponse(Payrun payrun, PayRunInvoiceDomain payRunInvoice)
        {
            var result = new PayRunInvoiceDetailViewResponse
            {
                PayRunId = payrun.Id,
                PayRunNumber = payrun.Id.ToString()[..6],
                DateCreated = payrun.DateCreated,
                StartDate = payrun.StartDate,
                EndDate = payrun.EndDate,
            };

            var (supplierReclaimsTotal, hackneyReclaimsTotal) = CalculateTotals(payRunInvoice.InvoiceItems);
            var invoiceRes = new PayRunInvoiceResponse
            {
                Id = payRunInvoice.Id,
                InvoiceId = payRunInvoice.InvoiceId,
                CarePackageId = payRunInvoice.CarePackageId,
                ServiceUserId = payRunInvoice.ServiceUserId,
                ServiceUserName = payRunInvoice.ServiceUserName,
                SupplierId = payRunInvoice.SupplierId,
                SupplierName = payRunInvoice.SupplierName,
                InvoiceNumber = payRunInvoice.InvoiceNumber,
                PackageTypeId = (int) payRunInvoice.PackageType,
                PackageType = payRunInvoice.PackageType.GetDisplayName(),
                GrossTotal = decimal.Round(payRunInvoice.GrossTotal, 2),
                NetTotal = decimal.Round(payRunInvoice.NetTotal, 2),
                SupplierReclaimsTotal = decimal.Round(supplierReclaimsTotal, 2),
                HackneyReclaimsTotal = decimal.Round(hackneyReclaimsTotal, 2),
                InvoiceStatus = payRunInvoice.InvoiceStatus,
                AssignedBrokerName = payRunInvoice.AssignedBrokerName,
                InvoiceItems = payRunInvoice.InvoiceItems.ToResponse()
            };

            result.Invoice = invoiceRes;

            return result;
        }

        private static (decimal, decimal) CalculateTotals(IEnumerable<PayRunInvoiceItemDomain> invoiceItems)
        {
            var supplierReclaimsTotal = 0.0m;
            var hackneyReclaimsTotal = 0.0m;

            foreach (var item in invoiceItems)
            {
                switch (item.ClaimCollector)
                {
                    case ClaimCollector.Supplier:
                        supplierReclaimsTotal += item.TotalCost;
                        break;

                    case ClaimCollector.Hackney:
                        hackneyReclaimsTotal += item.TotalCost;
                        break;
                }
            }

            return (supplierReclaimsTotal, hackneyReclaimsTotal);
        }
    }
}
