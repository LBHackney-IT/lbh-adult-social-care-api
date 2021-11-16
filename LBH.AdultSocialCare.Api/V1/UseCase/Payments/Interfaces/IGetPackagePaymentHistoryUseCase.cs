using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetPackagePaymentHistoryUseCase
    {
        Task<PackagePaymentViewResponse> GetAsync(Guid packageId, RequestParameters parameters);
    }
}
