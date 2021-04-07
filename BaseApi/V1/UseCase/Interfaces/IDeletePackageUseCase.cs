using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IDeletePackageUseCase
    {
        public Task<bool> DeleteAsync(Guid packageId);
    }
}
