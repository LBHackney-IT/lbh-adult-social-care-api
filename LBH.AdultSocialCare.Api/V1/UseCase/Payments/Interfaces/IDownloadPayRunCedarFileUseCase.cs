using System;
using System.IO;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IDownloadPayRunCedarFileUseCase
    {
        Task<CedarFileResponse> ExecuteAsync(Guid payRunId);
    }
}
