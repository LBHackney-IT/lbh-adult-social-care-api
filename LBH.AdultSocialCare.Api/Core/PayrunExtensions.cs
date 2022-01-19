using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Api.Core
{
    public static class PayrunExtensions
    {
        public static (decimal, decimal) CalculateTotals(IEnumerable<PayRunInvoiceItemDomain> invoiceItems)
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

        public static PayRunDetailsViewResponse CreateDetailsViewResponse(Payrun payrun, IEnumerable<PayRunInvoiceDomain> payRunInvoices, PagingMetaData pagingMetaData)
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
                var (supplierReclaimsTotal, hackneyReclaimsTotal) = PayrunExtensions.CalculateTotals(invoice.InvoiceItems.Where(i => i.PriceEffect != PriceEffect.None).ToList());
                var invoiceStatus = invoice.InvoiceStatus;
                if (payrun.Status.In(PayrunStatus.Paid, PayrunStatus.PaidWithHold)
                    && invoice.InvoiceStatus.In(InvoiceStatus.Released, InvoiceStatus.ReleaseAccepted))
                {
                    invoiceStatus = InvoiceStatus.Held;
                }

                var invoiceRes = invoice.ToResponse(invoiceStatus, supplierReclaimsTotal, hackneyReclaimsTotal);
                invoices.Add(invoiceRes);
            }

            result.PayRunItems = new PagedResponse<PayRunInvoiceResponse>
            {
                PagingMetaData = pagingMetaData,
                Data = invoices
            };

            return result;
        }
    }
}
