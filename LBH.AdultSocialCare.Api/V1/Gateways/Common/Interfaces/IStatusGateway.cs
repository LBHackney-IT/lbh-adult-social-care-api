using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IStatusGateway
    {
        public Task<PackageStatusOption> UpsertAsync(PackageStatusOption statusOption);

        public Task<PackageStatusOption> GetAsync(int statusId);

        public Task<IList<PackageStatusOption>> ListAsync();

        public Task<bool> DeleteAsync(int statusId);
    }
}
