using LBH.AdultSocialCare.Api.V1.Domain;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Security;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IRegisterUserUseCase
    {
        public Task<UsersResponse> RegisterUserAsync(UserForRegistrationDomain user);
    }
}
