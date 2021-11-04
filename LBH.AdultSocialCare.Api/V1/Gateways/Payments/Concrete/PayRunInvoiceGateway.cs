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
    public class PayRunInvoiceGateway : IPayRunInvoiceGateway
    {
        private readonly DatabaseContext _dbContext;

        public PayRunInvoiceGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<PayrunInvoice>> GetPayRunInvoicesAsync(Guid payRunId, PayRunDetailsQueryParameters parameters, PayRunInvoiceFields fields = PayRunInvoiceFields.None,
            bool trackChanges = false)
        {
            var query = _dbContext.PayrunInvoices.Where(p => p.PayrunId == payRunId)
                .FilterPayRunInvoices(parameters)
                .TrackChanges(trackChanges);

            var payRunInvoices = await BuildPayRunInvoiceQuery(query, fields)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var invoiceCount = await query.CountAsync();
            return PagedList<PayrunInvoice>.ToPagedList(payRunInvoices, invoiceCount, parameters.PageNumber,
                parameters.PageSize);
        }

        private static IQueryable<PayrunInvoice> BuildPayRunInvoiceQuery(IQueryable<PayrunInvoice> query, PayRunInvoiceFields fields)
        {
            if (fields.HasFlag(PayRunInvoiceFields.Creator)) query = query.Include(p => p.Creator);
            if (fields.HasFlag(PayRunInvoiceFields.Updater)) query = query.Include(p => p.Updater);
            if (fields.HasFlag(PayRunInvoiceFields.Invoice)) query = query.Include(p => p.Invoice).ThenInclude(i => i.Items);
            if (fields.HasFlag(PayRunInvoiceFields.Payrun)) query = query.Include(p => p.Payrun);

            return query;
        }
    }
}
