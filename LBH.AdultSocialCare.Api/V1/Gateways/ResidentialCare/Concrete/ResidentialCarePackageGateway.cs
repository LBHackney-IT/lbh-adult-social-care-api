using AutoMapper;
using Common.Exceptions.CustomExceptions;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Concrete
{
    public class ResidentialCarePackageGateway : IResidentialCarePackageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly ITransactionsService _transactionsService;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public ResidentialCarePackageGateway(DatabaseContext databaseContext, IMapper mapper
            , ITransactionsService transactionsService, IIdentityHelperUseCase identityHelperUseCase)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _transactionsService = transactionsService;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<ResidentialCarePackageDomain> UpdateAsync(ResidentialCarePackageForUpdateDomain residentialCarePackageForUpdate)
        {
            var residentialCarePackageEntity = await _databaseContext.ResidentialCarePackages
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackageForUpdate.Id).ConfigureAwait(false);
            if (residentialCarePackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate residential care package {residentialCarePackageForUpdate.Id.ToString()}");
            }

            // Map updated fields with auto mapper and save
            _mapper.Map(residentialCarePackageForUpdate, residentialCarePackageEntity);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return residentialCarePackageEntity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for residential care package {residentialCarePackageForUpdate.Id.ToString()} failed");
            }
        }

        public async Task<ResidentialCarePackageDomain> CreateAsync(ResidentialCarePackage residentialCarePackageForCreation)
        {
            var entry = await _databaseContext.ResidentialCarePackages.AddAsync(residentialCarePackageForCreation).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save residential care package to database");
            }
        }

        public async Task<ResidentialCarePackageDomain> GetAsync(Guid residentialCarePackageId)
        {
            var result = await _databaseContext.ResidentialCarePackages
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackageId).ConfigureAwait(false);
            return result?.ToDomain();
        }

        public async Task<ResidentialCarePackagePlainDomain> GetPlainAsync(Guid residentialCarePackageId)
        {
            var result = await _databaseContext.ResidentialCarePackages
                .SingleOrDefaultAsync(item => item.Id == residentialCarePackageId).ConfigureAwait(false);
            return result?.ToPlainDomain();
        }

        public async Task<ResidentialCarePackagePlainDomain> CheckResidentialCarePackageExistsAsync(Guid residentialCarePackageId)
        {
            var package = await _databaseContext.ResidentialCarePackages
                .SingleOrDefaultAsync(item => item.Id == residentialCarePackageId).ConfigureAwait(false);

            if (package == null)
            {
                throw new ApiException($"Residential care package with id {residentialCarePackageId} not found", StatusCodes.Status404NotFound);
            }

            return package.ToPlainDomain();
        }

        public async Task<ResidentialCarePackageDomain> ChangeStatusAsync(Guid residentialCarePackageId, int statusId)
        {
            ResidentialCarePackage residentialCarePackageToUpdate = await _databaseContext.ResidentialCarePackages
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackageId)
                .ConfigureAwait(false);

            if (residentialCarePackageToUpdate == null)
            {
                throw new EntityNotFoundException($"Couldn't find residential care package {residentialCarePackageId.ToString()}");
            }
            residentialCarePackageToUpdate.StatusId = statusId;

            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return residentialCarePackageToUpdate.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for residential care package {residentialCarePackageToUpdate.Id.ToString()} failed");
            }
        }

        public async Task<IEnumerable<ResidentialCarePackageDomain>> ListAsync()
        {
            var res = await _databaseContext.ResidentialCarePackages
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IEnumerable<TypeOfResidentialCareHomeDomain>> GetListOfTypeOfResidentialCareHomeAsync()
        {
            var res = await _databaseContext.TypesOfResidentialCareHomes
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IEnumerable<ResidentialCareTypeOfStayOptionDomain>> GetListOfResidentialCareTypeOfStayOptionAsync()
        {
            var res = await _databaseContext.ResidentialCareTypeOfStayOptions
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<int> GetClientPackagesCountAsync(Guid clientId)
        {
            return await _databaseContext.ResidentialCarePackages
                .Where(p => p.ClientId == clientId)
                .CountAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<Guid>> GetUnpaidPackageIdsAsync(DateTimeOffset dateTo)
        {
            return await _databaseContext.ResidentialCarePackages
                .Where(rc =>
                    ((rc.EndDate == null && rc.PaidUpTo == null) ||
                     (rc.EndDate == null && rc.PaidUpTo != null &&
                      _databaseContext.CompareDates(dateTo, rc.PaidUpTo) == 1 &&
                      _databaseContext.CompareDates(dateTo.AddDays(-1).Date, rc.PaidUpTo) == 1) ||
                     (rc.EndDate != null &&
                      _databaseContext.CompareDates(rc.PaidUpTo, rc.EndDate) == 1 &&
                      _databaseContext.CompareDates(dateTo.AddDays(-1).Date, rc.PaidUpTo) == 1)) &&
                    rc.ResidentialCareBrokerageInfo.Id != null
                )
                .Select(rc => rc.Id)
                .ToListAsync()
                .ConfigureAwait(false);
        }


        public async Task<List<ResidentialCarePackage>> GetPackagesByIds(List<Guid> packageIds)
        {
            return await _databaseContext.ResidentialCarePackages
                .Where(rc => packageIds.Contains(rc.Id))
                .Include(rc => rc.ResidentialCareBrokerageInfo)
                .ThenInclude(rc => rc.ResidentialCareAdditionalNeedsCosts)
                .ThenInclude(rc => rc.AdditionalNeedsPaymentType)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> ResetResidentialInvoicePaidUpToDate(List<Guid> residentialCarePackageIds)
        {
            var residentialCarePackages = await _databaseContext.ResidentialCarePackages
                .Where(rc => residentialCarePackageIds.Contains(rc.Id))
                .ToListAsync().ConfigureAwait(false);

            foreach (var item in residentialCarePackages)
                item.PaidUpTo = item.PreviousPaidUpTo;

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
