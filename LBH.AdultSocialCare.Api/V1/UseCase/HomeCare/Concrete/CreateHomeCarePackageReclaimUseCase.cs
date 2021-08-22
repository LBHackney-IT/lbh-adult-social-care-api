using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
{
    public class CreateHomeCarePackageReclaimUseCase : ICreateHomeCarePackageReclaimUseCase
    {
        private readonly IHomeCarePackageReclaimGateway _homeCarePackageReclaimGateway;

        public CreateHomeCarePackageReclaimUseCase(IHomeCarePackageReclaimGateway homeCarePackageReclaimGateway)
        {
            _homeCarePackageReclaimGateway = homeCarePackageReclaimGateway;
        }

        public async Task<HomeCarePackageClaimResponse> ExecuteAsync(HomeCarePackageClaimCreationDomain homeCarePackageClaimCreationDomain)
        {
            var homeCarePackageClaimEntity = homeCarePackageClaimCreationDomain.ToDb();
            var res = await _homeCarePackageReclaimGateway.CreateAsync(homeCarePackageClaimEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
