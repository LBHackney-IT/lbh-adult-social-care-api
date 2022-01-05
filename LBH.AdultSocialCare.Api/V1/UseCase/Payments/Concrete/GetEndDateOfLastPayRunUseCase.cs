using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetEndDateOfLastPayRunUseCase : IGetEndDateOfLastPayRunUseCase
    {
        private readonly IPayRunGateway _gateway;

        public GetEndDateOfLastPayRunUseCase(IPayRunGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<DateTimeOffset> GetAsync(PayrunType type)
        {
            return await _gateway.GetEndDateOfLastPayRun();
        }
    }
}
