using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IArchivePayRunUseCase
    {
        Task RejectAsync(Guid payRunId);
        Task DeleteAsync(Guid payRunId, string notes);
    }
}
