using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class CreateResidentialCarePackageUseCase : ICreateResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _residentialCarePackageGateway;
        private readonly IClientsGateway _clientsGateway;

        public CreateResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway, IClientsGateway clientsGateway)
        {
            _residentialCarePackageGateway = residentialCarePackageGateway;
            _clientsGateway = clientsGateway;
        }

        public async Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForCreationDomain residentialCarePackageForCreation)
        {
            var residentialCarePackageEntity = residentialCarePackageForCreation.ToDb();
            var client = await _clientsGateway.GetRandomAsync().ConfigureAwait(false);
            residentialCarePackageEntity.ClientId = client.Id;
            var res = await _residentialCarePackageGateway.CreateAsync(residentialCarePackageEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
