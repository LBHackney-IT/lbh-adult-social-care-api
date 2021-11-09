using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Concrete
{
    public class HeldInvoiceGateway : IHeldInvoiceGateway
    {
        private readonly DatabaseContext _dbContext;

        public HeldInvoiceGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddHeldInvoice(HeldInvoice invoice)
        {
            _dbContext.HeldInvoices.Add(invoice);
        }
    }
}
