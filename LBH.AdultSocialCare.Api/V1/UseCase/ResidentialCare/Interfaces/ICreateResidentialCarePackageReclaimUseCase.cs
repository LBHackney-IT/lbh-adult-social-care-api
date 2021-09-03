using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces
{
    public interface ICreateResidentialCarePackageReclaimUseCase
    {
        Task<ResidentialCarePackageClaimResponse> ExecuteAsync(ResidentialCarePackageClaimCreationDomain residentialCarePackageClaimCreationDomain);
    }
}
