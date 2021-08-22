using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
{
    public class CreateResidentialCarePackageReclaimUseCase : ICreateResidentialCarePackageReclaimUseCase
    {
        private readonly IResidentialCarePackageReclaimGateway _residentialCarePackageReclaimGateway;

        public CreateResidentialCarePackageReclaimUseCase(IResidentialCarePackageReclaimGateway residentialCarePackageReclaimGateway)
        {
            _residentialCarePackageReclaimGateway = residentialCarePackageReclaimGateway;
        }

        public async Task<ResidentialCarePackageClaimResponse> ExecuteAsync(ResidentialCarePackageClaimCreationDomain residentialCarePackageClaimCreationDomain)
        {
            var residentialCarePackageClaimEntity = residentialCarePackageClaimCreationDomain.ToDb();
            var res = await _residentialCarePackageReclaimGateway.CreateAsync(residentialCarePackageClaimEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
