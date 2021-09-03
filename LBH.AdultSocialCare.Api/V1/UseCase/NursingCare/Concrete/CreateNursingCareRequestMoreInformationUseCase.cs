using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class CreateNursingCareRequestMoreInformationUseCase : ICreateNursingCareRequestMoreInformationUseCase
    {
        private readonly INursingCareRequestMoreInformationGateway _requestMoreInformationGateway;

        public CreateNursingCareRequestMoreInformationUseCase(INursingCareRequestMoreInformationGateway requestMoreInformationGateway)
        {
            _requestMoreInformationGateway = requestMoreInformationGateway;
        }

        public async Task<bool> Execute(NursingCareRequestMoreInformationDomain nursingCareRequestMoreInformation)
        {
            var nursingCareRequestMoreInformationEntity = nursingCareRequestMoreInformation.ToDb();
            //Todo send mail if succeed
            return await _requestMoreInformationGateway.CreateAsync(nursingCareRequestMoreInformationEntity).ConfigureAwait(false);
        }
    }
}
