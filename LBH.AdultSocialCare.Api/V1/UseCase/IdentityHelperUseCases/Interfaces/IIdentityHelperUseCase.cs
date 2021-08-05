using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Interfaces
{
    public interface IIdentityHelperUseCase
    {
        Guid GetUserId();

        Guid GetUserName();
    }
}
