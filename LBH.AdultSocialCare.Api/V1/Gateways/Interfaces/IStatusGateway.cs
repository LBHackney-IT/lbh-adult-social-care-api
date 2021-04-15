using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IStatusGateway
    {
        public Task<PackageStatus> UpsertAsync(PackageStatus status);

        public Task<PackageStatus> GetAsync(Guid statusId);

        public Task<IList<PackageStatus>> ListAsync();

        public Task<bool> DeleteAsync(Guid statusId);
    }
}
