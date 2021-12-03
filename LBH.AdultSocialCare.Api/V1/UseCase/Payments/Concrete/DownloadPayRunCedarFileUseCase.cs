using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using OfficeOpenXml;
using OfficeOpenXml.Style;

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

            // Return header info
            var headerInfo = await _payRunGateway.GetPayRunInvoicesInfoAsync(payRunId);

            // Return invoice list
            var invoiceList = await _payRunGateway.GetCedarFileList(payRunId);

            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                // set excel file settings 
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.Style.Font.Size = 10;
                workSheet.Cells.Style.Font.Name = "Arial";

                // set header info 
                var headerIndex = 1;
                workSheet.Cells[headerIndex, 1].Value = 1;
                workSheet.Cells[headerIndex, 2].Value = 0;
                workSheet.Cells[headerIndex, 3].Value = "AP";
                workSheet.Cells[headerIndex, 4].Value = headerInfo.TotalValueOfInvoices;
                workSheet.Cells[headerIndex, 5].Value = headerInfo.TotalNumberOfInvoices;
                workSheet.Cells[headerIndex, 6].Value = "E5013";
                workSheet.Cells[headerIndex, 7].Value = "HA";

                workSheet.Cells[headerIndex, 1, headerIndex, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[headerIndex, 1, headerIndex, 11].Style.Fill.BackgroundColor.SetColor(Color.Yellow);


                var invoiceRowIndex = 2;
                var invoiceNumber = 1;
                foreach (var invoice in invoiceList)
                {
                    // set invoice header 
                    workSheet.Cells[invoiceRowIndex, 1].Value = invoice.InvoiceHeaderId;
                    workSheet.Cells[invoiceRowIndex, 2].Value = invoiceNumber;
                    workSheet.Cells[invoiceRowIndex, 3].Value = invoice.Subtype;
                    workSheet.Cells[invoiceRowIndex, 4].Value = invoice.InvoiceSupplierNumber;
                    workSheet.Cells[invoiceRowIndex, 5].Value = invoice.InvoiceReferenceNumber;
                    workSheet.Cells[invoiceRowIndex, 6].Value = invoice.TransactionDate.Date;
                    workSheet.Cells[invoiceRowIndex, 7].Value = invoice.ReceivedDate.Date;
                    workSheet.Cells[invoiceRowIndex, 8].Value = invoice.SupplierSiteReferenceId;
                    workSheet.Cells[invoiceRowIndex, 9].Value = invoice.GrossAmount;
                    workSheet.Cells[invoiceRowIndex, 10].Value = invoice.NetAmount;
                    workSheet.Cells[invoiceRowIndex, 11].Value = invoice.GrossVatAmount;

                    workSheet.Cells[invoiceRowIndex, 1, invoiceRowIndex, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[invoiceRowIndex, 1, invoiceRowIndex, 11].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                    var invoiceItemRowIndex = invoiceRowIndex + 1;
                    var invoiceLineNumber = 1;

                    foreach (var invoiceItem in invoice.InvoiceItems)
                    {
                        // set invoice list 
                        workSheet.Cells[invoiceItemRowIndex, 1].Value = invoiceItem.InvoiceLineId;
                        workSheet.Cells[invoiceItemRowIndex, 2].Value = invoiceNumber;
                        workSheet.Cells[invoiceItemRowIndex, 3].Value = invoiceLineNumber;
                        workSheet.Cells[invoiceItemRowIndex, 4].Value = invoiceItem.Name;
                        workSheet.Cells[invoiceItemRowIndex, 5].Value = invoiceItem.Quantity;
                        workSheet.Cells[invoiceItemRowIndex, 6].Value = invoiceItem.Cost;
                        workSheet.Cells[invoiceItemRowIndex, 7].Value = invoiceItem.TaxFlag;
                        workSheet.Cells[invoiceItemRowIndex, 8].Value = invoiceItem.CostCentre;
                        workSheet.Cells[invoiceItemRowIndex, 9].Value = invoiceItem.Subjective;
                        workSheet.Cells[invoiceItemRowIndex, 10].Value = invoiceItem.Analysis;
                        workSheet.Cells[invoiceItemRowIndex, 11].Value = invoiceItem.TaxStatus;

                        workSheet.Cells[invoiceItemRowIndex, 1, invoiceItemRowIndex, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        workSheet.Cells[invoiceItemRowIndex, 1, invoiceItemRowIndex, 11].Style.Fill.BackgroundColor.SetColor(Color.LawnGreen);

                        invoiceItemRowIndex++;
                        invoiceLineNumber++;
                    }

                    invoiceRowIndex = invoiceItemRowIndex;
                    invoiceNumber++;
                }

                await package.SaveAsync();
            }
            stream.Position = 0;

            // Record download history then return stream
            var history = new PayrunHistory
            {
                Notes = "Cedar file downloaded",
                Status = payRun.Status,
                Type = PayRunHistoryType.CedarFileDownload
            };

            payRun.Histories.Add(history);

            await _dbManager.SaveAsync($"Failed to add pay run history");

            return stream;
        }
    }
}
