using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface ICreateHomeCareBrokerageUseCase
    {
        public Task<HomeCareBrokerageResponse> ExecuteAsync(Guid homeCarePackageId, HomeCareBrokerageCreationDomain homeCareBrokerageCreationDomain);
    }
}
