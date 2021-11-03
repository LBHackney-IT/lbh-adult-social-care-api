using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCareChargePackagesUseCase
    {
        Task<PagedResponse<CareChargePackagesResponse>> GetCareChargePackages(CareChargePackagesParameters parameters);
    }
}
