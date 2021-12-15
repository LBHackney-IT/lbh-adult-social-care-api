using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces
{
    public interface IPayRunGateway
    {
        Task<Payrun> GetPayRunAsync(Guid payRunId, PayRunFields fields = PayRunFields.None, bool trackChanges = false);

        Task<PagedList<PayRunListDomain>> GetPayRunList(PayRunListParameters parameters);

        Task CreateDraftPayRun(Payrun payRun);

        Task<int> GetDraftPayRunCount(PayrunType payRunType);

        Task<bool> CheckExistsUnApprovedPayRunAsync();

        Task<IEnumerable<Payrun>> GetPayRunsByTypeAndStatusAsync(PayrunType[] types, PayrunStatus[] statuses);

        Task<DateTimeOffset> GetEndDateOfLastPayRun(PayrunType payRunType);

        Task<Payrun> GetPreviousPayRunAsync(PayrunType payRunType);

        Task<Payrun> GetPackageLatestPayRunAsync(Guid packageId, PayrunType[] payrunTypes, PayrunStatus[] payRunStatuses, InvoiceStatus[] invoiceStatuses);

        Task<List<CedarFileInvoiceHeader>> GetCedarFileList(Guid payRunId);

        Task<CedarFileHeader> GetPayRunInvoicesInfoAsync(Guid payRunId);
    }
}
