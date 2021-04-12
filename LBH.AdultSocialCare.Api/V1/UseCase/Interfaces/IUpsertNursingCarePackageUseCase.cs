using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertNursingCarePackageUseCase
    {
        public Task<NursingCarePackageDomain> ExecuteAsync(NursingCarePackageDomain nursingCarePackage);
    }
}
