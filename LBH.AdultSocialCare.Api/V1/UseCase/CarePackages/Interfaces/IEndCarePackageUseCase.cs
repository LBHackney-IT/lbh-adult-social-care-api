using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IEndCarePackageUseCase
    {
        Task ExecuteAsync(Guid packageId, DateTimeOffset endDate, string notes);
    }
}
