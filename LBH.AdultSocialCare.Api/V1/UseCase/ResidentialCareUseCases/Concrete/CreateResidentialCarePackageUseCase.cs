using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

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
