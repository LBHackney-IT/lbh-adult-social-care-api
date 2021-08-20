using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IGetAllHomeCarePackageUseCase
    {
        public Task<IList<HomeCarePackage>> GetAllAsync();
    }
}
