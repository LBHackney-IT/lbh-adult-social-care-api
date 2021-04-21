using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases
{
    public class GetAllNursingCareTypeOfStayOptionUseCase : IGetAllNursingCareTypeOfStayOptionUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        public GetAllNursingCareTypeOfStayOptionUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<IList<NursingCareTypeOfStayOptionDomain>> GetAllAsync()
        {
            var result = await _gateway.GetListOfNursingCareTypeOfStayOptionAsync().ConfigureAwait(false);
            return NursingCarePackageFactory.ToDomain(result);
        }
    }
}
