using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IEditCareChargeElementUseCase
    {
        Task<bool> ExecuteAsync(Guid packageCareChargeId, IEnumerable<CareChargeElementForUpdateDomain> careChargeElementsForUpdate);
    }
}
