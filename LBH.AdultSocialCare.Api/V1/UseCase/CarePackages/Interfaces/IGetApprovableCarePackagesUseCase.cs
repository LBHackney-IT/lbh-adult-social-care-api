using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetApprovableCarePackagesUseCase
    {
        Task<PagedList<CarePackageApprovableListItemDomain>> GetListAsync(ApprovableCarePackagesQueryParameters parameters);
    }
}
