using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetAllStatusUseCase
    {
        public Task<IList<PackageStatusOption>> GetAllAsync();
    }
}
