using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
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

            if (package == null)
            {
                throw new ApiException($"Residential care package with id {residentialCarePackageId} not found", StatusCodes.Status404NotFound);
            }

            if (package.StartDate > endDate)
            {
                throw new ApiException($"Residential care package date change for package with id {residentialCarePackageId} failed. Package start date cannot be greater than end date ", StatusCodes.Status422UnprocessableEntity);
            }

            package.EndDate = endDate;
            // brokers are prohibited to change package start date
            /*if (startDate.HasValue)
            {
                package.StartDate = startDate.Value;
            }*/

            var packageForUpdate = _mapper.Map<ResidentialCarePackageForUpdateDomain>(package);
            var updatedPackage = await _gateway.UpdateAsync(packageForUpdate).ConfigureAwait(false);

            return updatedPackage.ToResponse();
        }
    }
}
