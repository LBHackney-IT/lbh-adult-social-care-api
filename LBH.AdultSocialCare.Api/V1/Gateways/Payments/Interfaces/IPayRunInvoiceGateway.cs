using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces
{
    public interface IPayRunInvoiceGateway
    {
        Task<PagedList<PayrunInvoice>> GetPayRunInvoicesAsync(Guid payRunId, PayRunDetailsQueryParameters parameters, PayRunInvoiceFields fields = PayRunInvoiceFields.None, bool trackChanges = false);

        Task<PagedList<PayRunInvoiceDomain>> GetPayRunInvoicesSummaryAsync(Guid payRunId, PayRunDetailsQueryParameters parameters);
    }
}
