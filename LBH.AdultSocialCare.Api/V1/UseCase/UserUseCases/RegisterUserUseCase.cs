using Common.Exceptions.CustomExceptions;
using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.UserDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.UserUseCases
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUsersGateway _gateway;
        private readonly UserManager<User> _userManager;

        public RegisterUserUseCase(IUsersGateway usersGateway, UserManager<User> userManager)
        {
            _gateway = usersGateway;
            _userManager = userManager;
        }

        public async Task<UsersResponse> RegisterUserAsync(UserForRegistrationDomain user)
        {
            var userEntity = user.ToEntity();
            var result = await _userManager.CreateAsync(userEntity, user.Password).ConfigureAwait(false);

            if (result.Succeeded)
            {
                var domain = userEntity?.ToDomain();
                return domain?.ToResponse();
            }

            var errors = result.Errors.Select(e => e.Description).ToList();

            var validationErrors = errors.Select((error, index) => new ValidationError
            {
                Message = error,
                ControlID = index.ToString(),
                ID = index.ToString()
            });

            var validationErrorCollection = new ValidationErrorCollection();

            foreach (var validationError in validationErrors)
            {
                validationErrorCollection.Add(validationError);
            }

            throw new ApiException($"User creation failed", (int) StatusCodes.Status400BadRequest, validationErrorCollection);
        }
    }
}
