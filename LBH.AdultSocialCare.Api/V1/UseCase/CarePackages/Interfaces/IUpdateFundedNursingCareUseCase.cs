using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IUpdateFundedNursingCareUseCase
    {
        public Task UpdateAsync(CarePackageReclaimUpdateDomain requestedReclaim, Guid packageId);
    }
}
