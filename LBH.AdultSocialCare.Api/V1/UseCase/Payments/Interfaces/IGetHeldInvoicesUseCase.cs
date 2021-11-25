using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetHeldInvoicesUseCase
    {
        Task<PagedResponse<HeldInvoiceDetailsResponse>> ExecuteAsync(PayRunDetailsQueryParameters parameters);
    }
}
