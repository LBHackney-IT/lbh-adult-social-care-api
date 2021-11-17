using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetPackagePaymentHistoryUseCase
    {
        Task<PackagePaymentViewResponse> GetAsync(Guid packageId, RequestParameters parameters);
    }
}
