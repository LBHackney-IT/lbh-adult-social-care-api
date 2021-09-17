using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICareChargeElementTypeGateway
    {
        Task<IEnumerable<CareChargeElementTypePlainDomain>> GetAllAsync();
    }
}
