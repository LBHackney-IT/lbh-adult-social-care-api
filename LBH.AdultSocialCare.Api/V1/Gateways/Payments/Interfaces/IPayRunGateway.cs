using Common.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces
{
    public interface IPayRunGateway
    {
        Task<Payrun> GetPayRunAsync(Guid payRunId, PayRunFields fields = PayRunFields.None, bool trackChanges = false);

        Task<PagedList<PayRunListDomain>> GetPayRunList(PayRunListParameters parameters);

        Task CreateDraftPayRun(Payrun payRun);

        Task<int> GetDraftPayRunCount(PayrunType payRunType);

        Task<bool> CheckExistsUnApprovedPayRunAsync(PayrunType payRunType);

        Task<DateTimeOffset> GetEndDateOfLastPayRun(PayrunType payRunType);

        Task<Payrun> GetPreviousPayRunAsync(PayrunType payRunType);
    }
}
