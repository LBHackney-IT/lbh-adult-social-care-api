using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces
{
    public interface IHeldInvoiceGateway
    {
        void AddHeldInvoice(HeldInvoice invoice);
    }
}
