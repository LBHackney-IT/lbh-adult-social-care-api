using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface ICreateDayCarePackageUseCase
    {
        Task<Guid> Execute(Infrastructure.Entities.DayCarePackage dayCarePackage);
    }
}
