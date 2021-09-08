using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CreateCareChargeElementUseCase : ICreateCareChargeElementUseCase
    {
        private readonly ICareChargesGateway _gateway;

        public CreateCareChargeElementUseCase(ICareChargesGateway gateway)
        {
            _gateway = gateway;
        }
        public Task<CareChargeElementPlainDomain> ExecuteAsync(CareChargeElementPlainDomain careChargeElement)
        {
            throw new NotImplementedException();
        }
    }
}
