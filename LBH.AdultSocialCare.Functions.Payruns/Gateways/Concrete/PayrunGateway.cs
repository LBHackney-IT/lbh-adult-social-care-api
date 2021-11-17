using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments;
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
