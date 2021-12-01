using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IDeclineCarePackageUseCase
    {
        Task ExecuteAsync(Guid packageId, string notes);
    }
}
