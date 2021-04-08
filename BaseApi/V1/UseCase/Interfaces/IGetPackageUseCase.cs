using BaseApi.V1.Domain;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IGetPackageUseCase
    {
        public Task<PackageDomain> GetAsync(Guid packageId);
    }
}
