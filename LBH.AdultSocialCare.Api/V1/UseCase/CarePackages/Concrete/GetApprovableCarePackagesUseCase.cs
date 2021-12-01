using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetApprovableCarePackagesUseCase : IGetApprovableCarePackagesUseCase
    {
        private readonly ICarePackageGateway _gateway;

        public GetApprovableCarePackagesUseCase(ICarePackageGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<PagedList<CarePackageApprovableListItemDomain>> GetListAsync(ApprovableCarePackagesQueryParameters parameters)
        {
            return await _gateway.GetApprovablePackagesAsync(parameters, new[] { PackageStatus.SubmittedForApproval, PackageStatus.NotApproved, PackageStatus.Approved });
        }
    }
}
