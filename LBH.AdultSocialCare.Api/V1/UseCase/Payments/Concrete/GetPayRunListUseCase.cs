using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunListUseCase : IGetPayRunListUseCase
    {
        private readonly IPayRunGateway _payRunGateway;

        public GetPayRunListUseCase(IPayRunGateway payRunGateway)
        {
            _payRunGateway = payRunGateway;
        }

        public async Task<PagedResponse<PayRunListResponse>> GetPayRunList(PayRunListParameters parameters)
        {
            var res = await _payRunGateway.GetPayRunList(parameters).ConfigureAwait(false);
            return new PagedResponse<PayRunListResponse>()
            {
                PagingMetaData = res.PagingMetaData,
                Data = res.ToResponse()
            };
        }
    }
}
