using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using Microsoft.EntityFrameworkCore;

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
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save supplier to database");
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
                throw new ErrorException($"Could not find the Residential Care Package {residentialCarePackageId}");
            }

            var residentialCareBrokerageInfoDomain = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(item => item.ResidentialCarePackageId == residentialCarePackageId)
                .Select(ncb => new ResidentialCareBrokerageInfoDomain
                {
                    ResidentialCarePackageId = ncb.ResidentialCarePackageId,
                    ResidentialCarePackage = residentialCarePackage.ToDomain(),
                    ResidentialCore = ncb.ResidentialCore,
                    AdditionalNeedsPayment = ncb.AdditionalNeedsPayment,
                    AdditionalNeedsPaymentOneOff = ncb.AdditionalNeedsPaymentOneOff,
                    CreatorId = ncb.CreatorId,
                    UpdatorId = ncb.UpdatorId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return residentialCareBrokerageInfoDomain;
        }
    }
}
