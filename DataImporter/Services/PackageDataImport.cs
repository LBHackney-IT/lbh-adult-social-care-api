using DataImporter.Model;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Services
{
    public class PackageDataImport : IPackageDataImport
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IResidentsService _residentsService;
        private readonly Guid _applicationID;
        public PackageDataImport(DatabaseContext databaseContext, IResidentsService residentsService)
        {
            _databaseContext = databaseContext;
            _residentsService = residentsService;
            _applicationID = Guid.Parse("aee45700-af9b-4ab5-bb43-535adbdcfb84");
        }

        public async Task Import(string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var file = new FileInfo(fileName);
            var excelRows = new List<ExcelRowModel>();
            using (var excelFile = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = excelFile.Workbook.Worksheets[0];
                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    if (worksheet.Cells[$"A{i}"].Value == null)
                        continue;

                    var excelRow = new ExcelRowModel()
                    {
                        RowNumber = i,
                        HackneyID = worksheet.Cells[$"A{i}"].Value?.ToString(),
                        ServiceTypeGroup = worksheet.Cells[$"G{i}"].Value?.ToString(),
                        ServiceType = worksheet.Cells[$"H{i}"].Value?.ToString(),
                        ElementType = worksheet.Cells[$"I{i}"].Value?.ToString(),
                        CostPer = worksheet.Cells[$"L{i}"].Value?.ToString(),
                        Quantity = worksheet.Cells[$"N{i}"].Value?.ToString(),
                        UnitOfMeasure = worksheet.Cells[$"N{i}"].Value?.ToString(),
                        StartDateOA = worksheet.Cells[$"W{i}"].Value?.ToString(),
                        EndDateOA = worksheet.Cells[$"X{i}"].Value?.ToString(),
                        BudgetCode = worksheet.Cells[$"Y{i}"].Value?.ToString(),
                        SupplierID = worksheet.Cells[$"AB{i}"].Value?.ToString(),
                        SupplierSite = worksheet.Cells[$"AC{i}"].Value?.ToString()
                    };

                    excelRows.Add(excelRow);
                }
            }

            var serviceUserPackages = excelRows.GroupBy(x => x.HackneyID, x => x).ToList();
            List<string> logs = new List<string>();
            foreach (var serviceUserPackage in serviceUserPackages)
            {
                bool hasError = false;
                Guid serviceUserID = await CreateOrSkipUser(serviceUserPackage.Key);
                if (serviceUserID == Guid.Empty)
                {
                    logs.Add($"{DateTimeOffset.UtcNow}\tRow Number: {serviceUserPackage.FirstOrDefault().RowNumber}\tService user {serviceUserPackage.Key} not found");
                    hasError = true;
                }
                var primarySupportReasonID = GetPrimarySupportReasonID(serviceUserPackage.FirstOrDefault().BudgetCode.Replace("-", "").Substring(0, 5));
                if (primarySupportReasonID == 0)
                {
                    logs.Add($"{DateTimeOffset.UtcNow}\tRow Number: {serviceUserPackage.FirstOrDefault().RowNumber}\tPrimary support reason {serviceUserPackage.FirstOrDefault().BudgetCode.Substring(0, 5)} not found");
                    hasError = true;
                }

                if (!int.TryParse(serviceUserPackage.FirstOrDefault().SupplierID, out int supplierId))
                {
                    logs.Add($"{DateTimeOffset.UtcNow}\tRow Number: {serviceUserPackage.FirstOrDefault().RowNumber}\tSupplierID {serviceUserPackage.FirstOrDefault().SupplierID} must be number.");
                    hasError = true;
                }

                var supplierID = GetSupplierID(supplierId, serviceUserPackage.FirstOrDefault().SupplierSite);
                if (supplierID == 0)
                {
                    logs.Add($"{DateTimeOffset.UtcNow}\tRow Number: {serviceUserPackage.FirstOrDefault().RowNumber}\tService user {serviceUserPackage.Key}\tSupplierID: {supplierId}\tSupplierSite: {serviceUserPackage.FirstOrDefault().SupplierSite} not found.");
                    hasError = true;
                }

                if (hasError) continue;

                var carePackage = new CarePackage()
                {
                    Id = Guid.NewGuid(),
                    PackageType = ExcelPackageModel.GetPackageType(serviceUserPackage.FirstOrDefault().ServiceType),
                    Status = PackageStatus.Approved,
                    PackageScheduling = PackageScheduling.Temporary,
                    DateCreated = DateTimeOffset.UtcNow,
                    CreatorId = _applicationID,
                    Settings = new CarePackageSettings()
                    {
                        Id = Guid.NewGuid(),
                        CreatorId = _applicationID,
                        DateCreated = DateTimeOffset.UtcNow,
                    },
                    SupplierId = supplierID,
                    ServiceUserId = serviceUserID,
                    PrimarySupportReasonId = primarySupportReasonID,
                };

                foreach (var package in serviceUserPackage)
                {
                    var excelPackageModel = new ExcelPackageModel(package.ElementType);
                    if (excelPackageModel.SubPackageType == ExcelPackageModel.ExcelPackageType.Detail)
                    {
                        var corePackage = new CarePackageDetail()
                        {
                            CarePackageId = carePackage.Id,
                            CreatorId = _applicationID,
                            Cost = Math.Abs(package.Cost),
                            DateCreated = DateTimeOffset.UtcNow,
                            Id = Guid.NewGuid(),
                            Type = excelPackageModel.PackageDetailType,
                            UnitOfMeasure = package.UnitOfMeasure,
                            StartDate = package.StartDate,
                            CostPeriod = excelPackageModel.CostPeriod,
                            EndDate = package.EndDate
                        };
                        carePackage.Details.Add(corePackage);
                        _databaseContext.CarePackageDetails.Add(corePackage);
                    }
                    else if (excelPackageModel.SubPackageType == ExcelPackageModel.ExcelPackageType.Reclaim)
                    {
                        var reclaim = new CarePackageReclaim()
                        {
                            CarePackageId = carePackage.Id,
                            CreatorId = _applicationID,
                            Cost = excelPackageModel.ReclaimType == ReclaimType.Fnc ? package.Cost : Math.Abs(package.Cost),
                            Description = package.ElementType,
                            DateCreated = DateTimeOffset.UtcNow,
                            Id = Guid.NewGuid(),
                            StartDate = package.StartDate,
                            EndDate = package.EndDate,
                            ClaimCollector = excelPackageModel.ClaimCollector,
                            SubType = excelPackageModel.CareChargeSubType,
                            Type = excelPackageModel.ReclaimType,
                            Status = ReclaimStatus.Active
                        };
                        carePackage.Reclaims.Add(reclaim);
                        _databaseContext.CarePackageReclaims.Add(reclaim);
                    }
                    else
                    {
                        logs.Add($"{DateTimeOffset.UtcNow}\tRow Number: {serviceUserPackage.FirstOrDefault().RowNumber}\tService user {serviceUserPackage.Key}\tPackage Type {package.ElementType} is not valid.");
                    }
                }
                _databaseContext.CarePackages.Add(carePackage);
            }

            File.WriteAllLines($"{fileName}_logs.txt", logs);
            _databaseContext.SaveChanges();
        }

        private async Task<Guid> CreateOrSkipUser(string hackneyID)
        {
            int hackneyId = int.Parse(hackneyID);
            var serviceUser = _databaseContext.ServiceUsers.SingleOrDefault(x => x.HackneyId == hackneyId);
            if (serviceUser != null)
            {
                return serviceUser.Id;
            }

            var userInformation = await _residentsService.GetServiceUserInformationAsync(int.Parse(hackneyID));
            if (!userInformation.Residents.Any())
            {
                return Guid.Empty;
            }

            var user = new ServiceUser()
            {
                Id = Guid.NewGuid(),
                HackneyId = int.Parse(hackneyID),
                FirstName = userInformation.Residents[0].FirstName,
                LastName = userInformation.Residents[0].LastName,
                DateOfBirth = userInformation.Residents[0].DateOfBirth.Year == 0001 ? new DateTime(1040, 1, 1) : userInformation.Residents[0].DateOfBirth,
                AddressLine1 = userInformation.Residents[0].Address?.Address,
                PostCode = userInformation.Residents[0].Address?.Postcode
            };
            _databaseContext.ServiceUsers.Add(user);
            await _databaseContext.SaveChangesAsync();

            return user.Id;
        }

        private int GetPrimarySupportReasonID(string budgetCode)
        {
            var entity = _databaseContext.PrimarySupportReasons.SingleOrDefault(x => x.CederBudgetCode == budgetCode);
            if (entity == null) return 0;

            return entity.PrimarySupportReasonId;
        }

        private int GetSupplierID(int cedarID, string siteReferenceID)
        {

            var supplier = _databaseContext.Suppliers.SingleOrDefault(x => x.CedarId == cedarID && x.CedarReferenceNumber == siteReferenceID);
            if (supplier == null) return 0;

            return supplier.Id;
        }
    }
}
