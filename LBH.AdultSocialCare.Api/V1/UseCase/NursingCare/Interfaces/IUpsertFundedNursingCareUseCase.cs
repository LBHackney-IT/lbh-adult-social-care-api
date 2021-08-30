using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface IUpsertFundedNursingCareUseCase
    {
        Task<FundedNursingCareDomain> UpsertAsync(Guid packageId, int? supplierId, int? collectorId);
    }
}
