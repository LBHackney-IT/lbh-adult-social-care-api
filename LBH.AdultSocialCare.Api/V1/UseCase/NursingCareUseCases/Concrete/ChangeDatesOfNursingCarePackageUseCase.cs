using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;

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

        public async Task<NursingCarePackageResponse> UpdateAsync(Guid nursingCarePackageId, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            var package = await _gateway.GetAsync(nursingCarePackageId).ConfigureAwait(false);

            package.StartDate = startDate;
            package.EndDate = endDate;

            var packageForUpdate = _mapper.Map<NursingCarePackageForUpdateDomain>(package);
            var updatedPackage = await _gateway.UpdateAsync(packageForUpdate).ConfigureAwait(false);

            return updatedPackage.ToResponse();
        }
    }
}