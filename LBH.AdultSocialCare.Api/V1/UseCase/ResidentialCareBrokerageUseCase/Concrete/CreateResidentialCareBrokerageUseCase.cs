using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Concrete
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

        public async Task<ResidentialCareBrokerageInfoResponse> ExecuteAsync(ResidentialCareBrokerageInfoCreationDomain residentialCareBrokerageInfoCreationDomain)
        {
            var brokerageInfo = await _residentialCareBrokerageGateway.GetAsync(residentialCareBrokerageInfoCreationDomain.ResidentialCarePackageId).ConfigureAwait(false);

            if (brokerageInfo.Id != Guid.Empty)
            {
                throw new ApiException($"A brokerage for residential care package {residentialCareBrokerageInfoCreationDomain.ResidentialCarePackageId} already exists");
            }

            var residentialCareBrokerageInfoEntity = residentialCareBrokerageInfoCreationDomain.ToDb();
            var res = await _residentialCareBrokerageGateway.CreateAsync(residentialCareBrokerageInfoEntity).ConfigureAwait(false);
            if (res == null) return null;
            var residentialCarePackageDomain = await _residentialCarePackageGateway.GetAsync(residentialCareBrokerageInfoCreationDomain.ResidentialCarePackageId).ConfigureAwait(false);
            residentialCarePackageDomain.StageId = residentialCareBrokerageInfoCreationDomain.StageId;
            residentialCarePackageDomain.SupplierId = residentialCareBrokerageInfoCreationDomain.SupplierId;
            var residentialCarePackageForUpdateDomain = new ResidentialCarePackageForUpdateDomain();
            _mapper.Map(residentialCarePackageDomain, residentialCarePackageForUpdateDomain);
            // Update package
            await _residentialCarePackageGateway.UpdateAsync(residentialCarePackageForUpdateDomain).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
