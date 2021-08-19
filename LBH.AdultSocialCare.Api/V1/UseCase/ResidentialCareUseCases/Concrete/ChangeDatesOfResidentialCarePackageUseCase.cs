using System;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class ChangeDatesOfResidentialCarePackageUseCase : IChangeDatesOfResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;
        private readonly IMapper _mapper;

        public ChangeDatesOfResidentialCarePackageUseCase(IResidentialCarePackageGateway gateway, IMapper mapper)
        {
            _gateway = gateway;
            _mapper = mapper;
        }

        public async Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            var package = await _gateway.GetAsync(residentialCarePackageId).ConfigureAwait(false);

            package.EndDate = endDate;
            if (startDate.HasValue) // brokers are prohibited to change start date
            {
                package.StartDate = startDate.Value;
            }

            var packageForUpdate = _mapper.Map<ResidentialCarePackageForUpdateDomain>(package);
            var updatedPackage = await _gateway.UpdateAsync(packageForUpdate).ConfigureAwait(false);

            return updatedPackage.ToResponse();
        }
    }
}
