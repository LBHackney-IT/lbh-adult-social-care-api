using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IEnsureSingleActivePackageTypePerUserUseCase
    {
        Task ExecuteAsync(Guid serviceUserId, PackageType packageType, Guid? excludePackageId = null);
    }
}
