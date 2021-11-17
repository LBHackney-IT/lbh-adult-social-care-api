using Common.Exceptions.CustomExceptions;
using Common.Exceptions.Models;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUsersGateway _gateway;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterUserUseCase(IUsersGateway usersGateway, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _gateway = usersGateway;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<AppUserResponse> RegisterUserAsync(UserForRegistrationDomain user)
        {
            var userEntity = user.ToEntity();
            var result = await _userManager.CreateAsync(userEntity, user.Password).ConfigureAwait(false);

            if (result.Succeeded)
            {
                var defaultRoles = new List<string> { RolesEnum.User.GetDisplayName() };
                var newUserRoles = new List<string>();
                foreach (var userRole in defaultRoles)
                {
                    if (await _roleManager.RoleExistsAsync(userRole).ConfigureAwait(false))
                    {
                        newUserRoles.Add(userRole);
                    }
                }

                if (newUserRoles.Count > 0)
                {
                    await _userManager.AddToRolesAsync(userEntity, newUserRoles).ConfigureAwait(false);
                }

                var domain = userEntity?.ToDomain();
                return domain?.ToResponse();
            }

            var validationErrorCollection = new ValidationErrorCollection();

            foreach (var error in result.Errors)
            {
                validationErrorCollection.Add(new ValidationError
                {
                    Message = error.Description,
                    ControlID = error.Code,
                    ID = error.Code
                });
            }

            throw new ApiException($"User creation failed", (int) StatusCodes.Status400BadRequest, validationErrorCollection);
        }
    }
}
