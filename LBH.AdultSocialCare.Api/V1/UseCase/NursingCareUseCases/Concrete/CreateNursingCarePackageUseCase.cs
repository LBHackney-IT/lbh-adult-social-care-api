using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class CreateNursingCarePackageUseCase : ICreateNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;
        private readonly IClientsGateway _clientsGateway;

        public CreateNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway, IClientsGateway clientsGateway)
        {
            _nursingCarePackageGateway = nursingCarePackageGateway;
            _clientsGateway = clientsGateway;
        }

        public async Task<NursingCarePackageResponse> ExecuteAsync(NursingCarePackageForCreationDomain nursingCarePackageForCreation)
        {
            var nursingCarePackageEntity = nursingCarePackageForCreation.ToDb();
            var client = await _clientsGateway.GetRandomAsync().ConfigureAwait(false);
            nursingCarePackageEntity.ClientId = client.Id;
            var res = await _nursingCarePackageGateway.CreateAsync(nursingCarePackageEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
