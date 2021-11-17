using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces
{
    public interface IPayRunInvoiceGateway
    {
        Task<PagedList<PayrunInvoice>> GetPayRunInvoicesAsync(Guid payRunId, RequestParameters parameters, InvoiceStatus[] statuses, PayRunInvoiceFields fields = PayRunInvoiceFields.None, bool trackChanges = false);

        Task<PagedList<PayrunInvoice>> GetPackageInvoicesAsync(Guid packageId, RequestParameters parameters, PayrunStatus[] payRunStatuses, InvoiceStatus[] invoiceStatuses, PayRunInvoiceFields fields = PayRunInvoiceFields.None, bool trackChanges = false);

        Task<PayRunInsightsDomain> GetPayRunInsightsAsync(Guid payRunId);

        Task<PagedList<PayRunInvoiceDomain>> GetPayRunInvoicesSummaryAsync(Guid payRunId, PayRunDetailsQueryParameters parameters);

        Task<PayRunInvoiceDomain> GetPayRunInvoiceDetailAsync(Guid payRunId, Guid invoiceId, bool trackChanges = false);

        Task<PayrunInvoice> GetPayRunInvoiceAsync(Guid payRunInvoiceId, PayRunInvoiceFields fields = PayRunInvoiceFields.None, bool trackChanges = false);

        Task<decimal> GetPayRunInvoicedTotalAsync(Guid payRunId);

        Task<int> GetReleasedInvoiceCountAsync();
    }
}
