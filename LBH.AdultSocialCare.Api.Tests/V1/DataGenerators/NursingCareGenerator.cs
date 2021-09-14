using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.Tests.V1.DataGenerators
{
    public class NursingCareGenerator
    {
        private readonly DatabaseContext _context;

        public NursingCareGenerator(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<NursingCarePackage> GetPackage()
        {
            var client = await _context.Clients.FirstOrDefaultAsync().ConfigureAwait(false);

            var package = new NursingCarePackage
            {
                StageId = 1,
                StatusId = 2,
                ClientId = client.Id,
                StartDate = DateTimeOffset.Now.AddDays(-30)
            };

            await _context.NursingCarePackages.AddAsync(package).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return package;
        }

        public async Task<List<NursingCarePackage>> GetPackages(int count)
        {
            var result = new List<NursingCarePackage>();

            for (var i = 0; i < count; i++)
            {
                result.Add(await GetPackage().ConfigureAwait(false));
            }

            return result;
        }

        public async Task<NursingCareBrokerageInfo> GetBrokerageInfo(Guid packageId)
        {
            var brokerage = new NursingCareBrokerageInfo
            {
                NursingCarePackageId = packageId,
                NursingCore = new Bogus.Faker().Finance.Amount(10.0m),
            };

            _context.NursingCareBrokerageInfos.Add(brokerage);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return brokerage;
        }

        public async Task<NursingCareAdditionalNeedsCost> GetAdditionalNeedsCost(Guid brokerageId, int type)
        {
            var cost = new NursingCareAdditionalNeedsCost
            {
                NursingCareBrokerageId = brokerageId,
                AdditionalNeedsPaymentTypeId = type,
                AdditionalNeedsCost = new Bogus.Faker().Finance.Amount(10.0m),
                CreatorId = new Guid(UserConstants.DefaultApiUserId)
            };

            _context.NursingCareAdditionalNeedsCosts.Add(cost);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return cost;
        }
    }
}
