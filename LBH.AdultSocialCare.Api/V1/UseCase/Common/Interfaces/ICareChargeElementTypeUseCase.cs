using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICareChargeElementTypeUseCase
    {
        Task<IEnumerable<CareChargeElementTypePlainResponse>> GetAllAsync();
    }
}
