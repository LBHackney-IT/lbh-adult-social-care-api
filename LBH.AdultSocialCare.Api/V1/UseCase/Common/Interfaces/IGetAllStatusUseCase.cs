using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetAllStatusUseCase
    {
        public Task<IList<PackageStatusOption>> GetAllAsync();
    }
}
