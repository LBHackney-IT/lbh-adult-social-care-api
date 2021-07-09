using LBH.AdultSocialCare.Api.V1.Domain.RoleDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.AuthUseCases.Interfaces
{
    public interface IAuthUseCase
    {
        Task<bool> AssignRolesToUserUseCase(AssignRolesToUserDomain assignRolesToUserDomain);
    }
}
