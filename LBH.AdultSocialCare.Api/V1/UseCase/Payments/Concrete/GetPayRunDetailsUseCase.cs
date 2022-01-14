using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunDetailsUseCase : IGetPayRunDetailsUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public GetPayRunDetailsUseCase(IPayRunGateway payRunGateway, IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _payRunGateway = payRunGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task<PayRunDetailsViewResponse> ExecuteAsync(Guid payrunId, PayRunDetailsQueryParameters parameters)
        {
            // Get pay run
            var payRun = await _payRunGateway
                .GetPayRunAsync(payrunId)
                .EnsureExistsAsync($"Pay Run {payrunId} not found");

            // Get pay run items
            var payRunInvoices =
                await _payRunInvoiceGateway.GetPayRunInvoicesSummaryAsync(payrunId, parameters);
            var result = CreateResponse(payRun, payRunInvoices, payRunInvoices.PagingMetaData);
            return result;
        }

        private static PayRunDetailsViewResponse CreateResponse(Payrun payrun, IEnumerable<PayRunInvoiceDomain> payRunInvoices, PagingMetaData pagingMetaData)
        {
            var result = new PayRunDetailsViewResponse
            {
                PayRunId = payrun.Id,
                PayRunStatus = payrun.Status,
                PayRunNumber = payrun.Number,
                DateCreated = payrun.DateCreated,
                StartDate = payrun.StartDate,
                EndDate = payrun.EndDate
            };

            var invoices = new List<PayRunInvoiceResponse>();

            foreach (var invoice in payRunInvoices)
            {
                var (supplierReclaimsTotal, hackneyReclaimsTotal) = CalculateTotals(invoice.InvoiceItems);
                InvoiceStatus invoiceStatus = invoice.InvoiceStatus;
                if ((payrun.Status == PayrunStatus.Paid || payrun.Status == PayrunStatus.PaidWithHold)
                  && (invoice.InvoiceStatus == InvoiceStatus.Released || invoice.InvoiceStatus == InvoiceStatus.ReleaseAccepted))
                {
                    invoiceStatus = InvoiceStatus.Held;
                }

                var invoiceRes = new PayRunInvoiceResponse
                {
                    Id = invoice.Id,
                    InvoiceId = invoice.InvoiceId,
                    CarePackageId = invoice.CarePackageId,
                    ServiceUserId = invoice.ServiceUserId,
                    HackneyId = invoice.HackneyId,
                    ServiceUserName = invoice.ServiceUserName,
                    SupplierId = invoice.SupplierId,
                    SupplierName = invoice.SupplierName,
                    InvoiceNumber = invoice.InvoiceNumber,
                    PackageTypeId = (int) invoice.PackageType,
                    PackageType = invoice.PackageType.GetDisplayName(),
                    GrossTotal = decimal.Round(invoice.GrossTotal, 2),
                    NetTotal = decimal.Round(invoice.NetTotal, 2),
                    SupplierReclaimsTotal = decimal.Round(supplierReclaimsTotal, 2),
                    HackneyReclaimsTotal = decimal.Round(hackneyReclaimsTotal, 2),
                    InvoiceStatus = invoiceStatus,
                    AssignedBrokerName = invoice.AssignedBrokerName,
                    InvoiceItems = invoice.InvoiceItems.ToResponse()
                };
                invoices.Add(invoiceRes);
            }

            result.PayRunItems = new PagedResponse<PayRunInvoiceResponse>
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
