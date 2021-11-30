using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using OfficeOpenXml;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class DownloadPayRunCedarFileUseCase : IDownloadPayRunCedarFileUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IDatabaseManager _dbManager;

        public DownloadPayRunCedarFileUseCase(IPayRunGateway payRunGateway, IDatabaseManager dbManager)
        {
            _payRunGateway = payRunGateway;
            _dbManager = dbManager;
        }

        public async Task<MemoryStream> ExecuteAsync(Guid payRunId)
        {
            var payRun = await _payRunGateway.GetPayRunAsync(payRunId, PayRunFields.None, true)
                .EnsureExistsAsync($"Pay run with id {payRunId} not found");

            if (payRun.Status.NotIn(PayrunStatus.Approved, PayrunStatus.PaidWithHold, PayrunStatus.Paid))
            {
                throw new ApiException($"Pay run must be approved or paid to download file", HttpStatusCode.BadRequest);
            }

            var list = new List<PayRunInsightsResponse>()
            {
                new PayRunInsightsResponse() { PayRunId = payRunId, TotalHeldAmount = 100M},
                new PayRunInsightsResponse() { PayRunId = payRunId, TotalHeldAmount = 200M},
            };
            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                await package.SaveAsync();
            }
            stream.Position = 0;

            // Record download history then return stream
            var history = new PayrunHistory
            {
                Notes = "Cedar file downloaded", Status = payRun.Status, Type = PayRunHistoryType.CedarFileDownload
            };

            payRun.Histories.Add(history);

            await _dbManager.SaveAsync($"Failed to add pay run history");

            return stream;
        }
    }
}
