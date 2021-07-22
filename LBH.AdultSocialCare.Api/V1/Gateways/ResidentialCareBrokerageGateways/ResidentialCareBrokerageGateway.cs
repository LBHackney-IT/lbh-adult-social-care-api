using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareBrokerageGateways
{
    public class ResidentialCareBrokerageGateway : IResidentialCareBrokerageGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ResidentialCareBrokerageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ResidentialCareBrokerageInfoDomain> CreateAsync(ResidentialCareBrokerageInfo residentialCareBrokerageInfo)
        {
            var entry = await _databaseContext.ResidentialCareBrokerageInfos.AddAsync(residentialCareBrokerageInfo).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity.ToDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException("Could not save residential brokerage to database" + ex.Message);
            }
        }

        public async Task<ResidentialCareBrokerageInfoDomain> GetAsync(Guid residentialCarePackageId)
        {
            var residentialCarePackage = await _databaseContext.ResidentialCarePackages
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackageId).ConfigureAwait(false);

            if (residentialCarePackage == null)
            {
                throw new EntityNotFoundException($"Could not find the Residential Care Package {residentialCarePackageId}");
            }

            return new ResidentialCareBrokerageInfoDomain
            {
                ResidentialCarePackageId = residentialCarePackageId,
                ResidentialCarePackage = residentialCarePackage.ToDomain(),
            };
        }

        public async Task<bool> SetStage(Guid residentialCarePackageId, int stageId)
        {
            var residentialPackage = await _databaseContext.ResidentialCarePackages
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackageId)
                .ConfigureAwait(false);

            if (residentialPackage == null)
            {
                throw new EntityNotFoundException($"Couldn't find residential care package {residentialCarePackageId.ToString()}");
            }
            residentialPackage.StageId = stageId;
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for residential care package stage {residentialCarePackageId} failed");
            }
        }
    }
}
