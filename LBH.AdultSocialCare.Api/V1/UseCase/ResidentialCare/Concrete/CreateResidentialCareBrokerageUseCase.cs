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
    public class CreateResidentialCareBrokerageUseCase : ICreateResidentialCareBrokerageUseCase
    {
        private readonly IResidentialCareBrokerageGateway _residentialCareBrokerageGateway;
        private readonly IResidentialCarePackageGateway _residentialCarePackageGateway;
        private readonly IMapper _mapper;

        public CreateResidentialCareBrokerageUseCase(IResidentialCareBrokerageGateway residentialCareBrokerageGateway,
            IResidentialCarePackageGateway residentialCarePackageGateway,
            IMapper mapper)
        {
            _residentialCareBrokerageGateway = residentialCareBrokerageGateway;
            _residentialCarePackageGateway = residentialCarePackageGateway;
            _mapper = mapper;
        }

        public async Task<ResidentialCareBrokerageInfoResponse> ExecuteAsync(ResidentialCareBrokerageForCreationDomain residentialCareBrokerageForCreationDomain)
        {
            var brokerageInfo = await _residentialCareBrokerageGateway.GetAsync(residentialCareBrokerageForCreationDomain.ResidentialCarePackageId).ConfigureAwait(false);

            if (brokerageInfo.ResidentialCareBrokerageId != Guid.Empty)
            {
                throw new ApiException($"A brokerage for residential care package {residentialCareBrokerageForCreationDomain.ResidentialCarePackageId} already exists");
            }

            var residentialCareBrokerageInfoEntity = residentialCareBrokerageForCreationDomain.ToDb();
            var res = await _residentialCareBrokerageGateway.CreateAsync(residentialCareBrokerageInfoEntity).ConfigureAwait(false);
            if (res == null) return null;
            var residentialCarePackageDomain = await _residentialCarePackageGateway.GetAsync(residentialCareBrokerageForCreationDomain.ResidentialCarePackageId).ConfigureAwait(false);
            if (residentialCarePackageDomain == null)
            {
                throw new ApiException($"Residential care package with id {residentialCareBrokerageForCreationDomain.ResidentialCarePackageId} not found", StatusCodes.Status404NotFound);
            }
            residentialCarePackageDomain.StageId = residentialCareBrokerageForCreationDomain.StageId;
            residentialCarePackageDomain.SupplierId = residentialCareBrokerageForCreationDomain.SupplierId;
            var residentialCarePackageForUpdateDomain = new ResidentialCarePackageForUpdateDomain();
            _mapper.Map(residentialCarePackageDomain, residentialCarePackageForUpdateDomain);
            // Update package
            await _residentialCarePackageGateway.UpdateAsync(residentialCarePackageForUpdateDomain).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
