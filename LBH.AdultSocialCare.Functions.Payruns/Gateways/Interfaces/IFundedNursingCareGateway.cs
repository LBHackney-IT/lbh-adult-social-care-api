using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces
{
    public interface IFundedNursingCareGateway
    {
        Task<IList<FundedNursingCarePrice>> GetFundedNursingCarePricesAsync();
    }
}
