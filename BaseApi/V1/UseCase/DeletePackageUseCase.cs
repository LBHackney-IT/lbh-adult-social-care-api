using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class DeletePackageUseCase : IDeletePackageUseCase
    {
        private readonly IPackageGateway _gateway;
        public DeletePackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<bool> DeleteAsync(Guid packageId)
        {
            return await _gateway.DeleteAsync(packageId).ConfigureAwait(false);
        }
    }
}
