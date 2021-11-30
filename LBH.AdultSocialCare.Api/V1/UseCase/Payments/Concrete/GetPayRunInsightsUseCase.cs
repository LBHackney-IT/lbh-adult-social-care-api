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
            var payRun = await _payRunGateway.GetPayRunAsync(payRunId).EnsureExistsAsync($"Pay run with id {payRunId} not found");

            var insights = await _payRunInvoiceGateway.GetPayRunInsightsAsync(payRunId);
            var previousPayRun = await _payRunGateway.GetPreviousPayRunAsync(payRun.Type);

            // Get pay run invoiced totals
            var previousPayRunTotal = 0M;

            if (previousPayRun != null)
            {
                previousPayRunTotal = await _payRunInvoiceGateway.GetPayRunInvoicedTotalAsync(previousPayRun.Id);
            }

            var result = new PayRunInsightsResponse
            {
                PayRunId = payRun.Id,
                PayRunStatus = payRun.Status,
                TotalInvoiceAmount = insights.TotalInvoiceAmount,
                TotalDifferenceFromLastCycle = insights.TotalInvoiceAmount - previousPayRunTotal,
                SupplierCount = insights.SupplierCount,
                ServiceUserCount = insights.ServiceUserCount,
                HoldsCount = insights.HoldsCount,
                TotalHeldAmount = insights.TotalHeldAmount,
                IsCedarFileDownloaded = insights.IsCedarFileDownloaded
            };

            return result;
        }
    }
}
