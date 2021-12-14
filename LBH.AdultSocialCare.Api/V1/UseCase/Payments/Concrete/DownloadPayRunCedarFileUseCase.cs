using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
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

        public async Task<CedarFileResponse> ExecuteAsync(Guid payRunId)
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

                // Set header info 
                var headerIndex = 1;

                workSheet.Cells[headerIndex, 1].Value = 1;
                workSheet.Cells[headerIndex, 2].Value = 0;
                workSheet.Cells[headerIndex, 3].Value = "AP";
                workSheet.Cells[headerIndex, 4].Value = headerInfo.TotalValueOfInvoices;
                workSheet.Cells[headerIndex, 5].Value = headerInfo.TotalNumberOfInvoices;
                workSheet.Cells[headerIndex, 6].Value = "E5013";
                workSheet.Cells[headerIndex, 7].Value = "HA";

                // Set background color for invoice header
                workSheet.Cells[headerIndex, 1, headerIndex, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[headerIndex, 1, headerIndex, 11].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

                var invoiceRowIndex = 2;

                // Set initial invoice line number
                var invoiceNumber = 1;

                foreach (var invoice in invoiceList.OrderBy(x => x.InvoiceNumber))
                {
                    // Get Property Value of invoice header using Reflection
                    var invoiceModel = new CedarFileInvoiceHeader();
                    var cellIndex = 0;

                    foreach (PropertyInfo property in invoiceModel.GetType().GetProperties())
                    {
                        if (property.Name == "InvoiceItems")
                            continue;
                        if (property.Name == "InvoiceNumber") invoice.InvoiceNumber = invoiceNumber;
                        cellIndex++;
                        workSheet.Cells[invoiceRowIndex, cellIndex].Value = property.GetValue(invoice, null);
                        if (property.PropertyType == typeof(DateTime)) workSheet.Cells[invoiceRowIndex, cellIndex].Style.Numberformat.Format = "dd/mm/yyyy";
                    }

                    // Set background color for invoice line
                    workSheet.Cells[invoiceRowIndex, 1, invoiceRowIndex, cellIndex].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[invoiceRowIndex, 1, invoiceRowIndex, cellIndex].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                    // Set invoice item row index
                    var invoiceItemRowIndex = invoiceRowIndex + 1;

                    // Set initial invoice item number
                    var invoiceLineNumber = 1;

                    foreach (var invoiceItem in invoice.InvoiceItems)
                    {
                        // Get Property Value of invoice item using Reflection
                        var invoiceLineModel = new CedarFileInvoiceLineDomain();
                        var cellIndexInvoiceLine = 0;

                        foreach (PropertyInfo propertyInvoiceItem in invoiceLineModel.GetType().GetProperties())
                        {
                            cellIndexInvoiceLine++;
                            if (propertyInvoiceItem.Name == "InvoiceNumber") invoiceItem.InvoiceNumber = invoiceNumber;
                            if (propertyInvoiceItem.Name == "InvoiceLineNumber") invoiceItem.InvoiceLineNumber = invoiceLineNumber;
                            workSheet.Cells[invoiceItemRowIndex, cellIndexInvoiceLine].Value = propertyInvoiceItem.GetValue(invoiceItem, null);
                        }

                        workSheet.Cells[invoiceItemRowIndex, 1, invoiceItemRowIndex, cellIndexInvoiceLine].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        workSheet.Cells[invoiceItemRowIndex, 1, invoiceItemRowIndex, cellIndexInvoiceLine].Style.Fill.BackgroundColor.SetColor(Color.LawnGreen);

                        invoiceItemRowIndex++;
                        invoiceLineNumber++;
                    }

                    // Set next invoice header row index
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

            return new CedarFileResponse()
            {
                Stream = stream,
                PayRunNumber = payRun.Number
            };
        }
    }
}
