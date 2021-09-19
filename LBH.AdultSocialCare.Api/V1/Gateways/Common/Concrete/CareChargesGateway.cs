using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using Microsoft.EntityFrameworkCore.Internal;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CareChargesGateway : ICareChargesGateway
    {
        private readonly DatabaseContext _dbContext;

        public CareChargesGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PackageCareCharge>> GetCareChargesAsync(IEnumerable<Guid> packageIds)
        {
            var careCharges = await _dbContext.PackageCareCharges
                .Where(cc => packageIds.Contains(cc.PackageId))
                .Include(cc => cc.CareChargeElements)
                .ThenInclude(ce => ce.ClaimCollector)
                .Include(cc => cc.CareChargeElements)
                .ThenInclude(ce => ce.CareChargeType)
                .ToListAsync()
                .ConfigureAwait(false);

            return careCharges;
        }

        public async Task<ProvisionalCareChargeAmountPlainDomain> GetUsingServiceUserIdAsync(Guid serviceUserId)
        {
            // Get client age
            var clientBirthDate = await _dbContext.Clients
                .Where(c => c.Id.Equals(serviceUserId))
                .Select(c => c.DateOfBirth)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (clientBirthDate == null)
            {
                throw new ApiException($"Service user with Id {serviceUserId} not found");
            }

            var clientAge = clientBirthDate.GetAge(DateTime.Now);
            var todayDate = DateTimeOffset.Now.Date;

            // Use age to get provisional amount range
            var provisionalAmount = await _dbContext.ProvisionalCareChargeAmounts
                .Where(pca => (clientAge >= pca.AgeFrom && (pca.AgeTo == null || clientAge <= pca.AgeTo)) &&
                              (todayDate >= EF.Property<DateTime>(pca, nameof(pca.StartDate)).Date &&
                               (pca.EndDate == null || todayDate <= EF.Property<DateTime>(pca, nameof(pca.EndDate)).Date)))
                .OrderBy(pca => pca.StartDate)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return provisionalAmount?.ToDomain();
        }

        public async Task<bool> UpdateCareChargeElementStatusAsync(Guid packageCareChargeId, Guid careElementId, int newElementStatusId, DateTimeOffset? newEndDate)
        {
            // Get care charge element
            var element = await GetCareChargeElementAsync(packageCareChargeId, careElementId).ConfigureAwait(false);

            if (element == null)
            {
                throw new ApiException($"Care charge element with Id {careElementId} not found");
            }

            // Update element and save
            element.StatusId = newElementStatusId;

            if (newEndDate == null || newEndDate > element.StartDate)
            {
                element.EndDate = newEndDate;
            }

            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Failed to update care element status {ex.InnerException?.Message}",
                    ex);
            }
        }

        public async Task<CareChargeElementPlainDomain> CheckCareChargeElementExistsAsync(Guid packageCareChargeId,
            Guid careElementId)
        {
            var element = await _dbContext.CareChargeElements
                .Where(ce => ce.Id.Equals(careElementId) && ce.CareChargeId.Equals(packageCareChargeId))
                .AsNoTracking()
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (element == null)
            {
                throw new ApiException($"Care charge element with Id {careElementId} not found");
            }

            return element.ToPlainDomain();
        }

        private async Task<CareChargeElement> GetCareChargeElementAsync(Guid packageCareChargeId, Guid careElementId)
        {
            var element = await _dbContext.CareChargeElements
                .Where(ce => ce.Id.Equals(careElementId) && ce.CareChargeId.Equals(packageCareChargeId))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            return element;
        }

        public async Task<IEnumerable<CareChargeElementPlainDomain>> CreateCareChargeElementsAsync(IEnumerable<CareChargeElementPlainDomain> elementDomains)
        {
            var newElements = new List<CareChargeElement>();

            await using var transaction = await _dbContext.Database.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                foreach (var domain in elementDomains)
                {
                    var element = domain.ToEntity();
                    newElements.Add(element);

                    _dbContext.CareChargeElements.Add(element);
                }

                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                await transaction.CommitAsync().ConfigureAwait(false);

                return newElements.ToPlainDomain();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                throw new DbSaveFailedException("Saving care charge element failed", ex);
            }
        }

        public async Task<CareChargeElementPlainDomain> CreateCareChargeElementAsync(CareChargeElement careChargeElement)
        {
            try
            {
                await _dbContext.CareChargeElements.AddAsync(careChargeElement).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return careChargeElement.ToPlainDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException("Saving care charge element failed", ex);
            }
        }

        public async Task<PagedList<CareChargePackagesDomain>> GetCareChargePackages(CareChargePackagesParameters parameters)
        {
            var careChargePackagesCount = await GetCareChargePackagesCount(parameters).ConfigureAwait(false);
            var careChargePackageList = await GetCareChargePackagesList(parameters).ConfigureAwait(false);

            var paginatedCareChargePackageList = careChargePackageList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return PagedList<CareChargePackagesDomain>.ToPagedList(paginatedCareChargePackageList, careChargePackagesCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<SinglePackageCareChargeDomain> GetSinglePackageCareCharge(Guid packageId, int packageTypeId)
        {
            switch (packageTypeId)
            {
                case PackageTypesConstants.NursingCarePackageId:
                    return await GetNursingCareCharge(packageId).ConfigureAwait(false);
                case PackageTypesConstants.ResidentialCarePackageId:
                    return await GetResidentialCareCharge(packageId).ConfigureAwait(false);
                default:
                    return null;
            }
        }

        private async Task<SinglePackageCareChargeDomain> GetResidentialCareCharge(Guid packageId)
        {
            var careChargeId = await _dbContext.PackageCareCharges
                .Where(pcc => pcc.PackageId.Equals(packageId))
                .Select(x => x.Id).SingleOrDefaultAsync().ConfigureAwait(false);

            return await _dbContext.ResidentialCarePackages
                .Where(rc => rc.Id.Equals(packageId))
                .Include(item => item.Client)
                .Include(item => item.Supplier)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.ResidentialCareBrokerageInfo)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .ThenInclude(item => item.AdditionalNeedsPaymentType)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .ThenInclude(item => item.ResidentialCareAdditionalNeedsCost)
                .Select(rc => new SinglePackageCareChargeDomain
                {
                    CareChargeId = careChargeId,
                    CareChargeStatus = rc.ResidentialCareBrokerageInfo.HasCareCharges == true ? "Existing" : "New",
                    CarePackage = new CarePackageDomain
                    {
                        Id = rc.Id,
                        ClientId = rc.ClientId,
                        IsFixedPeriod = rc.IsFixedPeriod,
                        StartDate = rc.StartDate,
                        EndDate = rc.EndDate,
                        HasRespiteCare = rc.HasRespiteCare,
                        HasDischargePackage = rc.HasDischargePackage,
                        IsThisUserUnderS117 = rc.IsThisUserUnderS117,
                        IsThisAnImmediateService = rc.IsThisAnImmediateService,
                        SupplierId = rc.SupplierId,
                        SupplierName = rc.Supplier.SupplierName,
                        TypeOfStayId = rc.TypeOfStayId,
                        TypeOfStay = rc.TypeOfStayOption.OptionName
                    },
                    Client = new ClientsDomain
                    {
                        Id = rc.Client.Id,
                        HackneyId = rc.Client.HackneyId,
                        FirstName = rc.Client.FirstName,
                        MiddleName = rc.Client.MiddleName,
                        LastName = rc.Client.LastName,
                        DateOfBirth = rc.Client.DateOfBirth,
                        AddressLine1 = rc.Client.AddressLine1,
                        AddressLine2 = rc.Client.AddressLine2,
                        AddressLine3 = rc.Client.AddressLine3,
                        PostCode = rc.Client.PostCode,
                        County = rc.Client.County,
                        Town = rc.Client.Town
                    },
                    CarePackageBrokerage = new CarePackageBrokerageDomain
                    {
                        Name = $"{PackageTypesConstants.ResidentialCarePackage} / wk",
                        StartDate = rc.StartDate,
                        EndDate = rc.EndDate,
                        Amount = rc.ResidentialCareBrokerageInfo.ResidentialCore,
                        CarePackageElements = rc.ResidentialCareAdditionalNeeds.Select(an => new CarePackageElementDomain
                        {
                            Name = $"Additional Needs Payment {an.AdditionalNeedsPaymentType.OptionName}",
                            Amount = an.ResidentialCareAdditionalNeedsCost.AdditionalNeedsCost,
                            StartDate = an.StartDate ?? rc.StartDate,
                            EndDate = an.EndDate ?? rc.EndDate
                        })
                    },
                    CareChargeElements = _dbContext.CareChargeElements
                        .Where(cce => cce.CareChargeId.Equals(careChargeId))
                        .Select(items => new CareChargeElementDomain()
                        {
                            Id = items.Id,
                            CareChargeId = items.CareChargeId,
                            Status = items.CareChargeElementStatus.StatusName,
                            StatusId = items.StatusId,
                            TypeId = items.TypeId,
                            Name = items.Name,
                            Amount = items.Amount,
                            StartDate = items.StartDate,
                            EndDate = items.EndDate,
                        })
                })
                .SingleOrDefaultAsync().ConfigureAwait(false);
        }

        private async Task<SinglePackageCareChargeDomain> GetNursingCareCharge(Guid packageId)
        {
            var careChargeId = await _dbContext.PackageCareCharges
                .Where(pcc => pcc.PackageId.Equals(packageId))
                .Select(x => x.Id).SingleOrDefaultAsync().ConfigureAwait(false);

            return await _dbContext.NursingCarePackages
                .Where(nc => nc.Id.Equals(packageId))
                .Include(item => item.Client)
                .Include(item => item.Supplier)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.NursingCareAdditionalNeeds)
                .ThenInclude(item => item.AdditionalNeedsPaymentType)
                .Include(item => item.NursingCareAdditionalNeeds)
                .ThenInclude(item => item.NursingCareAdditionalNeedsCost)
                .Include(item => item.NursingCareBrokerageInfo)
                .Select(nc => new SinglePackageCareChargeDomain()
                {
                    CareChargeId = careChargeId,
                    CareChargeStatus = nc.NursingCareBrokerageInfo.HasCareCharges == true ? "Existing" : "New",
                    CarePackage = new CarePackageDomain
                    {
                        Id = nc.Id,
                        ClientId = nc.ClientId,
                        IsFixedPeriod = nc.IsFixedPeriod,
                        StartDate = nc.StartDate,
                        EndDate = nc.EndDate,
                        HasRespiteCare = nc.HasRespiteCare,
                        HasDischargePackage = nc.HasDischargePackage,
                        IsThisUserUnderS117 = nc.IsThisUserUnderS117,
                        IsThisAnImmediateService = nc.IsThisAnImmediateService,
                        SupplierId = nc.SupplierId,
                        SupplierName = nc.Supplier.SupplierName,
                        TypeOfStayId = nc.TypeOfStayId,
                        TypeOfStay = nc.TypeOfStayOption.OptionName
                    },
                    Client = new ClientsDomain
                    {
                        Id = nc.Client.Id,
                        HackneyId = nc.Client.HackneyId,
                        FirstName = nc.Client.FirstName,
                        MiddleName = nc.Client.MiddleName,
                        LastName = nc.Client.LastName,
                        DateOfBirth = nc.Client.DateOfBirth,
                        AddressLine1 = nc.Client.AddressLine1,
                        AddressLine2 = nc.Client.AddressLine2,
                        AddressLine3 = nc.Client.AddressLine3,
                        PostCode = nc.Client.PostCode,
                        County = nc.Client.County,
                        Town = nc.Client.Town
                    },
                    CarePackageBrokerage = new CarePackageBrokerageDomain
                    {
                        Name = $"{PackageTypesConstants.NursingCarePackage} / wk",
                        StartDate = nc.StartDate,
                        EndDate = nc.EndDate,
                        Amount = nc.NursingCareBrokerageInfo.NursingCore,
                        CarePackageElements = nc.NursingCareAdditionalNeeds.Select(an => new CarePackageElementDomain
                        {
                            Name = $"Additional Needs Payment {an.AdditionalNeedsPaymentType.OptionName}",
                            Amount = an.NursingCareAdditionalNeedsCost.AdditionalNeedsCost,
                            StartDate = an.StartDate ?? nc.StartDate,
                            EndDate = an.EndDate ?? nc.EndDate
                        })
                    },
                    CareChargeElements = _dbContext.CareChargeElements
                        .Where(cce => cce.CareChargeId.Equals(careChargeId))
                        .Select(items => new CareChargeElementDomain()
                        {
                            Id = items.Id,
                            CareChargeId = items.CareChargeId,
                            Status = items.CareChargeElementStatus.StatusName,
                            StatusId = items.StatusId,
                            TypeId = items.TypeId,
                            Name = items.Name,
                            Amount = items.Amount,
                            StartDate = items.StartDate,
                            EndDate = items.EndDate,
                        })
                })
                .SingleOrDefaultAsync().ConfigureAwait(false);
        }

        private async Task<int> GetCareChargePackagesCount(CareChargePackagesParameters parameters)
        {
            var packageCount = 0;

            packageCount += await _dbContext.ResidentialCarePackages
                .FilterCareChargeResidentialCareList(parameters.Status, parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy).Include(p => p.ResidentialCareApprovalHistories)
                .CountAsync().ConfigureAwait(false);

            packageCount += await _dbContext.NursingCarePackages
                .FilterCareChargeNursingCareList(parameters.Status, parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy).Include(p => p.NursingCareApprovalHistories)
                .CountAsync().ConfigureAwait(false);

            return packageCount;
        }

        private async Task<List<CareChargePackagesDomain>> GetCareChargePackagesList(CareChargePackagesParameters parameters)
        {
            var packageList = new List<CareChargePackagesDomain>();

            var residentialCare = await GetCareChargeResidentialCarePackages(parameters).ConfigureAwait(false);
            packageList.AddRange(residentialCare);

            var nursingCare = await GetCareChargeNursingCarePackages(parameters).ConfigureAwait(false);
            packageList.AddRange(nursingCare);

            return packageList;
        }

        private async Task<List<CareChargePackagesDomain>> GetCareChargeResidentialCarePackages(CareChargePackagesParameters parameters)
        {
            var residentialCarePackageList = await _dbContext.ResidentialCarePackages
                .FilterCareChargeResidentialCareList(parameters.Status, parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy)
                .Include(item => item.Client)
                .Include(item => item.Updater)
                .Select(rc => new CareChargePackagesDomain()
                {
                    Status = rc.ResidentialCareBrokerageInfo.HasCareCharges == true ? "Existing" : "New",
                    ServiceUser = $"{rc.Client.FirstName} {rc.Client.LastName}",
                    DateOfBirth = rc.Client.DateOfBirth,
                    Address = $"{rc.Client.AddressLine1} {rc.Client.AddressLine2} {rc.Client.AddressLine3} {rc.Client.County} {rc.Client.Town} {rc.Client.PostCode}",
                    HackneyId = rc.Client.HackneyId,
                    PackageTypeId = PackageTypesConstants.ResidentialCarePackageId,
                    PackageType = PackageTypesConstants.ResidentialCarePackage,
                    PackageId = rc.Id,
                    StartDate = rc.StartDate,
                    LastModified = rc.DateUpdated,
                    ModifiedBy = rc.Updater.Name
                })
                .ToListAsync().ConfigureAwait(false);
            return residentialCarePackageList;
        }

        private async Task<List<CareChargePackagesDomain>> GetCareChargeNursingCarePackages(CareChargePackagesParameters parameters)
        {
            var nursingCarePackageList = await _dbContext.NursingCarePackages
                .FilterCareChargeNursingCareList(parameters.Status, parameters.FirstName, parameters.LastName,
                    parameters.DateOfBirth, parameters.PostCode, parameters.MosaicId, parameters.ModifiedAt, parameters.ModifiedBy)
                .Include(item => item.Client)
                .Include(item => item.Updater)
                .Select(ncp => new CareChargePackagesDomain
                {
                    Status = ncp.NursingCareBrokerageInfo.HasCareCharges == true ? "Existing" : "New",
                    ServiceUser = $"{ncp.Client.FirstName} {ncp.Client.LastName}",
                    DateOfBirth = ncp.Client.DateOfBirth,
                    Address = $"{ncp.Client.AddressLine1} {ncp.Client.AddressLine2} {ncp.Client.AddressLine3} {ncp.Client.County} {ncp.Client.Town} {ncp.Client.PostCode}",
                    HackneyId = ncp.Client.HackneyId,
                    PackageTypeId = PackageTypesConstants.NursingCarePackageId,
                    PackageType = PackageTypesConstants.NursingCarePackage,
                    PackageId = ncp.Id,
                    StartDate = ncp.StartDate,
                    LastModified = ncp.DateUpdated,
                    ModifiedBy = ncp.Updater.Name
                })
                .ToListAsync().ConfigureAwait(false);
            return nursingCarePackageList;
        }

        public async Task RefreshCareChargeElementsPaidUpToDate(IEnumerable<CareChargeElement> elements, DateTimeOffset paidUpTo)
        {
            foreach (var element in elements)
            {
                element.PreviousPaidUpTo = element.PaidUpTo;
                element.PaidUpTo = Dates.Min(paidUpTo, element.PaidUpTo);
            }

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
