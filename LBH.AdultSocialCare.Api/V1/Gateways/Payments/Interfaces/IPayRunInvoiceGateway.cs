using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Threading.Tasks;

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
