using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces
{
    public interface IGetResidentialCareInvoiceDetailUseCase
    {
        Task<InvoiceResponse> GetResidentialCareInvoiceDetail(Guid residentialCarePackageId);
    }
}
