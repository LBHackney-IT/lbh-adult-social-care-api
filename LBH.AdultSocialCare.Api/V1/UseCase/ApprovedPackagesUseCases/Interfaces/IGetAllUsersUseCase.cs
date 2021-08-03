using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ApprovedPackagesBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Interfaces
{
    public interface IGetAllUsersUseCase
    {
        Task<IEnumerable<UsersMinimalResponse>> GetUsers(int roleId);
        
        Task<IEnumerable<UsersMinimalResponse>> GetUsers(string role);
    }
}
