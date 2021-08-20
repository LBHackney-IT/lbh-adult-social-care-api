using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways
{
    public interface INursingCareApproveCommercialGateway
    {
        public Task<NursingCareApproveCommercialDomain> GetAsync(Guid nursingCarePackageId);

        Task<InvoiceDomain> GetInvoiceDetail(Guid nursingCarePackageId);
    }
}
