using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Concrete
{
    // ReSharper disable once UnusedType.Global
    public class FundedNursingCareGateway : BaseGateway, IFundedNursingCareGateway
    {
        public FundedNursingCareGateway(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<FundedNursingCarePrice>> GetFundedNursingCarePricesAsync()
        {
            // TODO: VK: Implement
            return await Task.FromResult(new List<FundedNursingCarePrice>());
        }
    }
}
