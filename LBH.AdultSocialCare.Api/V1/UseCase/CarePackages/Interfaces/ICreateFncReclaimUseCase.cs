using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICreateFncReclaimUseCase
    {
        Task<CarePackageReclaimResponse> ExecuteAsync(CarePackageReclaimCreationDomain requestedReclaim);
    }
}
