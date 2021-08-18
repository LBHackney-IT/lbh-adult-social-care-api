using AutoMapper;
using Common.Exceptions.CustomExceptions;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.GeneralDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways
{
    public class NursingCarePackageGateway : INursingCarePackageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;
        private readonly ITransactionsService _transactionsService;

        public NursingCarePackageGateway(DatabaseContext databaseContext, IMapper mapper, IIdentityHelperUseCase identityHelperUseCase, ITransactionsService transactionsService)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _identityHelperUseCase = identityHelperUseCase;
            _transactionsService = transactionsService;
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
                throw new DbSaveFailedException($"Update for nursing care package {nursingCarePackageForUpdate.Id.ToString()} failed {ex.Message}");
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
                    .Include(nc => nc.NursingCareBrokerageInfo).ToListAsync()
                    .ConfigureAwait(false);

                foreach (var nursingCarePackage in nursingCarePackages)
                {
                    // Get weeks
                    var startDate = nursingCarePackage.PaidUpTo ?? nursingCarePackage.StartDate;

                    var dateDiff = (dateTo.Date - startDate.Date).Days;

                    if (dateDiff <= 0) continue;

                    var weeks = dateDiff / 7M;

                    // Create invoice
                    var invoiceItems = new List<InvoiceItemForCreationRequest>()
                    {
                        new InvoiceItemForCreationRequest
                        {
                            ItemName = $"Nursing Care Core Cost {startDate:dd MMM yyyy} - {dateTo:dd MMM yyyy}",
                            PricePerUnit = nursingCarePackage.NursingCareBrokerageInfo.NursingCore,
                            Quantity = weeks,
                            CreatorId = _identityHelperUseCase.GetUserId()
                        },
                        new InvoiceItemForCreationRequest()
                        {
                            ItemName = $"Additional Needs Cost {startDate:dd MMM yyyy} - {dateTo:dd MMM yyyy}",
                            PricePerUnit = nursingCarePackage.NursingCareBrokerageInfo.AdditionalNeedsPayment,
                            Quantity = weeks,
                            CreatorId = _identityHelperUseCase.GetUserId()
                        }
                    };

                    // Create one off cost invoice item if first pay run
                    if (nursingCarePackage.PaidUpTo == null)
                    {
                        invoiceItems.Add(new InvoiceItemForCreationRequest
                        {
                            ItemName = "Nursing care package one off cost",
                            PricePerUnit = nursingCarePackage.NursingCareBrokerageInfo.AdditionalNeedsPaymentOneOff,
                            Quantity = 1,
                            CreatorId = _identityHelperUseCase.GetUserId()
                        });
                    }

                    // Create the invoice
                    invoicesForCreation.Add(new InvoiceForCreationRequest
                    {
                        SupplierId = nursingCarePackage.SupplierId,
                        PackageTypeId = PackageTypesConstants.NursingCarePackageId,
                        ServiceUserId = nursingCarePackage.ClientId,
                        CreatorId = _identityHelperUseCase.GetUserId(),
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

                // Send invoices to transactions api
                /*foreach (var invoiceForCreationRequest in invoicesForCreation)
                {
                    var res = await _transactionsService.CreateInvoiceUseCase(invoiceForCreationRequest)
                        .ConfigureAwait(false);
                }*/

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
