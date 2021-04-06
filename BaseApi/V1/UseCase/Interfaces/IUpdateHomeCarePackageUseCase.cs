using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IUpdateHomeCarePackageUseCase
    {
        public Task<HomeCarePackageDomain> UpdateAsync(HomeCarePackageDomain homeCarePackage);
    }
}
