using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IApprovePayRunUseCase
    {
        Task ExecuteAsync(Guid payRunId, string notes);
    }
}
