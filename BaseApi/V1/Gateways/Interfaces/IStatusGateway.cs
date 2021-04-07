using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways.Interfaces
{
    public interface IStatusGateway
    {
        public Task<Status> UpsertAsync(Status status);

        public Task<Status> GetAsync(Guid statusId);

        public Task<IList<Status>> ListAsync();

        public Task<bool> DeleteAsync(Guid statusId);
    }
}
