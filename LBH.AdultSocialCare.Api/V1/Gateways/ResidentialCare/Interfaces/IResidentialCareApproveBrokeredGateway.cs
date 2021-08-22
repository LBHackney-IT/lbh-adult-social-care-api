using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces
{
    public interface IResidentialCareApproveBrokeredGateway
    {
        public Task<ResidentialCareApproveBrokeredDomain> GetAsync(Guid residentialCarePackageId);

        Task<InvoiceDomain> GetInvoiceDetail(Guid residentialCarePackageId);
    }
}
