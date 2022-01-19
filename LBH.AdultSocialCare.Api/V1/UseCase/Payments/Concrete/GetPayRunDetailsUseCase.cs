using Common.Extensions;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunDetailsUseCase : IGetPayRunDetailsUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public GetPayRunDetailsUseCase(IPayRunGateway payRunGateway, IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _payRunGateway = payRunGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task<PayRunDetailsViewResponse> ExecuteAsync(Guid payrunId, PayRunDetailsQueryParameters parameters)
        {
            // Get pay run
            var payRun = await _payRunGateway
                .GetPayRunAsync(payrunId)
                .EnsureExistsAsync($"Pay Run {payrunId} not found");

            // Get pay run items
            var payRunInvoices =
                await _payRunInvoiceGateway.GetPayRunInvoicesSummaryAsync(payrunId, parameters);
            var result = PayrunExtensions.CreateDetailsViewResponse(payRun, payRunInvoices, payRunInvoices.PagingMetaData);
            return result;
        }
    }
}
