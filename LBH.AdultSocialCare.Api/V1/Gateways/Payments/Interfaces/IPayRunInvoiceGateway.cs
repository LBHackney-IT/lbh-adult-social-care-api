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
        Task<PagedList<PayrunInvoice>> GetPayRunInvoicesAsync(Guid payRunId, PayRunDetailsQueryParameters parameters, PayRunInvoiceFields fields = PayRunInvoiceFields.None, bool trackChanges = false);

        Task<PagedList<PayRunInvoiceDomain>> GetPayRunInvoicesSummaryAsync(Guid payRunId, PayRunDetailsQueryParameters parameters);

        Task<PayrunInvoice> GetPayRunInvoiceAsync(Guid payRunInvoiceId, PayRunInvoiceFields fields = PayRunInvoiceFields.None, bool trackChanges = false);

        Task<decimal> GetPayRunInvoicedTotalAsync(Guid payRunId);

        Task<int> GetSupplierCountInPayRunAsync(Guid payRunId);

        Task<int> GetServiceUserCountInPayRunAsync(Guid payRunId);

        Task<int> GetPayRunHeldInvoiceCountAsync(Guid payRunId);

        Task<decimal> GetPayRunHeldInvoiceTotalAsync(Guid payRunId);
    }
}
