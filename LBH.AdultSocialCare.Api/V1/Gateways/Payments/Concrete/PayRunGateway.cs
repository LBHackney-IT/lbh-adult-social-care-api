using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

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
            var paidStatuses = new[] { PayrunStatus.Paid, PayrunStatus.PaidWithHold };
            var heldInvoiceStatuses = new[] { InvoiceStatus.Held, InvoiceStatus.Released, InvoiceStatus.ReleaseAccepted };
            var payRunList = await _dbContext.Payruns
                .FilterPayRunList(parameters.PayRunId, parameters.PayRunType,
                    parameters.PayRunStatus, parameters.DateFrom, parameters.DateTo)
                .Select(pr => new PayRunListDomain
                {
                    PayRunId = pr.Id,
                    PayRunNumber = pr.Id.ToString().Substring(0, 6), //Todo FK: temp solution
                    PayRunTypeId = (int) pr.Type,
                    PayRunTypeName = types.Contains((int) pr.Type) ? pr.Type.ToDescription() : string.Empty,
                    PayRunStatusId = (int) pr.Status,
                    PayRunStatusName = statuses.Contains((int) pr.Status) ? pr.Status.GetDisplayName() : string.Empty,
                    TotalAmountPaid = paidStatuses.Contains(pr.Status) ? pr.PayrunInvoices.Where(pi => pi.InvoiceStatus == InvoiceStatus.Accepted).Sum(pi => pi.Invoice.GrossTotal) : pr.Paid,
                    TotalAmountHeld = pr.PayrunInvoices.Where(pi => heldInvoiceStatuses.Contains(pi.InvoiceStatus)).Sum(pi => pi.Invoice.GrossTotal),
                    DateFrom = pr.StartDate,
                    DateTo = pr.EndDate,
                    DateCreated = pr.DateCreated
                })
                .OrderBy(p => p.PayRunStatusId).ThenBy(p => p.DateCreated)
                .ToListAsync();

            payRunList = payRunList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).ToList();

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
            var completedPayRunStatuses = new[] { PayrunStatus.Archived, PayrunStatus.Paid, PayrunStatus.PaidWithHold };
            return await _dbContext.Payruns
                .Where(pr => pr.Type == payRunType && !completedPayRunStatuses.Contains(pr.Status)).AnyAsync();
        }

        public async Task<IEnumerable<Payrun>> GetPayRunsByTypeAndStatusAsync(PayrunType[] types, PayrunStatus[] statuses)
        {
            return await _dbContext.Payruns.Where(p => types.Contains(p.Type) && statuses.Contains(p.Status))
                .TrackChanges(false)
                .ToListAsync();
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

        public async Task<Payrun> GetPackageLatestPayRunAsync(Guid packageId, PayrunType[] payrunTypes, PayrunStatus[] payRunStatuses, InvoiceStatus[] invoiceStatuses)
        {
            var payrun = await _dbContext.PayrunInvoices
                .Where(pi => pi.Invoice.PackageId == packageId && invoiceStatuses.Contains(pi.InvoiceStatus) && payrunTypes.Contains(pi.Payrun.Type) && payRunStatuses.Contains(pi.Payrun.Status))
                .OrderByDescending(pi => pi.Payrun.EndDate).Select(pi => pi.Payrun).FirstOrDefaultAsync();
            return payrun;
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
