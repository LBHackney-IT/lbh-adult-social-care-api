using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class HomeCarePackageCostGateway : IHomeCarePackageCostGateway
    {
        private readonly DatabaseContext _databaseContext;

        public HomeCarePackageCostGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<HomeCarePackageCost> UpsertAsync(HomeCarePackageCost homeCarePackageCost)
        {
            HomeCarePackageCost homeCarePackageCostToUpdate = await _databaseContext.HomeCarePackageCosts
                .Include(item => item.Services)
                .FirstOrDefaultAsync(item => item.Id == homeCarePackageCost.Id).ConfigureAwait(false);
            if (homeCarePackageCostToUpdate == null)
            {
                homeCarePackageCostToUpdate = new HomeCarePackageCost();
                await _databaseContext.HomeCarePackageCosts.AddAsync(homeCarePackageCostToUpdate).ConfigureAwait(false);
            }
            homeCarePackageCostToUpdate.HomeCarePackageId = homeCarePackageCost.HomeCarePackageId;
            homeCarePackageCostToUpdate.ServiceId = homeCarePackageCost.ServiceId;
            homeCarePackageCostToUpdate.CostPerHour = homeCarePackageCost.CostPerHour;
            homeCarePackageCostToUpdate.HoursPerWeek = homeCarePackageCost.HoursPerWeek;
            homeCarePackageCostToUpdate.TotalCost = homeCarePackageCost.TotalCost;
            homeCarePackageCostToUpdate.CreatorId = homeCarePackageCost.CreatorId;
            homeCarePackageCostToUpdate.UpdatorId = homeCarePackageCost.UpdatorId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? homeCarePackageCostToUpdate
                : null;
        }

        public async Task<IList<HomeCarePackageCost>> GetListAsync(Guid homeCarePackageId)
        {
            var homeCarePackageSlot = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId)
                .ToListAsync()
                .ConfigureAwait(false);

            if (homeCarePackageSlot == null)
            {
                throw new ErrorException($"Could not find the Home Care Package Slot {homeCarePackageId}");
            }
            var homeCarePackageCostList = new List<HomeCarePackageCost>();

            List<HomeCarePackageCost> result = await _databaseContext.HomeCarePackageSlots
                                        .GroupBy(l => l.ServiceId)
                                        .Select(cl => new HomeCarePackageCost
                                        {
                                            ServiceId = cl.Key,
                                            HoursPerWeek = cl.Sum(c => c.PrimaryInMinutes/60)
                                        }).ToListAsync().ConfigureAwait(false);

            foreach (var item in result)
            {
                var homeCarePackageCost = new HomeCarePackageCost();
                homeCarePackageCost.HomeCarePackageId = homeCarePackageId;
                homeCarePackageCost.ServiceId = item.ServiceId;
                homeCarePackageCost.HoursPerWeek = item.HoursPerWeek;
                await _databaseContext.HomeCarePackageCosts.AddAsync(homeCarePackageCost).ConfigureAwait(false);
                homeCarePackageCostList.Add(homeCarePackageCost);
            }
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? homeCarePackageCostList
                : null;
        }
    }
}
