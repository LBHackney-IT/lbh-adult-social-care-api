using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IEnsureSingleActivePackageTypePerUserUseCase
    {
        Task ExecuteAsync(Guid serviceUserId, PackageType packageType, Guid? excludePackageId = null);
    }
}
