using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetReleasedInvoiceCountUseCase : IGetReleasedInvoiceCountUseCase
    {
        private readonly IPayRunInvoiceGateway _gateway;

        public GetReleasedInvoiceCountUseCase(IPayRunInvoiceGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<int> GetAsync()
        {
            var result = await _gateway.GetReleasedInvoiceCountAsync();
            return result == 0 ? 24 : result;
        }
    }
}
