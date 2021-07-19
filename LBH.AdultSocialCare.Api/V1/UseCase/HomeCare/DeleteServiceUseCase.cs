using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{

    public class DeleteServiceUseCase : IDeleteServiceUseCase
    {

        private readonly IHomeCareServiceTypeGateway _typeGateway;

        public DeleteServiceUseCase(IHomeCareServiceTypeGateway homeCareServiceTypeGateway)
        {
            _typeGateway = homeCareServiceTypeGateway;
        }

        public async Task<bool> DeleteAsync(int serviceId)
        {
            return await _typeGateway.DeleteAsync(serviceId).ConfigureAwait(false);
        }

    }

}
