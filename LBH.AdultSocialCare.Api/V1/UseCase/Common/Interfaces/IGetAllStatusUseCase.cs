using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetAllStatusUseCase
    {
        public Task<IList<PackageStatus>> GetAllAsync();
    }
}