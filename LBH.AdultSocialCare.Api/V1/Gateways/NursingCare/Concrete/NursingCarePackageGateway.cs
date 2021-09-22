using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
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

        public NursingCarePackageGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
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

        public async Task<List<Guid>> GetUnpaidPackageIdsAsync(DateTimeOffset dateTo)
        {
            return await _databaseContext.NursingCarePackages.Where(nc =>
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
        }

        public async Task<List<NursingCarePackage>> GetFullPackagesByIds(IEnumerable<Guid> packageIds)
        {
            return await _databaseContext.NursingCarePackages
                .Where(nc => packageIds.Contains(nc.Id))
                .Include(nc => nc.NursingCareBrokerageInfo)
                .ThenInclude(rc => rc.NursingCareAdditionalNeedsCosts)
                .ThenInclude(rc => rc.AdditionalNeedsPaymentType)
                .Include(nc => nc.FundedNursingCare)
                .ThenInclude(fc => fc.FundedNursingCareCollector)
                .Include(nc => nc.FundedNursingCare)
                .ThenInclude(fc => fc.ReclaimFrom)
                .Include(nc => nc.CareCharge)
                .ThenInclude(cc => cc.CareChargeElements)
                .ThenInclude(ce => ce.ClaimCollector)
                .ToListAsync()
                .ConfigureAwait(false);
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

        public async Task RefreshPaidUpToDateAsync(List<NursingCarePackage> packages, DateTimeOffset paidUpTo)
        {
            foreach (var package in packages)
            {
                package.PreviousPaidUpTo = package.PaidUpTo;
                package.PaidUpTo = paidUpTo;
            }

            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
