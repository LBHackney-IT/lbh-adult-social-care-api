using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICreateCareChargeElementUseCase
    {
        Task<IEnumerable<CareChargeElementPlainDomain>> ExecuteAsync(IEnumerable<CareChargeElementPlainDomain> elements);
    }
}
