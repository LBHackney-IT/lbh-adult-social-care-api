using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetApprovableCarePackagesUseCase
    {
        Task<PagedList<CarePackageApprovableListItemDomain>> GetListAsync(ApprovableCarePackagesQueryParameters parameters);
    }
}
