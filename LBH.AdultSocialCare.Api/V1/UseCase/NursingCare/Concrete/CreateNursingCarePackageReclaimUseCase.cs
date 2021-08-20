using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class CreateNursingCarePackageReclaimUseCase : ICreateNursingCarePackageReclaimUseCase
    {
        private readonly INursingCarePackageReclaimGateway _nursingCarePackageReclaimGateway;

        public CreateNursingCarePackageReclaimUseCase(INursingCarePackageReclaimGateway nursingCarePackageReclaimGateway)
        {
            _nursingCarePackageReclaimGateway = nursingCarePackageReclaimGateway;
        }

        public async Task<NursingCarePackageClaimResponse> ExecuteAsync(NursingCarePackageClaimCreationDomain nursingCarePackageClaimCreationDomain)
        {
            var residentialCarePackageClaimEntity = nursingCarePackageClaimCreationDomain.ToDb();
            var res = await _nursingCarePackageReclaimGateway.CreateAsync(residentialCarePackageClaimEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
