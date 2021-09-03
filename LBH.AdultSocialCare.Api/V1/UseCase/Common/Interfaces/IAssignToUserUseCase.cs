using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IAssignToUserUseCase
    {
        Task<bool> AssignToUser(Guid packageId, Guid userId);
    }
}
