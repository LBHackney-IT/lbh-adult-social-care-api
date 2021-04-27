using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class ResidentialCarePackageGateway : IResidentialCarePackageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public ResidentialCarePackageGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
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
    }
}