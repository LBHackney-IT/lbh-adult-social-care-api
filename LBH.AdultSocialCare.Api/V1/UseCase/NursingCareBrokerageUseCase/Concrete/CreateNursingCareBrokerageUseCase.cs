using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
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
            var brokerage = await _nursingCareBrokerageGateway.GetAsync(nursingCareBrokerageInfoCreationDomain.NursingCarePackageId).ConfigureAwait(false);

            if (brokerage.NursingCareBrokerageId != Guid.Empty)
            {
                throw new ApiException($"A brokerage for nursing care package {nursingCareBrokerageInfoCreationDomain.NursingCarePackageId} already exists");
            }

            var nursingCareBrokerageInfoEntity = nursingCareBrokerageInfoCreationDomain.ToDb();
            var res = await _nursingCareBrokerageGateway.CreateAsync(nursingCareBrokerageInfoEntity).ConfigureAwait(false);
            if (res == null) return null;
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
