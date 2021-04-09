using BaseApi.V1.Domain.DayCarePackageDomains;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface ICreateDayCarePackageUseCase
    {
        Task<Guid> Execute(DayCarePackageForCreationDomain dayCarePackageForCreationDomain);
    }
}
