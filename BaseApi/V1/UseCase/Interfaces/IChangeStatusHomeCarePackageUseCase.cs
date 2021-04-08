using BaseApi.V1.Domain;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IChangeStatusHomeCarePackageUseCase
    {
        public Task<HomeCarePackageDomain> UpdateAsync(HomeCarePackageDomain homeCarePackage);
    }
}
