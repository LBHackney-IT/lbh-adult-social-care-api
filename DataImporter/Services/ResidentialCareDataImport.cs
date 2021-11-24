using LBH.AdultSocialCare.Data;
using OfficeOpenXml;
using System;
using System.IO;

namespace DataImporter.Services
{
    public class ResidentialCareDataImport : IResidentialCareDataImport
    {
        private readonly DatabaseContext _databaseContext;
        public ResidentialCareDataImport(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Import(string fileName)
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


                }

                _databaseContext.SaveChanges();
            }
        }
    }
}
