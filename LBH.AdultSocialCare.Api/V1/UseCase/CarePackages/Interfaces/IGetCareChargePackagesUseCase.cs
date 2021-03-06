using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCareChargePackagesUseCase
    {
        Task<PagedResponse<CareChargePackagesResponse>> GetCareChargePackages(CareChargePackagesParameters parameters);
    }
}
