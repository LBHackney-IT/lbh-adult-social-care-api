using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class CreateResidentialCarePackageUseCase : ICreateResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _residentialCarePackageGateway;

        public CreateResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _residentialCarePackageGateway = residentialCarePackageGateway;
        }

        public async Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForCreationDomain residentialCarePackageForCreation)
        {
            var residentialCarePackageEntity = residentialCarePackageForCreation.ToDb();
            var res = await _residentialCarePackageGateway.CreateAsync(residentialCarePackageEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
