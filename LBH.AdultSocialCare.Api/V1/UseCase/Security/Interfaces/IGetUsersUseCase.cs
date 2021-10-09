using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IGetUsersUseCase
    {
        public Task<AppUserResponse> GetAsync(Guid userId);

        public Task<PagedResponse<AppUserResponse>> GetUsersWithRoles(List<string> roles,
            AppUserListQueryParameters queryParams);
    }
}
