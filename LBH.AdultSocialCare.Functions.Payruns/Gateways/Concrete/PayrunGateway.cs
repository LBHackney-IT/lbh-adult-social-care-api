using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Concrete
{
    // ReSharper disable once UnusedType.Global
    public class PayrunGateway : BaseGateway, IPayrunGateway
    {
        public PayrunGateway(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Payrun>> GetDraftPayrunsAsync()
        {
            return await DbContext.Payruns
                .Where(p => p.Status == PayrunStatus.Draft)
                .ToListAsync();
        }
    }
}
