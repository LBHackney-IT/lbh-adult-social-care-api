using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;

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

        public async Task<PagedList<PayRunListDomain>> GetPayRunList(PayRunListParameters parameters)
        {
            var payRunList = await _dbContext.Payruns
                .FilterPayRunList(parameters.PayRunId, parameters.PayRunType,
                    parameters.PayRunStatus, parameters.DateFrom, parameters.DateTo)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .Select(pr => new PayRunListDomain
                {
                    PayRunId = pr.Id,
                    PayRunTypeId = (int) pr.Type,
                    PayRunTypeName = pr.Type.ToDescription(),
                    PayRunStatusId = (int) pr.Status,
                    PayRunStatusName = pr.Status.GetDisplayName(),
                    TotalAmountPaid = pr.Paid,
                    TotalAmountHeld = pr.Held,
                    DateFrom = pr.StartDate,
                    DateTo = pr.EndDate,
                    DateCreated = pr.DateCreated
                }).ToListAsync().ConfigureAwait(false);

            var payRunCount = await _dbContext.Payruns
                .FilterPayRunList(parameters.PayRunId, parameters.PayRunType,
                    parameters.PayRunStatus, parameters.DateFrom, parameters.DateTo)
                .CountAsync().ConfigureAwait(false);

            return PagedList<PayRunListDomain>.ToPagedList(payRunList, payRunCount, parameters.PageNumber, parameters.PageSize);
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
