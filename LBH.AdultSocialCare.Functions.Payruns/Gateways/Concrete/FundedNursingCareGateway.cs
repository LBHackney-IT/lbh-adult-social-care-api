using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common;

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
            return await Task.FromResult(new List<FundedNursingCarePrice>());
        }
    }
}
