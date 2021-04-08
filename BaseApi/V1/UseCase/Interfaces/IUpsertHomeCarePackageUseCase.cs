using BaseApi.V1.Domain;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IUpsertHomeCarePackageUseCase
    {
        public Task<HomeCarePackageDomain> ExecuteAsync(HomeCarePackageDomain homeCarePackage);
    }
}
