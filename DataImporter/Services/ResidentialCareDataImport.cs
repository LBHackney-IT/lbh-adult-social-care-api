using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Data;
using OfficeOpenXml;
using System.IO;

namespace DataImporter.Services
{
    public class ResidentialCareDataImport : IResidentialCareDataImport
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IResidentsService _residentsService;

        public ResidentialCareDataImport(DatabaseContext databaseContext, IResidentsService residentsService)
        {
            _databaseContext = databaseContext;
            _residentsService = residentsService;
        }

        public async void Import(string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var file = new FileInfo(fileName);
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    if (worksheet.Cells[$"A{i}"].Value == null)
                        continue;

                    string hackneyID = worksheet.Cells[$"A{i}"].Value.ToString();
                    string serviceTypeGroup = worksheet.Cells[$"G{i}"].Value.ToString();
                    string elementType = worksheet.Cells[$"I{i}"].Value.ToString();
                    string costPer = worksheet.Cells[$"L{i}"].Value.ToString();
                    string quantity = worksheet.Cells[$"N{i}"].Value.ToString();
                    string unitOfMeasure = worksheet.Cells[$"N{i}"].Value.ToString();
                    string startDate = worksheet.Cells[$"W{i}"].Value.ToString();
                    string endDate = worksheet.Cells[$"X{i}"].Value.ToString();
                    string budgetCode = worksheet.Cells[$"Y{i}"].Value.ToString();
                    string supplierId = worksheet.Cells[$"AA{i}"].Value.ToString();
                    string supplierSite = worksheet.Cells[$"AB{i}"].Value.ToString();

                    var userInformation = await _residentsService.GetServiceUserInformationAsync(int.Parse(hackneyID));
                }


                _databaseContext.SaveChanges();
            }
        }
    }
}
