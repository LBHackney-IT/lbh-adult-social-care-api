using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using LBH.AdultSocialCare.Api.Configuration;
using Microsoft.Extensions.Options;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Concrete
{
    public class PayRunInvoiceGateway : IPayRunInvoiceGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly RuntimeConfiguration _runtimeConfig;

        public PayRunInvoiceGateway(DatabaseContext dbContext, IOptions<RuntimeConfiguration> runtimeConfig)
        {
            _dbContext = dbContext;
            _runtimeConfig = runtimeConfig.Value;
        }

        public async Task<PagedList<PayrunInvoice>> GetPayRunInvoicesAsync(Guid payRunId, RequestParameters parameters, InvoiceStatus[] statuses, PayRunInvoiceFields fields = PayRunInvoiceFields.None,
            bool trackChanges = false)
        {
            var query = _dbContext.PayrunInvoices.Where(p => p.PayrunId == payRunId && statuses.Contains(p.InvoiceStatus))
                .TrackChanges(trackChanges);

            var payRunInvoices = await BuildPayRunInvoiceQuery(query, fields)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var invoiceCount = await query.CountAsync();
            return PagedList<PayrunInvoice>.ToPagedList(payRunInvoices, invoiceCount, parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<IList<PayrunInvoice>> GetPackageInvoicesAsync(Guid packageId, PayrunStatus[] payRunStatuses, InvoiceStatus[] invoiceStatuses,
            PayRunInvoiceFields fields = PayRunInvoiceFields.None, bool trackChanges = false)
        {
            var query = _dbContext.PayrunInvoices.Where(p => p.Invoice.PackageId == packageId && payRunStatuses.Contains(p.Payrun.Status) && invoiceStatuses.Contains(p.InvoiceStatus))
                .TrackChanges(trackChanges);

            return await BuildPayRunInvoiceQuery(query, fields)
                .OrderByDescending(pi => pi.DateCreated)
                .ToListAsync();
        }

        public async Task<PayRunInsightsDomain> GetPayRunInsightsAsync(Guid payRunId)
        {
            var invoices = await _dbContext.PayrunInvoices.Where(p => p.PayrunId == payRunId).Include(pi => pi.Invoice)
                .ToListAsync();

            var isCedarDownloaded = await _dbContext.PayrunHistories.Where(ph => ph.PayRunId.Equals(payRunId))
                .AnyAsync(ph => ph.Type == PayRunHistoryType.CedarFileDownload);

            var paidLog = await _dbContext.PayrunHistories.Include(ph => ph.Creator).FirstOrDefaultAsync(ph => ph.PayRunId.Equals(payRunId) && ph.Type == PayRunHistoryType.PaidPayrun);

            var heldInvoiceStatuses =
                new[] { InvoiceStatus.Held, InvoiceStatus.Released, InvoiceStatus.ReleaseAccepted };

            var result = new PayRunInsightsDomain
            {
                TotalInvoiceAmount = invoices.Where(x => x.InvoiceStatus == InvoiceStatus.Accepted).Sum(i => i.Invoice.GrossTotal),
                SupplierCount = invoices.Where(x => x.InvoiceStatus == InvoiceStatus.Accepted).Select(i => i.Invoice.SupplierId).Distinct().Count(),
                ServiceUserCount = invoices.Where(x => x.InvoiceStatus == InvoiceStatus.Accepted).Select(i => i.Invoice.ServiceUserId).Distinct().Count(),
                HoldsCount = invoices.Count(i => heldInvoiceStatuses.Contains(i.InvoiceStatus)),
                TotalHeldAmount = invoices.Where(i => heldInvoiceStatuses.Contains(i.InvoiceStatus))
                    .Sum(i => i.Invoice.GrossTotal),
                IsCedarFileDownloaded = isCedarDownloaded,
                PaidBy = paidLog?.Creator.Name,
                PaidOn = paidLog?.DateCreated
            };

            return result;
        }

        public async Task<PagedList<PayRunInvoiceDomain>> GetPayRunInvoicesSummaryAsync(Guid payRunId,
            PayRunDetailsQueryParameters parameters)
        {
            var query = _dbContext.PayrunInvoices.Where(p => p.PayrunId == payRunId)
                .FilterPayRunInvoices(_runtimeConfig, parameters)
                .TrackChanges(false);

            var payRunInvoices = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .Select(payRunInvoice => new PayRunInvoiceDomain
                {
                    Id = payRunInvoice.Id,
                    InvoiceId = payRunInvoice.InvoiceId,
                    CarePackageId = payRunInvoice.Invoice.PackageId,
                    ServiceUserId = payRunInvoice.Invoice.ServiceUserId,
                    ServiceUserName =
                    $"{payRunInvoice.Invoice.ServiceUser.FirstName} {payRunInvoice.Invoice.ServiceUser.MiddleName ?? string.Empty} {payRunInvoice.Invoice.ServiceUser.LastName}",
                    SupplierId = payRunInvoice.Invoice.Supplier.CedarId ?? payRunInvoice.Invoice.SupplierId,
                    SupplierName = payRunInvoice.Invoice.Supplier.SupplierName,
                    InvoiceNumber = payRunInvoice.Invoice.Number,
                    PackageType = payRunInvoice.Invoice.Package.PackageType,
                    NetTotal = payRunInvoice.Invoice.NetTotal,
                    GrossTotal = payRunInvoice.Invoice.GrossTotal,
                    InvoiceStatus = payRunInvoice.InvoiceStatus,
                    AssignedBrokerName = payRunInvoice.Invoice.Package.Broker.Name,
                    InvoiceItems = payRunInvoice.Invoice.Items.Select(ii => new PayRunInvoiceItemDomain
                    {
                        Id = ii.Id,
                        Name = ii.Name,
                        FromDate = ii.FromDate,
                        ToDate = ii.ToDate,
                        Cost = ii.WeeklyCost,
                        Quantity = ii.Quantity,
                        TotalCost = ii.TotalCost,
                        ClaimCollector = ii.ClaimCollector,
                        PriceEffect = ii.PriceEffect
                    })
                }).ToListAsync();

            var invoiceCount = await query.CountAsync();
            return PagedList<PayRunInvoiceDomain>.ToPagedList(payRunInvoices, invoiceCount, parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<PagedList<HeldInvoiceDetailsDomain>> GetHeldInvoicesAsync(
            PayRunDetailsQueryParameters parameters)
        {
            parameters.InvoiceStatus = InvoiceStatus.Held;
            var query = _dbContext.PayrunInvoices
                .Where(pr => pr.Payrun.Status != PayrunStatus.Archived)
                .FilterPayRunInvoices(_runtimeConfig, parameters)
                .TrackChanges(false);

            var heldInvoices = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .OrderBy(pi => pi.Payrun.DateCreated)
                .Select(pi => new HeldInvoiceDetailsDomain
                {
                    PayRunId = pi.PayrunId,
                    PayRunNumber = pi.Payrun.Number,
                    DateCreated = pi.DateCreated,
                    StartDate = pi.Payrun.StartDate,
                    EndDate = pi.Payrun.EndDate,
                    PayRunInvoice = new PayRunInvoiceDomain
                    {
                        Id = pi.Id,
                        InvoiceId = pi.InvoiceId,
                        CarePackageId = pi.Invoice.PackageId,
                        ServiceUserId = pi.Invoice.ServiceUserId,
                        ServiceUserName =
                        $"{pi.Invoice.ServiceUser.FirstName} {pi.Invoice.ServiceUser.MiddleName ?? string.Empty} {pi.Invoice.ServiceUser.LastName}",
                        SupplierId = pi.Invoice.Supplier.CedarId ?? pi.Invoice.SupplierId,
                        SupplierName = pi.Invoice.Supplier.SupplierName,
                        InvoiceNumber = pi.Invoice.Number,
                        PackageType = pi.Invoice.Package.PackageType,
                        NetTotal = pi.Invoice.NetTotal,
                        GrossTotal = pi.Invoice.GrossTotal,
                        InvoiceStatus = pi.InvoiceStatus,
                        AssignedBrokerName = pi.Invoice.Package.Broker.Name,
                        InvoiceItems = pi.Invoice.Items.Select(ii => new PayRunInvoiceItemDomain
                        {
                            Id = ii.Id,
                            Name = ii.Name,
                            FromDate = ii.FromDate,
                            ToDate = ii.ToDate,
                            Cost = ii.WeeklyCost,
                            Quantity = ii.Quantity,
                            TotalCost = ii.TotalCost,
                            ClaimCollector = ii.ClaimCollector,
                            PriceEffect = ii.PriceEffect
                        })
                    }
                }).ToListAsync();

            var heldInvoiceCount = await query.CountAsync();
            return PagedList<HeldInvoiceDetailsDomain>.ToPagedList(heldInvoices, heldInvoiceCount, parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<PayRunInvoiceDomain> GetPayRunInvoiceDetailAsync(Guid payRunId, Guid invoiceId, bool trackChanges = false)
        {
            var result = await _dbContext.PayrunInvoices.Where(pi => pi.PayrunId == payRunId && pi.InvoiceId == invoiceId)
                .TrackChanges(trackChanges).Select(payRunInvoice => new PayRunInvoiceDomain
                {
                    Id = payRunInvoice.Id,
                    InvoiceId = payRunInvoice.InvoiceId,
                    CarePackageId = payRunInvoice.Invoice.PackageId,
                    ServiceUserId = payRunInvoice.Invoice.ServiceUserId,
                    ServiceUserName =
                    $"{payRunInvoice.Invoice.ServiceUser.FirstName} {payRunInvoice.Invoice.ServiceUser.MiddleName ?? string.Empty} {payRunInvoice.Invoice.ServiceUser.LastName}",
                    SupplierId = payRunInvoice.Invoice.Supplier.CedarId ?? payRunInvoice.Invoice.SupplierId,
                    SupplierName = payRunInvoice.Invoice.Supplier.SupplierName,
                    InvoiceNumber = payRunInvoice.Invoice.Number,
                    PackageType = payRunInvoice.Invoice.Package.PackageType,
                    InvoiceStatus = payRunInvoice.InvoiceStatus,
                    AssignedBrokerName = payRunInvoice.Invoice.Package.Broker.Name,
                    NetTotal = payRunInvoice.Invoice.NetTotal,
                    GrossTotal = payRunInvoice.Invoice.GrossTotal,
                    InvoiceItems = payRunInvoice.Invoice.Items.Select(ii => new PayRunInvoiceItemDomain
                    {
                        Id = ii.Id,
                        Name = ii.Name,
                        FromDate = ii.FromDate,
                        ToDate = ii.ToDate,
                        Cost = ii.WeeklyCost,
                        Quantity = ii.Quantity,
                        TotalCost = ii.TotalCost,
                        ClaimCollector = ii.ClaimCollector,
                        PriceEffect = ii.PriceEffect
                    })
                }).SingleOrDefaultAsync();
            return result;
        }

        public async Task<PayrunInvoice> GetPayRunInvoiceAsync(Guid payRunInvoiceId, PayRunInvoiceFields fields = PayRunInvoiceFields.None,
            bool trackChanges = false)
        {
            var query = _dbContext.PayrunInvoices.Where(p => p.Id.Equals(payRunInvoiceId))
                .TrackChanges(trackChanges);

            return await BuildPayRunInvoiceQuery(query, fields).SingleOrDefaultAsync();
        }

        public async Task<decimal> GetPayRunInvoicedTotalAsync(Guid payRunId)
        {
            var result = await _dbContext.PayrunInvoices.Where(pi => pi.PayrunId == payRunId).TrackChanges(false)
                .SumAsync(pi => pi.Invoice.GrossTotal);
            return decimal.Round(result, 2);
        }

        public async Task<int> GetReleasedInvoiceCountAsync()
        {
            return await _dbContext.PayrunInvoices.Where(pi => pi.InvoiceStatus == InvoiceStatus.Released && pi.Payrun.Status != PayrunStatus.Archived).CountAsync();
        }

        private static IQueryable<PayrunInvoice> BuildPayRunInvoiceQuery(IQueryable<PayrunInvoice> query, PayRunInvoiceFields fields)
        {
            if (fields.HasFlag(PayRunInvoiceFields.Creator)) query = query.Include(p => p.Creator);
            if (fields.HasFlag(PayRunInvoiceFields.Updater)) query = query.Include(p => p.Updater);
            if (fields.HasFlag(PayRunInvoiceFields.Payrun)) query = query.Include(p => p.Payrun);
            if (fields.HasFlag(PayRunInvoiceFields.Invoice)) query = query.Include(p => p.Invoice);
            if (fields.HasFlag(PayRunInvoiceFields.InvoiceItems)) query = query.Include(p => p.Invoice).ThenInclude(i => i.Items);
            if (fields.HasFlag(PayRunInvoiceFields.Package)) query = query.Include(p => p.Invoice).ThenInclude(i => i.Package);
            if (fields.HasFlag(PayRunInvoiceFields.Supplier)) query = query.Include(p => p.Invoice).ThenInclude(i => i.Supplier);
            if (fields.HasFlag(PayRunInvoiceFields.ServiceUser)) query = query.Include(p => p.Invoice).ThenInclude(i => i.ServiceUser);

            return query;
        }
    }
}
