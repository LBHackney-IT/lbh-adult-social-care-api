using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces
{
    public interface IHomeCarePackageGateway
    {
        public Task<HomeCarePackage> UpsertAsync(HomeCarePackage homeCarePackage);

        public Task<HomeCarePackage> ChangeStatusAsync(Guid homeCarePackageId, int statusId);

        public Task<HomeCarePackage> GetAsync(Guid homeCarePackageId);

        public Task<IList<HomeCarePackage>> ListAsync();
    }
}
