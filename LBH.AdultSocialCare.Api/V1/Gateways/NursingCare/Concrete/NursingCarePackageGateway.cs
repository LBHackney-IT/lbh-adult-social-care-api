using AutoMapper;
using Common.Exceptions.CustomExceptions;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete
{
    public class NursingCarePackageGateway : INursingCarePackageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;
        private readonly ITransactionsService _transactionsService;
        private readonly IFundedNursingCaseGateway _fundedNursingCaseGateway;

        public NursingCarePackageGateway(DatabaseContext databaseContext, IMapper mapper, IIdentityHelperUseCase identityHelperUseCase, ITransactionsService transactionsService, IFundedNursingCaseGateway fundedNursingCaseGateway)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _identityHelperUseCase = identityHelperUseCase;
            _transactionsService = transactionsService;
            _fundedNursingCaseGateway = fundedNursingCaseGateway;
        }

        public async Task<NursingCarePackageDomain> UpdateAsync(NursingCarePackageForUpdateDomain nursingCarePackageForUpdate)
        {
            var nursingCarePackageEntity = await _databaseContext.NursingCarePackages
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageForUpdate.Id).ConfigureAwait(false);
            if (nursingCarePackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate nursing care package {nursingCarePackageForUpdate.Id.ToString()}");
            }

            // Map updated fields with auto mapper and save
            _mapper.Map(nursingCarePackageForUpdate, nursingCarePackageEntity);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return nursingCarePackageEntity.ToDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Update for nursing care package {nursingCarePackageForUpdate.Id.ToString()} failed {ex.Message}", ex);
            }
        }

        public async Task<NursingCarePackageDomain> CreateAsync(NursingCarePackage nursingCarePackageForCreation)
        {
            var entry = await _databaseContext.NursingCarePackages.AddAsync(nursingCarePackageForCreation).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.ToDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException("Could not save nursing care package to database" + ex.Message);
            }
        }

        public async Task<NursingCarePackageDomain> GetAsync(Guid nursingCarePackageId)
        {
            var result = await _databaseContext.NursingCarePackages
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageId).ConfigureAwait(false);

            if (result == null)
            {
                throw new EntityNotFoundException($"Unable to locate nursing care package {nursingCarePackageId.ToString()}");
            }

            return result.ToDomain();
        }

        public async Task<NursingCarePackagePlainDomain> CheckNursingCarePackageExists(Guid nursingCarePackageId)
        {
            var nursingCarePackage = await _databaseContext.NursingCarePackages.AsNoTracking()
                .SingleOrDefaultAsync(nc => nc.Id.Equals(nursingCarePackageId)).ConfigureAwait(false);

            if (nursingCarePackage == null)
            {
                throw new ApiException($"Nursing care package with Id {nursingCarePackageId} not found",
                    StatusCodes.Status404NotFound);
            }

            return nursingCarePackage.ToPlainDomain();
        }

        public async Task<NursingCarePackageDomain> ChangeStatusAsync(Guid nursingCarePackageId, int statusId)
        {
            NursingCarePackage nursingCarePackageToUpdate = await _databaseContext.NursingCarePackages
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageId)
                .ConfigureAwait(false);

            if (nursingCarePackageToUpdate == null)
            {
                throw new EntityNotFoundException($"Couldn't find nursing care package {nursingCarePackageId.ToString()}");
            }
            nursingCarePackageToUpdate.StatusId = statusId;

            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return nursingCarePackageToUpdate.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for nursing care package {nursingCarePackageToUpdate.Id.ToString()} failed");
            }
        }

        public async Task<IEnumerable<NursingCarePackageDomain>> ListAsync()
        {
            var res = await _databaseContext.NursingCarePackages
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IEnumerable<TypeOfNursingCareHomeDomain>> GetListOfTypeOfNursingCareHomeAsync()
        {
            var res = await _databaseContext.TypesOfNursingCareHomes
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IEnumerable<NursingCareTypeOfStayOptionDomain>> GetListOfNursingCareTypeOfStayOptionAsync()
        {
            var res = await _databaseContext.NursingCareTypeOfStayOptions
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<int> GetClientPackagesCountAsync(Guid clientId)
        {
            return await _databaseContext.NursingCarePackages
                .Where(p => p.ClientId == clientId)
                .CountAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> GenerateNursingCareInvoices(DateTimeOffset dateTo)
        {
            var todayDate = DateTimeOffset.Now.Date;

            if (dateTo > todayDate)
            {
                dateTo = todayDate;
            }

            dateTo = dateTo.Date;

            // Get and store the creator id
            var creatorId = _identityHelperUseCase.GetUserId();

            // Get all relevant nursing care package ids
            var nursingCarePackagesIds = await _databaseContext.NursingCarePackages.Where(nc =>
                    ((nc.EndDate == null && nc.PaidUpTo == null) ||
                     (nc.EndDate == null && nc.PaidUpTo != null &&
                      EF.Property<DateTime>(nc, nameof(nc.PaidUpTo)).Date < dateTo.Date &&
                      dateTo.AddDays(-1).Date > EF.Property<DateTime>(nc, nameof(nc.PaidUpTo)).Date) ||
                     (nc.EndDate != null &&
                      EF.Property<DateTime>(nc, nameof(nc.EndDate)).Date < EF.Property<DateTime>(nc, nameof(nc.PaidUpTo)).Date &&
                      dateTo.AddDays(-1).Date > EF.Property<DateTime>(nc, nameof(nc.PaidUpTo)).Date)) &&
                    nc.NursingCareBrokerageInfo.NursingCareBrokerageId != null
                )
                .Select(nc => nc.Id)
                .ToListAsync()
                .ConfigureAwait(false);

            // Get the minimum invoice start date
            var minInvoiceDate =
                await _databaseContext.NursingCarePackages.Where(nc => nursingCarePackagesIds.Contains(nc.Id))
                    .Select(nc => new { StartDate = nc.PaidUpTo ?? nc.StartDate })
                    .OrderByDescending(nc => nc.StartDate)
                    .Select(nc => nc.StartDate)
                    .FirstOrDefaultAsync().ConfigureAwait(false);

            // Get fnc costs in the start and end range
            var fncPrices = await _fundedNursingCaseGateway.GetFundedNursingCarePricingInRangeAsync(minInvoiceDate, dateTo)
                .ConfigureAwait(false);
            var fncPriceList = fncPrices.ToList();

            // Iterate every 1000 and create invoices
            var nursingCarePackagesCount = nursingCarePackagesIds.Count;
            var iterations = Math.Ceiling(nursingCarePackagesCount / 1000M);
            for (var i = 0; i < iterations; i++)
            {
                var invoicesForCreation = new List<InvoiceForCreationRequest>();

                // Get nursing care packages in range
                var selectedIds = nursingCarePackagesIds.Skip(i * 1000).Take(1000);
                var nursingCarePackages = await _databaseContext.NursingCarePackages
                    .Where(nc => selectedIds.Contains(nc.Id))
                    .Include(nc => nc.NursingCareBrokerageInfo)
                    .ThenInclude(rc => rc.NursingCareAdditionalNeedsCosts)
                    .ThenInclude(rc => rc.AdditionalNeedsPaymentType)
                    .Include(nc => nc.FundedNursingCare)
                    .ThenInclude(fc => fc.FundedNursingCareCollector)
                    .Include(nc => nc.FundedNursingCare)
                    .ThenInclude(fc => fc.ReclaimFrom)
                    .ToListAsync()
                    .ConfigureAwait(false);

                foreach (var nursingCarePackage in nursingCarePackages)
                {
                    // Get weeks
                    var startDate = nursingCarePackage.PaidUpTo ?? nursingCarePackage.StartDate;

                    var dateDiff = (dateTo.Date - startDate.Date).Days;

                    if (dateDiff <= 0) continue;

                    var weeks = dateDiff / 7M;

                    // Collect invoice items
                    var invoiceItems = new List<InvoiceItemForCreationRequest>()
                    {
                        new InvoiceItemForCreationRequest
                        {
                            ItemName = $"Nursing Care Core Cost {startDate:dd MMM yyyy} - {dateTo:dd MMM yyyy}",
                            PricePerUnit = nursingCarePackage.NursingCareBrokerageInfo.NursingCore,
                            Quantity = weeks,
                            PriceEffect = "Add",
                            CreatorId = creatorId
                        }
                    };

                    //TODO refactor creation invoice item logic
                    if (nursingCarePackage.NursingCareBrokerageInfo.NursingCareAdditionalNeedsCosts.Count > 0)
                    {
                        foreach (var nursingCareAdditionalNeedsCost in nursingCarePackage.NursingCareBrokerageInfo.NursingCareAdditionalNeedsCosts)
                            // create invoice item for additional needs item except one off cost
                            if (nursingCareAdditionalNeedsCost.AdditionalNeedsPaymentTypeId != AdditionalNeedPaymentTypesConstants.OneOff)
                                invoiceItems.Add(new InvoiceItemForCreationRequest
                                {
                                    ItemName =
                                        $"Additional Needs {nursingCareAdditionalNeedsCost.AdditionalNeedsPaymentType.OptionName} {startDate:dd MMM yyyy} - {dateTo:dd MMM yyyy}",
                                    PricePerUnit = nursingCareAdditionalNeedsCost.AdditionalNeedsCost,
                                    Quantity = weeks,
                                    PriceEffect = "Add",
                                    CreatorId = _identityHelperUseCase.GetUserId()
                                });
                            else if (nursingCarePackage.PaidUpTo == null)
                                invoiceItems.Add(new InvoiceItemForCreationRequest
                                {
                                    ItemName =
                                        $"Additional Needs {nursingCareAdditionalNeedsCost.AdditionalNeedsPaymentType.OptionName} {startDate:dd MMM yyyy} - {dateTo:dd MMM yyyy}",
                                    PricePerUnit = nursingCareAdditionalNeedsCost.AdditionalNeedsCost,
                                    Quantity = 1,
                                    PriceEffect = "Add",
                                    CreatorId = _identityHelperUseCase.GetUserId()
                                });
                    }

                    // Check if package has FNC
                    var fundedNursingCare = nursingCarePackage.FundedNursingCare;
                    if (fundedNursingCare != null)
                    {
                        invoiceItems.AddRange(from fncCost in fncPriceList
                                              let fncStartDate = new[] { fncCost.ActiveFrom, startDate }.Max()
                                              let fncEndDate = new[] { fncCost.ActiveTo, dateTo }.Min()
                                              let fncWeeks = ((fncEndDate.Date - fncStartDate.Date).Days) / 7M
                                              where weeks > 0
                                              let fncItemName = nursingCarePackage.FundedNursingCare.FundedNursingCareCollector.OptionInvoiceName
                                              let fncClaimedBy = fundedNursingCare.FundedNursingCareCollector.ClaimedBy switch
                                              {
                                                  PackageCostClaimersConstants.Hackney => "Hackney",
                                                  PackageCostClaimersConstants.Supplier => "Supplier",
                                                  _ => "Hackney"
                                              }
                                              let fncPriceEffect = fncClaimedBy switch
                                              {
                                                  "Hackney" => "None",
                                                  "Supplier" => "Subtract",
                                                  _ => "Add"
                                              }
                                              select new InvoiceItemForCreationRequest
                                              {
                                                  ItemName = fncItemName,
                                                  PricePerUnit = fncCost.PricePerWeek,
                                                  Quantity = fncWeeks,
                                                  PriceEffect = fncPriceEffect,
                                                  ClaimedBy = fncClaimedBy,
                                                  ReclaimedFrom = fundedNursingCare.ReclaimFrom.ReclaimFromName,
                                                  CreatorId = creatorId
                                              });
                    }

                    // Create the invoice
                    invoicesForCreation.Add(new InvoiceForCreationRequest
                    {
                        SupplierId = nursingCarePackage.SupplierId,
                        PackageTypeId = PackageTypesConstants.NursingCarePackageId,
                        ServiceUserId = nursingCarePackage.ClientId,
                        CreatorId = creatorId,
                        DateFrom = startDate.Date,
                        DateTo = dateTo,
                        PackageId = nursingCarePackage.Id,
                        InvoiceItems = invoiceItems
                    });

                    // update previous paid up to
                    nursingCarePackage.PreviousPaidUpTo = nursingCarePackage.PaidUpTo;

                    // Update paidUpTo
                    nursingCarePackage.PaidUpTo = dateTo;
                }

                if (invoicesForCreation.Count > 0)
                {
                    await _transactionsService.BatchCreateInvoicesUseCase(invoicesForCreation).ConfigureAwait(false);
                }

                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            }

            return true;
        }

        public async Task<bool> ResetInvoicePaidUpToDate(List<Guid> nursingCarePackageIds)
        {
            var nursingCarePackages = await _databaseContext.NursingCarePackages
                .Where(nc => nursingCarePackageIds.Contains(nc.Id))
                .ToListAsync().ConfigureAwait(false);

            foreach (var nursingCarePackage in nursingCarePackages)
            {
                nursingCarePackage.PaidUpTo = nursingCarePackage.PreviousPaidUpTo;
            }

            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
