using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
{
    public class GetUsersUseCase : IGetUsersUseCase
    {
        private readonly IUsersGateway _gateway;

        public GetUsersUseCase(IUsersGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<AppUserResponse> GetAsync(Guid userId)
        {
            var usersEntity = await _gateway.GetAsync(userId).ConfigureAwait(false);
            return usersEntity?.ToResponse();
        }

        public async Task<PagedResponse<AppUserResponse>> GetUsersWithRoles(List<string> roles,
            AppUserListQueryParameters queryParams)
        {
            var allRoles = Enum.GetValues(typeof(RolesEnum))
                .OfType<RolesEnum>()
                .Select(x =>
                    new Role()
                    {
                        Id = x.GetId(),
                        Name = x.GetDisplayName()
                    })
                .ToArray();

            List<Guid> validRolesFromRequest;

            if (roles != null && roles.Count != 0)
            {
                validRolesFromRequest =
                    (from role in roles
                     select allRoles.FirstOrDefault(r => r.Name.ToLower().Equals(role.ToLower()))
                        into val
                     where val != null
                     select val.Id).ToList();
            }
            else
            {
                validRolesFromRequest = allRoles.Select(r => r.Id).ToList();
            }

            var usersWithRoles = await _gateway.GetUsersWithRoles(validRolesFromRequest.ToArray(), queryParams);
            var response = new PagedResponse<AppUserResponse>
            {
                PagingMetaData = usersWithRoles.PagingMetaData,
                Data = usersWithRoles.ToResponse()
            };

            return response;
        }
    }
}
