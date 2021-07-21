using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.PrimarySupportReasonBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PrimarySupportReasonUseCase.Interfaces
{
    public interface IGetAllPrimarySupportReasonsUseCase
    {
        Task<IEnumerable<PrimarySupportReasonResponse>> GetAllAsync();
    }
}
