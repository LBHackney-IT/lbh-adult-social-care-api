using System;
using System.IO;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IDownloadPayRunCedarFileUseCase
    {
        Task<MemoryStream> ExecuteAsync(Guid payRunId);
    }
}
