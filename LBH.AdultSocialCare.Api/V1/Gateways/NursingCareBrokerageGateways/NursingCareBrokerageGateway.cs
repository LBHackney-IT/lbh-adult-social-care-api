using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareBrokerageGateways
{
    public class NursingCareBrokerageGateway : INursingCareBrokerageGateway
    {
        private readonly DatabaseContext _databaseContext;

        public NursingCareBrokerageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<NursingCareBrokerageInfoDomain> CreateAsync(NursingCareBrokerageInfo nursingCareBrokerageInfo)
        {
            var entry = await _databaseContext.NursingCareBrokerageInfos.AddAsync(nursingCareBrokerageInfo).ConfigureAwait(false);
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

        public async Task<NursingCareBrokerageInfoDomain> GetAsync(Guid nursingCarePackageId)
        {
            var nursingCarePackage = await _databaseContext.NursingCarePackages
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageId).ConfigureAwait(false);

            if (nursingCarePackage == null)
            {
                throw new EntityNotFoundException($"Could not find the Nursing Care Package {nursingCarePackageId}");
            }

            return new NursingCareBrokerageInfoDomain()
            {
                NursingCarePackageId = nursingCarePackageId,
                NursingCarePackage = nursingCarePackage.ToDomain(),
            };
        }
    }
}
