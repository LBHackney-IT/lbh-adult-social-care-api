using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            var (grossTotal, netTotal, supplierReclaimsTotal, hackneyReclaimsTotal) = CalculateTotals(payRunInvoice.InvoiceItems);
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
                GrossTotal = decimal.Round(grossTotal, 2),
                NetTotal = decimal.Round(netTotal, 2),
                SupplierReclaimsTotal = decimal.Round(supplierReclaimsTotal, 2),
                HackneyReclaimsTotal = decimal.Round(hackneyReclaimsTotal, 2),
                InvoiceStatus = payRunInvoice.InvoiceStatus,
                AssignedBrokerName = payRunInvoice.AssignedBrokerName,
                InvoiceItems = payRunInvoice.InvoiceItems.ToResponse()
            };

            result.Invoice = invoiceRes;

            return result;
        }

        private static (decimal, decimal, decimal, decimal) CalculateTotals(IEnumerable<PayRunInvoiceItemDomain> invoiceItems)
        {
            var grossTotal = 0M;
            var netTotal = 0M;
            var supplierReclaimsTotal = 0M;
            var hackneyReclaimsTotal = 0M;

            foreach (var invoiceItem in invoiceItems)
            {
                switch (invoiceItem.IsReclaim)
                {
                    case false when invoiceItem.PriceEffect == PriceEffect.Add:
                        grossTotal += invoiceItem.TotalCost;
                        netTotal += invoiceItem.TotalCost;
                        break;

                    case true when invoiceItem.ClaimCollector == ClaimCollector.Supplier && invoiceItem.PriceEffect == PriceEffect.Subtract:
                        netTotal -= invoiceItem.TotalCost;
                        supplierReclaimsTotal += invoiceItem.TotalCost;
                        break;

                    case true when invoiceItem.ClaimCollector == ClaimCollector.Hackney:
                        hackneyReclaimsTotal += invoiceItem.TotalCost;
                        break;
                }
            }

            return (grossTotal, netTotal, supplierReclaimsTotal, hackneyReclaimsTotal);
        }
    }
}
