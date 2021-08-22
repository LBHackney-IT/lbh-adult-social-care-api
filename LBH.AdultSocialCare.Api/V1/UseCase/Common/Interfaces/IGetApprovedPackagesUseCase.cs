using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetApprovedPackagesUseCase
    {
        Task<PagedApprovedPackagesResponse> GetApprovedPackages(ApprovedPackagesParameters parameters, int statusId);
    }
}
