using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
{
    public class GetResidentialCareInvoiceDetailUseCase : IGetResidentialCareInvoiceDetailUseCase
    {
        private readonly IResidentialCareApproveBrokeredGateway _residentialCareApproveBrokeredGateway;

        public GetResidentialCareInvoiceDetailUseCase(IResidentialCareApproveBrokeredGateway residentialCareApproveBrokeredGateway)
        {
            _residentialCareApproveBrokeredGateway = residentialCareApproveBrokeredGateway;
        }

        public async Task<InvoiceResponse> GetResidentialCareInvoiceDetail(Guid residentialCarePackageId)
        {
            var residentialCareInvoiceDetail = await _residentialCareApproveBrokeredGateway.GetInvoiceDetail(residentialCarePackageId).ConfigureAwait(false);
            return residentialCareInvoiceDetail.ToResponse();
        }
    }
}
