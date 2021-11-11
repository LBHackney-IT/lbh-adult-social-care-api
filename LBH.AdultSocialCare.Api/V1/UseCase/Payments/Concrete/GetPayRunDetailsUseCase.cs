using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;

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
                PayRunNumber = payrun.Id.ToString().Substring(0, 6),
                DateCreated = payrun.DateCreated,
                StartDate = payrun.StartDate,
                EndDate = payrun.EndDate
            };

            var invoices = new List<PayRunInvoiceResponse>();

            foreach (var invoice in payRunInvoices)
            {
                var (grossTotal, netTotal) = CalculateTotals(invoice.InvoiceItems);
                var invoiceRes = new PayRunInvoiceResponse
                {
                    Id = invoice.Id,
                    InvoiceId = invoice.InvoiceId,
                    CarePackageId = invoice.CarePackageId,
                    ServiceUserId = invoice.ServiceUserId,
                    ServiceUserName = invoice.ServiceUserName,
                    SupplierId = invoice.SupplierId,
                    SupplierName = invoice.SupplierName,
                    InvoiceNumber = invoice.InvoiceNumber,
                    PackageTypeId = (int) invoice.PackageType,
                    PackageType = invoice.PackageType.GetDisplayName(),
                    GrossTotal = grossTotal,
                    NetTotal = netTotal,
                    InvoiceStatus = invoice.InvoiceStatus,
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
            var grossTotal = 0M;
            var netTotal = 0M;

            foreach (var invoiceItem in invoiceItems)
            {
                if (invoiceItem.IsReclaim == false && invoiceItem.PriceEffect == PriceEffect.Add)
                {
                    grossTotal += invoiceItem.TotalCost;
                    netTotal += invoiceItem.TotalCost;
                }

                if (invoiceItem.IsReclaim && invoiceItem.ClaimCollector == ClaimCollector.Supplier && invoiceItem.PriceEffect == PriceEffect.Subtract)
                {
                    netTotal -= invoiceItem.TotalCost;
                }
            }

            return (grossTotal, netTotal);
        }
    }
}
