using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetAllPackageUseCase : IGetAllPackageUseCase
    {
        private readonly IPackageGateway _gateway;
        public GetAllPackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<IList<Package>> GetAllAsync()
        {
            return await _gateway.ListAsync().ConfigureAwait(false);
        }
    }
}
