using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface IFundedNursingCaseGateway
    {
        Task<FundedNursingCareDomain> UpsertFundedNursingCase(FundedNursingCareDomain fundedNursingCareDomain);

        Task<bool> DeleteFundedNursingCare(Guid packageId);

        Task<decimal> GetFundedNursingCarePrice(DateTimeOffset dateTime);
    }
}
