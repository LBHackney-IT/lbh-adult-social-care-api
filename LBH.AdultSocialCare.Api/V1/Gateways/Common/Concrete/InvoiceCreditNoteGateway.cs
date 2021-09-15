using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class InvoiceCreditNoteGateway : IInvoiceCreditNoteGateway
    {
        private readonly DatabaseContext _dbContext;

        public InvoiceCreditNoteGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InvoiceCreditNotePlainDomain> CreateInvoiceCreditNoteAsync(InvoiceCreditNote newInvoiceCreditNote)
        {
            var entry = await _dbContext.InvoiceCreditNotes.AddAsync(newInvoiceCreditNote).ConfigureAwait(false);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.ToPlainDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Failed to save invoice credit note {ex.InnerException?.Message}", ex);
            }
        }
    }
}
