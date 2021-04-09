using LBH.AdultSocialCare.Api.V1.Domain;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertHomeCarePackageUseCase
    {
        public Task<HomeCarePackageDomain> ExecuteAsync(HomeCarePackageDomain homeCarePackage);
    }
}
