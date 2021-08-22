using System;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IIdentityHelperUseCase
    {
        Guid GetUserId();

        Guid GetUserName();
    }
}
