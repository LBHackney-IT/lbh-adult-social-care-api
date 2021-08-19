using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Interfaces
{
    public interface ICreateSupplierCostUseCase
    {
        public Task<bool> ExecuteAsync(IEnumerable<HomeCareSupplierCostCreationDomain> homeCareSupplierCostDomains);
    }
}
