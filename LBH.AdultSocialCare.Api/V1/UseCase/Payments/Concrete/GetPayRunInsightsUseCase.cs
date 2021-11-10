using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunInsightsUseCase : IGetPayRunInsightsUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public GetPayRunInsightsUseCase(IPayRunGateway payRunGateway, IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _payRunGateway = payRunGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task<PayRunInsightsResponse> GetAsync(Guid payRunId)
        {
            var payRun = await _payRunGateway.GetPayRunAsync(payRunId)
                .EnsureExistsAsync($"Pay run with id {payRunId} not found");

            var previousPayRun = await _payRunGateway.GetPreviousPayRunAsync(payRun.Type);

            // Get pay run invoiced totals
            var thisPayRunTotal = await _payRunInvoiceGateway.GetPayRunInvoicedTotalAsync(payRunId);
            var previousPayRunTotal = 0M;

            if (previousPayRun != null)
            {
                previousPayRunTotal = await _payRunInvoiceGateway.GetPayRunInvoicedTotalAsync(previousPayRun.Id);
            }

            var result = new PayRunInsightsResponse
            {
                PayRunId = payRun.Id,
                TotalInvoiceAmount = thisPayRunTotal,
                TotalDifferenceFromLastCycle = thisPayRunTotal - previousPayRunTotal,
                SupplierCount = await _payRunInvoiceGateway.GetSupplierCountInPayRunAsync(payRunId),
                ServiceUserCount = await _payRunInvoiceGateway.GetServiceUserCountInPayRunAsync(payRunId),
                HoldsCount = await _payRunInvoiceGateway.GetPayRunHeldInvoiceCountAsync(payRunId),
                TotalHeldAmount = await _payRunInvoiceGateway.GetPayRunHeldInvoiceTotalAsync(payRunId)
            };

            return result;
        }
    }
}
