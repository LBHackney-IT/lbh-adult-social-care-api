using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IInvoiceCreditNoteGateway
    {
        Task<InvoiceCreditNotePlainDomain> CreateInvoiceCreditNoteAsync(InvoiceCreditNote newInvoiceCreditNote);
    }
}
