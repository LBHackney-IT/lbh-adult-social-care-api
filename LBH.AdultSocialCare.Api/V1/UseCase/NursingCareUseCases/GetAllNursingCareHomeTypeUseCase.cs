using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases
{
    public class GetAllNursingCareHomeTypeUseCase : IGetAllNursingCareHomeTypeUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        public GetAllNursingCareHomeTypeUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<IList<TypeOfNursingCareHomeDomain>> GetAllAsync()
        {
            var result = await _gateway.GetListOfTypeOfNursingCareHomeAsync().ConfigureAwait(false);
            return NursingCarePackageFactory.ToDomain(result);
        }
    }
}
