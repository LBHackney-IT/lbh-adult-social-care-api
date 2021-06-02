using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Concrete
{
    public class CreateNursingCareBrokerageUseCase : ICreateNursingCareBrokerageUseCase
    {
        private readonly INursingCareBrokerageGateway _nursingCareBrokerageGateway;
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;
        private readonly IMapper _mapper;

        public CreateNursingCareBrokerageUseCase(INursingCareBrokerageGateway nursingCareBrokerageGateway, INursingCarePackageGateway nursingCarePackageGateway, IMapper mapper)
        {
            _nursingCareBrokerageGateway = nursingCareBrokerageGateway;
            _nursingCarePackageGateway = nursingCarePackageGateway;
            _mapper = mapper;
        }

        public async Task<NursingCareBrokerageInfoResponse> ExecuteAsync(NursingCareBrokerageInfoCreationDomain nursingCareBrokerageInfoCreationDomain)
        {
            var nursingCareBrokerageInfoEntity = nursingCareBrokerageInfoCreationDomain.ToDb();
            var res = await _nursingCareBrokerageGateway.CreateAsync(nursingCareBrokerageInfoEntity).ConfigureAwait(false);
            if (res == null) return res.ToResponse();
            var nursingCarePackageDomain = await _nursingCarePackageGateway.GetAsync(nursingCareBrokerageInfoCreationDomain.NursingCarePackageId).ConfigureAwait(false);
            nursingCarePackageDomain.StageId = nursingCareBrokerageInfoCreationDomain.StageId;
            nursingCarePackageDomain.SupplierId = nursingCareBrokerageInfoCreationDomain.SupplierId;
            var nursingCarePackageForUpdateDomain = new NursingCarePackageForUpdateDomain();
            _mapper.Map(nursingCarePackageDomain, nursingCarePackageForUpdateDomain);
            // Update package
            await _nursingCarePackageGateway.UpdateAsync(nursingCarePackageForUpdateDomain).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
