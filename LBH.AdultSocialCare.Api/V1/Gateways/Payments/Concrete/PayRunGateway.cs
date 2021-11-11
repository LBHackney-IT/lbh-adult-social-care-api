using Common.AppConstants.Enums;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
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

        public async Task<PagedList<PayRunListDomain>> GetPayRunList(PayRunListParameters parameters)
        {
            var types = Enum.GetValues(typeof(PayrunType)).OfType<PayrunType>().Select(x => (int) x).ToArray();
            var statuses = Enum.GetValues(typeof(PayrunStatus)).OfType<PayrunStatus>().Select(x => (int) x).ToArray();
            var payRunList = await _dbContext.Payruns
                .FilterPayRunList(parameters.PayRunId, parameters.PayRunType,
                    parameters.PayRunStatus, parameters.DateFrom, parameters.DateTo)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .Select(pr => new PayRunListDomain
                {
                    PayRunId = pr.Id,
                    PayRunNumber = pr.Id.ToString().Substring(0, 6), //Todo FK: temp solution
                    PayRunTypeId = (int) pr.Type,
                    PayRunTypeName = types.Contains((int) pr.Type) ? pr.Type.ToDescription() : string.Empty,
                    PayRunStatusId = (int) pr.Status,
                    PayRunStatusName = statuses.Contains((int) pr.Status) ? pr.Status.GetDisplayName() : string.Empty,
                    TotalAmountPaid = pr.Paid,
                    TotalAmountHeld = pr.Held,
                    DateFrom = pr.StartDate,
                    DateTo = pr.EndDate,
                    DateCreated = pr.DateCreated
                }).ToListAsync();

            var payRunCount = await _dbContext.Payruns
                .FilterPayRunList(parameters.PayRunId, parameters.PayRunType,
                    parameters.PayRunStatus, parameters.DateFrom, parameters.DateTo)
                .CountAsync();

            return PagedList<PayRunListDomain>.ToPagedList(payRunList, payRunCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task CreateDraftPayRun(Payrun payRun)
        {
            await _dbContext.Payruns.AddAsync(payRun);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not create pay run");
            }
        }

        public async Task<int> GetDraftPayRunCount(PayrunType payRunType)
        {
            return await _dbContext.Payruns.Where(pr =>
                    pr.Type.Equals(payRunType) &&
                    pr.Status == PayrunStatus.Draft)
                .CountAsync();
        }

        public async Task<bool> CheckExistsUnApprovedPayRunAsync(PayrunType payRunType)
        {
            var approvedPayRunStatuses = new[] { PayrunStatus.Approved, PayrunStatus.Paid, PayrunStatus.PaidWithHold };
            return await _dbContext.Payruns
                .Where(pr => pr.Type == payRunType && !approvedPayRunStatuses.Contains(pr.Status)).AnyAsync();
        }

        public async Task<DateTimeOffset> GetEndDateOfLastPayRun(PayrunType payRunType)
        {
            var lastPayRun = await _dbContext.Payruns.Where(pr =>
                    pr.Type.Equals(payRunType))
                .OrderByDescending(pr => pr.PaidUpToDate)
                .FirstOrDefaultAsync();

            return lastPayRun?.PaidUpToDate ?? DateTimeOffset.Now.AddDays(-28);
        }

        public async Task<Payrun> GetPreviousPayRunAsync(PayrunType payRunType)
        {
            var previousPayRun = await _dbContext.Payruns.Where(pr => pr.Type.Equals(payRunType)).TrackChanges(false)
                .OrderByDescending(pr => pr.DateCreated)
                .Skip(1)
                .FirstOrDefaultAsync();
            return previousPayRun;
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
