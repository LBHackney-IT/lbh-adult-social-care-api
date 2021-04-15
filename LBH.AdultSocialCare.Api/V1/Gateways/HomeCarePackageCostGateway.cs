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
                .FirstOrDefaultAsync(item => item.Id == homeCarePackageCost.Id).ConfigureAwait(false);
            if (homeCarePackageCostToUpdate == null)
            {
                homeCarePackageCostToUpdate = new HomeCarePackageCost();
                await _databaseContext.HomeCarePackageCosts.AddAsync(homeCarePackageCostToUpdate).ConfigureAwait(false);
            }
            homeCarePackageCostToUpdate.HomeCarePackageId = homeCarePackageCost.HomeCarePackageId;
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
    }
}
