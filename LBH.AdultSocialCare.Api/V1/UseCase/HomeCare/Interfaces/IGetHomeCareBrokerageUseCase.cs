using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IGetHomeCareBrokerageUseCase
    {
        Task<HomeCareBrokerageResponse> Execute(Guid homeCarePackageId);
    }
}
