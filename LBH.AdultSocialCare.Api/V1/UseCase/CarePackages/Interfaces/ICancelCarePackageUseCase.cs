using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICancelCarePackageUseCase
    {
        Task ExecuteAsync(Guid packageId, string notes);
    }
}
