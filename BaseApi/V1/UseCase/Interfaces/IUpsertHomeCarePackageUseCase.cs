using BaseApi.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IUpsertHomeCarePackageUseCase
    {
        public Task<HomeCarePackageDomain> ExecuteAsync(HomeCarePackageDomain homeCarePackage);
    }
}
