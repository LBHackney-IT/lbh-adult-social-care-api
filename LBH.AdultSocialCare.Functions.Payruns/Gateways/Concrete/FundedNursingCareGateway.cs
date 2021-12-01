using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return await DbContext.FundedNursingCarePrices.ToListAsync();
        }
    }
}
