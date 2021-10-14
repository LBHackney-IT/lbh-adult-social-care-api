using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetSinglePackageCareChargeUseCase
    {
        Task<SinglePackageCareChargeResponse> GetSinglePackageCareCharge(Guid packageId);
    }
}
