using AutoMapper;
using Common.Exceptions.CustomExceptions;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways
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
            if (result == null)
            {
                throw new EntityNotFoundException($"Unable to locate residential care package {residentialCarePackageId.ToString()}");
            }
            return result.ToDomain();
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

        public async Task<bool> GenerateResidentialCareInvoices(DateTimeOffset dateTo)
        {
            var todayDate = DateTimeOffset.Now.Date;
            if (dateTo > todayDate) dateTo = todayDate;

            var residentialCarePackagesIds = await _databaseContext.ResidentialCarePackages
                .Where(rc =>
                    ((rc.EndDate == null &&
                      rc.PaidUpTo == null) || (rc.EndDate == null && rc.PaidUpTo != null && rc.PaidUpTo < dateTo) ||
                     (rc.EndDate != null &&
                      rc.EndDate < rc.PaidUpTo &&
                      dateTo.AddDays(-1) > rc.PaidUpTo)) &&
                    rc.ResidentialCareBrokerageInfo.Id != null
                )
                .Select(rc => rc.Id)
                .ToListAsync()
                .ConfigureAwait(false);

            var residentialCarePackages = await _databaseContext.ResidentialCarePackages
                .Where(rc => residentialCarePackagesIds.Contains(rc.Id))
                .Include(rc => rc.ResidentialCareBrokerageInfo).ToListAsync()
                .ConfigureAwait(false);

            var invoicesForCreation = new List<InvoiceForCreationRequest>();

            foreach (var residentialCarePackage in residentialCarePackages)
            {
                var startDate = residentialCarePackage.PaidUpTo ?? residentialCarePackage.StartDate;
                var dateDiff = (dateTo.Date - startDate.Date).Days;
                var weeks = (decimal) dateDiff / 7;

                var invoiceItems = new List<InvoiceItemForCreationRequest>()
                {
                    new InvoiceItemForCreationRequest
                    {
                        ItemName = $"Residential Care Core Cost {startDate:dd MMM yyyy} - {dateTo:dd MMM yyyy} - {residentialCarePackage.PaidUpTo}",
                        PricePerUnit = residentialCarePackage.ResidentialCareBrokerageInfo.ResidentialCore,
                        Quantity = weeks,
                        CreatorId = _identityHelperUseCase.GetUserId()
                    },
                    new InvoiceItemForCreationRequest()
                    {
                        ItemName = $"Additional Needs Cost {startDate:dd MMM yyyy} - {dateTo:dd MMM yyyy}",
                        PricePerUnit = residentialCarePackage.ResidentialCareBrokerageInfo.AdditionalNeedsPayment,
                        Quantity = weeks,
                        CreatorId = _identityHelperUseCase.GetUserId()
                    }
                };

                if (residentialCarePackage.PaidUpTo == null && residentialCarePackage.ResidentialCareBrokerageInfo.AdditionalNeedsPaymentOneOff > 0)
                {
                    invoiceItems.Add(new InvoiceItemForCreationRequest
                    {
                        ItemName = "Additional Needs One Off Cost",
                        PricePerUnit = residentialCarePackage.ResidentialCareBrokerageInfo.AdditionalNeedsPaymentOneOff,
                        Quantity = 1,
                        CreatorId = _identityHelperUseCase.GetUserId()
                    });
                }

                invoicesForCreation.Add(new InvoiceForCreationRequest
                {
                    PackageTypeId = PackageTypesConstants.ResidentialCarePackageId,
                    ServiceUserId = residentialCarePackage.ClientId,
                    DateFrom = startDate.Date,
                    DateTo = dateTo,
                    PackageId = residentialCarePackage.Id,
                    SupplierId = residentialCarePackage.SupplierId,
                    InvoiceItems = invoiceItems,
                    CreatorId = _identityHelperUseCase.GetUserId(),
                });

                residentialCarePackage.PreviousPaidUpTo = residentialCarePackage.PaidUpTo;

                residentialCarePackage.PaidUpTo = dateTo.Date;
            }

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

            return true;
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
    }
}
