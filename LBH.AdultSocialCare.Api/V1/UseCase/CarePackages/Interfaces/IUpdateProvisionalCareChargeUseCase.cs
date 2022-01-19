using System;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IUpdateProvisionalCareChargeUseCase
    {
        Task UpdateAsync(Guid packageId, CarePackageReclaimUpdateDomain requestedReclaim);
    }
}
