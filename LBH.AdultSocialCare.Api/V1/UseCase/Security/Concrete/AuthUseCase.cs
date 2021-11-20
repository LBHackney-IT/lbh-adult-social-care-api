using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.Services.Auth;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Extensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
{
    public class AuthUseCase : IAuthUseCase
    {
        private readonly IAuthenticationManager _authManager;
        private readonly IUserRolesGateway _userRolesGateway;
        private readonly IDatabaseManager _dbManager;

        public AuthUseCase(IAuthenticationManager authManager, IUserRolesGateway userRolesGateway, IDatabaseManager dbManager)
        {
            _authManager = authManager;
            _userRolesGateway = userRolesGateway;
            _dbManager = dbManager;
        }

        public async Task<bool> AssignRolesToUserUseCase(AssignRolesToUserDomain assignRolesToUserDomain)
        {
            var res = await _authManager
                .AssignRolesToUser(assignRolesToUserDomain.UserId, assignRolesToUserDomain.Roles).ConfigureAwait(false);

            return res;
        }

        public async Task<TokenResponse> GoogleAuthenticateUseCase(string hackneyToken)
        {
            var validToken = _authManager.ValidateHackneyJwtToken(hackneyToken);

            // Check if user exists. Not? Create
            var userDomain = await _authManager.GetOrCreateUser(validToken).ConfigureAwait(false);

            // Create token and return to  user
            if (!await _authManager.ValidateUser(userDomain.Email).ConfigureAwait(false))
            {
                throw new ApiException("Authentication failed. Invalid token.", (int) HttpStatusCode.Unauthorized);
            }

            var user = _authManager.GetUser();

            // Get roles from user groups
            var currentRolesList = GetCurrentUserRoles(validToken.Groups);
            var currentRoleIds = currentRolesList.Select(r => r.GetId()).ToList();

            // Get active roles and determine ones to add or remove
            var activeUserRoles = await _userRolesGateway.GetUserRolesAsync(user.Id, true);
            var rolesToAdd = currentRolesList.Select(r => r.GetDisplayName());
            var rolesToRemove = activeUserRoles.Where(activeUserRole => !currentRoleIds.Contains(activeUserRole.RoleId)).ToList();

            // Remove roles
            _userRolesGateway.RemoveUserRoles(rolesToRemove);
            await _dbManager.SaveAsync();

            // Add new roles
            await _authManager.AssignRolesToUser(user.Id, rolesToAdd);

            // Return response with token
            var res = new TokenResponse
            {
                UserId = user.Id,
                Name = user.Name,
                Token = await _authManager.CreateToken().ConfigureAwait(false),
                Groups = validToken.Groups,
                Roles = currentRolesList.Select(r => r.GetDisplayName())
            };

            return res;
        }

        private static List<RolesEnum> GetCurrentUserRoles(IEnumerable<string> currentUserGroups)
        {
            var rolesList = new List<RolesEnum>();
            foreach (var currentUserGroup in currentUserGroups)
            {
                switch (currentUserGroup)
                {
                    case "saml-socialcarefinance-brokerage":
                        rolesList.Add(RolesEnum.Broker);
                        break;
                    case "saml-socialcarefinance-approvers":
                        rolesList.Add(RolesEnum.BrokerageApprover);
                        break;
                    case "saml-socialcarefinance-care-charge":
                    case "saml-socialcarefinance-carecharges":
                        rolesList.Add(RolesEnum.CareChargeManager);
                        break;
                    case "saml-socialcarefinance-finance":
                        rolesList.Add(RolesEnum.Finance);
                        break;
                    case "saml-socialcarefinance-finance-approver":
                        rolesList.Add(RolesEnum.FinanceApprover);
                        break;
                }
            }

            return rolesList.Distinct().ToList();
        }
    }
}
