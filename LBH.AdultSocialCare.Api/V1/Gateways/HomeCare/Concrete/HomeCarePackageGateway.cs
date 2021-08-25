using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Concrete
{
    public class HomeCarePackageGateway : IHomeCarePackageGateway
    {
        private readonly DatabaseContext _databaseContext;

        public HomeCarePackageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<HomeCarePackage> GetAsync(Guid homeCarePackageId)
        {
            var result = await _databaseContext.HomeCarePackage.FirstOrDefaultAsync(item => item.Id == homeCarePackageId)
                .ConfigureAwait(false);

            return result;
        }

        public async Task<IList<HomeCarePackage>> ListAsync()
        {
            return await _databaseContext.HomeCarePackage.Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.Stage)
                .Include(item => item.Supplier)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<HomeCarePackage> ChangeStatusAsync(Guid homeCarePackageId, int statusId)
        {
            HomeCarePackage homeCarePackageToUpdate = await _databaseContext.HomeCarePackage
                .FirstOrDefaultAsync(item => item.Id == homeCarePackageId)
                .ConfigureAwait(false);

            if (homeCarePackageToUpdate == null)
            {
                throw new ApiException($"Couldn't find the record: {homeCarePackageId}");
            }

            homeCarePackageToUpdate.StatusId = statusId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? homeCarePackageToUpdate
                : null;
        }

        public async Task<HomeCarePackage> UpsertAsync(HomeCarePackage homeCarePackage)
        {
            var homeCarePackageToUpdate = await _databaseContext.HomeCarePackage.Include(item => item.Status)
                .Include(item => item.Client)
                .Include(item => item.Stage)
                .Include(item => item.Supplier)
                .FirstOrDefaultAsync(item => item.Id == homeCarePackage.Id)
                .ConfigureAwait(false);

            if (homeCarePackageToUpdate == null)
            {
                homeCarePackageToUpdate = homeCarePackage;

                // TODO revert
                //homeCarePackageToUpdate.StatusId = homeCarePackage.StatusId;
                homeCarePackageToUpdate.StatusId =
                    (await _databaseContext.PackageStatuses.FirstAsync().ConfigureAwait(false)).Id;

                await _databaseContext.HomeCarePackage.AddAsync(homeCarePackageToUpdate).ConfigureAwait(false);

                try
                {
                    await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

                    return homeCarePackageToUpdate;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    Debugger.Break();

                    throw new DbSaveFailedException("Could not save day care package to database");
                }
            }

            homeCarePackageToUpdate.StartDate = homeCarePackage.StartDate;
            homeCarePackageToUpdate.EndDate = homeCarePackage.EndDate;
            homeCarePackageToUpdate.IsFixedPeriod = homeCarePackage.IsFixedPeriod;
            homeCarePackageToUpdate.IsOngoingPeriod = homeCarePackage.IsOngoingPeriod;
            homeCarePackageToUpdate.IsThisAnImmediateService = homeCarePackage.IsThisAnImmediateService;
            homeCarePackageToUpdate.IsThisuserUnderS117 = homeCarePackage.IsThisuserUnderS117;
            homeCarePackageToUpdate.ClientId = homeCarePackage.ClientId;
            homeCarePackageToUpdate.CreatorId = homeCarePackage.CreatorId;
            homeCarePackageToUpdate.UpdaterId = homeCarePackage.UpdaterId;

            // TODO status

            homeCarePackageToUpdate.SupplierId = homeCarePackage.SupplierId;
            homeCarePackageToUpdate.StageId = homeCarePackage.StageId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? homeCarePackageToUpdate
                : null;
        }
    }
}