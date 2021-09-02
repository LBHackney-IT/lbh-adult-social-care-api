using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class DataGenerator
    {
        private readonly DatabaseContext _context;

        public DataGenerator(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<NursingCarePackage> GenerateNursingCarePackage()
        {
            var client = await _context.Clients.FirstOrDefaultAsync().ConfigureAwait(false);

            var package = new NursingCarePackage
            {
                StageId = 1,
                StatusId = 2,
                ClientId = client.Id
            };

            _context.NursingCarePackages.Add(package);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return package;
        }

        public async Task<List<NursingCarePackage>> GenerateNursingCarePackages(int count)
        {
            var result = new List<NursingCarePackage>();

            for (var i = 0; i < count; i++)
            {
                result.Add(await GenerateNursingCarePackage().ConfigureAwait(false));
            }

            return result;
        }

        public async Task<NursingCareBrokerageInfo> GenerateNursingCareBrokerageInfo(Guid packageId)
        {
            var brokerage = new NursingCareBrokerageInfo
            {
                NursingCarePackageId = packageId,
                NursingCore = 0.0m
            };

            _context.NursingCareBrokerageInfos.Add(brokerage);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return brokerage;
        }
    }
}
