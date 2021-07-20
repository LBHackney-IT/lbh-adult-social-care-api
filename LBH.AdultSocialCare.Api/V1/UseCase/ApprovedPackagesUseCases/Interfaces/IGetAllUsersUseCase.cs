using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ApprovedPackagesBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Interfaces
{
    public interface IGetAllUsersUseCase
    {
        Task<IEnumerable<UsersMinimalResponse>> GetUsers(int roleId);
    }
}
