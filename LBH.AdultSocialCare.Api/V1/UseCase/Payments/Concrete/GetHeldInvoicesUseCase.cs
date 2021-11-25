using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetHeldInvoicesUseCase : IGetHeldInvoicesUseCase
    {
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public GetHeldInvoicesUseCase(IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task<PagedResponse<HeldInvoiceDetailsResponse>> ExecuteAsync(PayRunDetailsQueryParameters parameters)
        {
            // Get held invoices
            var payRunInvoices = await _payRunInvoiceGateway.GetHeldInvoicesAsync(parameters);
            var result = CreateResponse(payRunInvoices, payRunInvoices.PagingMetaData);
            return result;
        }

        private static PagedResponse<HeldInvoiceDetailsResponse> CreateResponse(IEnumerable<HeldInvoiceDetailsDomain> heldInvoices, PagingMetaData pagingMetaData)
        {
            var invoices = new List<HeldInvoiceDetailsResponse>();

            foreach (var invoice in heldInvoices)
            {
                var (supplierReclaimsTotal, hackneyReclaimsTotal) = CalculateTotals(invoice.PayRunInvoice.InvoiceItems);
                var invoiceRes = new HeldInvoiceDetailsResponse
                {
                    PayRunId = invoice.PayRunId,
                    PayRunNumber = invoice.PayRunNumber,
                    DateCreated = invoice.DateCreated,
                    StartDate = invoice.StartDate,
                    EndDate = invoice.EndDate,
                    PayRunInvoice = new PayRunInvoiceResponse
                    {
                        Id = invoice.PayRunInvoice.Id,
                        InvoiceId = invoice.PayRunInvoice.InvoiceId,
                        CarePackageId = invoice.PayRunInvoice.CarePackageId,
                        ServiceUserId = invoice.PayRunInvoice.ServiceUserId,
                        ServiceUserName = invoice.PayRunInvoice.ServiceUserName,
                        SupplierId = invoice.PayRunInvoice.SupplierId,
                        SupplierName = invoice.PayRunInvoice.SupplierName,
                        InvoiceNumber = invoice.PayRunInvoice.InvoiceNumber,
                        PackageTypeId = (int) invoice.PayRunInvoice.PackageType,
                        PackageType = invoice.PayRunInvoice.PackageType.GetDisplayName(),
                        GrossTotal = decimal.Round(invoice.PayRunInvoice.GrossTotal, 2),
                        NetTotal = decimal.Round(invoice.PayRunInvoice.NetTotal, 2),
                        SupplierReclaimsTotal = decimal.Round(supplierReclaimsTotal, 2),
                        HackneyReclaimsTotal = decimal.Round(hackneyReclaimsTotal, 2),
                        InvoiceStatus = invoice.PayRunInvoice.InvoiceStatus,
                        AssignedBrokerName = invoice.PayRunInvoice.AssignedBrokerName,
                        InvoiceItems = invoice.PayRunInvoice.InvoiceItems.ToResponse()
                    }
                };
                invoices.Add(invoiceRes);
            }

            var result = new PagedResponse<HeldInvoiceDetailsResponse>
            {
                PagingMetaData = pagingMetaData,
                Data = invoices
            };

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
