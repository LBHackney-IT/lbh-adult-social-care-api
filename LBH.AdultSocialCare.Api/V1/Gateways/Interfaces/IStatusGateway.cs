using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IStatusGateway
    {
        public Task<PackageStatus> UpsertAsync(PackageStatus status);

        public Task<PackageStatus> GetAsync(int statusId);

        public Task<IList<PackageStatus>> ListAsync();

        public Task<bool> DeleteAsync(int statusId);
    }
}
