using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetApprovedPackagesUseCase
    {
        Task<PagedApprovedPackagesResponse> GetApprovedPackages(ApprovedPackagesParameters parameters, int statusId);
    }
}
