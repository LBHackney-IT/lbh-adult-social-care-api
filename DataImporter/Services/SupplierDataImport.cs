using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Entities.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataImporter.Services
{
    public class SupplierDataImport : ISupplierDataImport
    {
        private readonly DatabaseContext _databaseContext;
        public SupplierDataImport(DatabaseContext databaseContext)
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
                List<Supplier> suppliers = new List<Supplier>();
                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    if (worksheet.Cells[$"A{i}"].Value == null)
                        continue;

                    suppliers.Add(new Supplier()
                    {
                        Id = i - 1,
                        SupplierName = worksheet.Cells[$"A{i}"].Value.ToString(),
                        CedarName = worksheet.Cells[$"B{i}"].Value.ToString(),
                        CedarReferenceNumber = worksheet.Cells[$"C{i}"].Value.ToString(),
                        CedarId = int.Parse(worksheet.Cells[$"D{i}"].Value.ToString()),
                        Address = worksheet.Cells[$"E{i}"].Value.ToString(),
                        Postcode = worksheet.Cells[$"F{i}"].Value.ToString()
                    });
                }
                _databaseContext.Suppliers.AddRange(suppliers);

                _databaseContext.SaveChanges();
            }
        }
    }
}
