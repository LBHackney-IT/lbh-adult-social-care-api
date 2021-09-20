using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.Tests.V1.DataGenerators
{
    public class ResidentialCareGenerator
    {
        private readonly DatabaseContext _context;

        public ResidentialCareGenerator(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResidentialCarePackage> GetPackage()
        {
            var client = await _context.Clients.FirstOrDefaultAsync().ConfigureAwait(false);

            var package = new ResidentialCarePackage
            {
                StageId = 1,
                StatusId = 2,
                ClientId = client.Id,
                StartDate = DateTimeOffset.Now.AddDays(-30)
            };

            await _context.ResidentialCarePackages.AddAsync(package).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return package;
        }

        public async Task<List<ResidentialCarePackage>> GetPackages(int count)
        {
            var result = new List<ResidentialCarePackage>();

            for (var i = 0; i < count; i++)
            {
                result.Add(await GetPackage().ConfigureAwait(false));
            }

            return result;
        }

        public async Task<ResidentialCareAdditionalNeed> GetAdditionalNeeds(Guid packageId)
        {
            var additionalNeeds = new ResidentialCareAdditionalNeed()
            {
                ResidentialCarePackageId = packageId,
                NeedToAddress = "test",
                AdditionalNeedsPaymentTypeId = 1
            };

            _context.ResidentialCareAdditionalNeeds.Add(additionalNeeds);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return additionalNeeds;
        }

        public async Task<ResidentialCareBrokerageInfo> GetBrokerageInfo(Guid packageId)
        {
            var brokerage = new ResidentialCareBrokerageInfo
            {
                ResidentialCarePackageId = packageId,
                ResidentialCore = new Bogus.Faker().Finance.Amount(10.0m),
            };

            _context.ResidentialCareBrokerageInfos.Add(brokerage);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return brokerage;
        }

        public async Task<ResidentialCareAdditionalNeedsCost> GetAdditionalNeedsCost(Guid brokerageId, Guid additionalNeedsId, int type)
        {
            var cost = new ResidentialCareAdditionalNeedsCost
            {
                ResidentialCareBrokerageId = brokerageId,
                ResidentialCareAdditionalNeedsId = additionalNeedsId,
                AdditionalNeedsPaymentTypeId = type,
                AdditionalNeedsCost = new Bogus.Faker().Finance.Amount(10.0m),
                CreatorId = new Guid(UserConstants.DefaultApiUserId)
            };

            _context.ResidentialCareAdditionalNeedsCosts.Add(cost);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return cost;
        }
    }
}
