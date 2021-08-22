using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class GetNursingCareAdditionalNeedsPaymentTypesUseCase : IGetNursingCareAdditionalNeedsPaymentTypesUseCase
    {
        private readonly INursingCareAdditionalNeedsGateway _nursingCareAdditionalNeedsGateway;

        public GetNursingCareAdditionalNeedsPaymentTypesUseCase(INursingCareAdditionalNeedsGateway nursingCareAdditionalNeedsGateway)
        {
            _nursingCareAdditionalNeedsGateway = nursingCareAdditionalNeedsGateway;
        }

        public async Task<IEnumerable<AdditionalNeedsPaymentTypeResponse>> GetAllAsync()
        {
            var result = await _nursingCareAdditionalNeedsGateway.GetListOfTypeOfPaymentOptionList().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
