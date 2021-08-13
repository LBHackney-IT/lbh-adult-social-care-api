using LBH.AdultSocialCare.Api.V1.Domain.InvoiceDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApproveCommercialDomains;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways
{
    public interface INursingCareApproveCommercialGateway
    {
        public Task<NursingCareApproveCommercialDomain> GetAsync(Guid nursingCarePackageId);

        Task<InvoiceDomain> GetInvoiceDetail(Guid nursingCarePackageId);
    }
}
