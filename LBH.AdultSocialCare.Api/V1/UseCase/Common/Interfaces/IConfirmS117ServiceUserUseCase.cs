using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IConfirmS117ServiceUserUseCase
    {
        Task ExecuteAsync(Guid packageId);
    }
}
