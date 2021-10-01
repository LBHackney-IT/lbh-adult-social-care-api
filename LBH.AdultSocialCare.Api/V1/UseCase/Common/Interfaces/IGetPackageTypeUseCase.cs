using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetPackageTypeUseCase
    {
        public Task<IList<Package>> GetAllAsync();

        public Task<PackageTypeDomain> GetSingleAsync(int packageTypeId);
    }
}
