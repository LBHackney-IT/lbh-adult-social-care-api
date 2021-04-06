using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class DeleteStatusUseCase : IDeleteStatusUseCase
    {
        private readonly IStatusGateway _gateway;
        public DeleteStatusUseCase(IStatusGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<bool> DeleteAsync(Guid statusId)
        {
            return await _gateway.DeleteAsync(statusId).ConfigureAwait(false);
        }
    }
}
