using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApproveBrokeredGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Concrete
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
