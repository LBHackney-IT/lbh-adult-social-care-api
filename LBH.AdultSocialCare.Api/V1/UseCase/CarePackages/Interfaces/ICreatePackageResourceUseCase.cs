using LBH.AdultSocialCare.Data.Constants.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICreatePackageResourceUseCase
    {
        Task<Guid> CreateFileAsync(Guid carePackageId, PackageResourceType type, IFormFile file);
    }
}
