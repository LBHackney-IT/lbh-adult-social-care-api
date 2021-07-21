using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.BrokeredPackagesUseCases.Interfaces
{
    public interface IAssignToUserUseCase
    {
        Task<bool> AssignToUser(Guid packageId, Guid userId);
    }
}
