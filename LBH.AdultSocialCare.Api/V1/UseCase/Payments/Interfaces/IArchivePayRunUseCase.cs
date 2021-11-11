using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IArchivePayRunUseCase
    {
        Task ExecuteAsync(Guid payRunId, string notes);
    }
}