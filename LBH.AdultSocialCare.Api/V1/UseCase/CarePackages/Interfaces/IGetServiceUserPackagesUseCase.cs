using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetServiceUserPackagesUseCase
    {
        Task<ServiceUserPackagesViewResponse> ExecuteAsync(Guid serviceUserId);
    }
}
