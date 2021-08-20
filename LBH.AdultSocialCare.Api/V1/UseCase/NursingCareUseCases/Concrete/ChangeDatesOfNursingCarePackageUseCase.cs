using AutoMapper;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class ChangeDatesOfNursingCarePackageUseCase : IChangeDatesOfNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        private readonly IMapper _mapper;

        public ChangeDatesOfNursingCarePackageUseCase(INursingCarePackageGateway gateway, IMapper mapper)
        {
            _gateway = gateway;
            _mapper = mapper;
        }

        public async Task<NursingCarePackageResponse> UpdateAsync(Guid nursingCarePackageId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var package = await _gateway.GetAsync(nursingCarePackageId).ConfigureAwait(false);

            package.EndDate = endDate;
            if (startDate.HasValue)  // brokers are prohibited to change start date
            {
                package.StartDate = startDate.Value;
            }

            var packageForUpdate = _mapper.Map<NursingCarePackageForUpdateDomain>(package);
            var updatedPackage = await _gateway.UpdateAsync(packageForUpdate).ConfigureAwait(false);

            return updatedPackage.ToResponse();
        }
    }
}
