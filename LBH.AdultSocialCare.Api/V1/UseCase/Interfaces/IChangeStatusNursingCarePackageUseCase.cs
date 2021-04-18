using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IChangeStatusNursingCarePackageUseCase
    {
        public Task<NursingCarePackageDomain> UpdateAsync(Guid nursingCarePackageId, int statusId);
    }
}
