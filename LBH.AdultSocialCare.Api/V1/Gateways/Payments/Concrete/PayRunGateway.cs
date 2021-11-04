using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Concrete
{
    public class PayRunGateway : IPayRunGateway
    {
        private readonly DatabaseContext _dbContext;

        public PayRunGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payrun> GetPayRunAsync(Guid payRunId, PayRunFields fields = PayRunFields.None, bool trackChanges = false)
        {
            var query = BuildPayRunQuery(
                    _dbContext.Payruns.Where(p => p.Id == payRunId), fields)
                .TrackChanges(trackChanges);

            return await query.SingleOrDefaultAsync();
        }

        private static IQueryable<Payrun> BuildPayRunQuery(IQueryable<Payrun> query, PayRunFields fields)
        {
            if (fields.HasFlag(PayRunFields.Creator)) query = query.Include(p => p.Creator);
            if (fields.HasFlag(PayRunFields.Updater)) query = query.Include(p => p.Updater);
            if (fields.HasFlag(PayRunFields.PayrunInvoices)) query = query.Include(p => p.PayrunInvoices);

            return query;
        }
    }
}
