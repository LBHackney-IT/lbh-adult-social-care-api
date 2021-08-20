using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICreateSupplierCostUseCase
    {
        public Task<bool> ExecuteAsync(IEnumerable<HomeCareSupplierCostCreationDomain> homeCareSupplierCostDomains);
    }
}
