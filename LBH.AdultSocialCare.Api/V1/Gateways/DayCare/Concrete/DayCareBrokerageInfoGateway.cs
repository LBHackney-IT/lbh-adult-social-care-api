using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Concrete
{
    public class DayCareBrokerageInfoGateway : IDayCareBrokerageInfoGateway
    {
        private readonly DatabaseContext _dbContext;

        public DayCareBrokerageInfoGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateDayCareBrokerageInfo(DayCareBrokerageInfo dayCareBrokerageInfo)
        {
            var entry = await _dbContext.DayCareBrokerageInfo.AddAsync(dayCareBrokerageInfo).ConfigureAwait(false);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.BrokerageInfoId;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save day care package brokerage info to database");
            }
        }

        public async Task<DayCareBrokerageInfoDomain> GetDayCareBrokerageInfoForPackage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dbContext.DayCareBrokerageInfo
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .AsNoTracking()
                .SingleOrDefaultAsync().ConfigureAwait(false);

            return dayCarePackage?.ToDomain();
        }

        public async Task<IEnumerable<DayCareBrokerageStageDomain>> GetDayCareBrokerageStages()
        {
            var statuses = await _dbContext.DayCarePackageStatuses.Where(ps =>
                    ps.IsDayCareStatus.Equals(true) && ps.IsStatusActive.Equals(true) &&
                    ps.Stage.Equals(PackageStageNameConstants.PackageBrokering))
                .AsNoTracking()
                .Select(ps => new DayCareBrokerageStageDomain
                {
                    PackageStatusId = ps.PackageStatusId,
                    StatusName = ps.StatusName,
                    CreatorId = ps.CreatorId,
                    UpdaterId = ps.UpdaterId,
                    SequenceNumber = ps.SequenceNumber,
                    IsDayCareStatus = ps.IsDayCareStatus,
                    IsStatusActive = ps.IsStatusActive,
                    Stage = ps.Stage,
                    PackageAction = ps.PackageAction
                })
                .ToListAsync().ConfigureAwait(false);
            return statuses;
        }

        public async Task UpdateEscortPackage(DayCareBrokerageInfo dayCareBrokerageInfo)
        {
            // Get package to update
            var escortPackageEntity = await _dbContext.EscortPackages
                .Where(e => e.DayCarePackageId.Equals(dayCareBrokerageInfo.DayCarePackageId))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (escortPackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate escort package for {dayCareBrokerageInfo.DayCarePackageId.ToString()}");
            }

            escortPackageEntity.SupplierId = dayCareBrokerageInfo.EscortSupplierId;
            escortPackageEntity.EscortCostPerHour = dayCareBrokerageInfo.EscortCostPerHour;
            escortPackageEntity.EscortHoursPerWeek = dayCareBrokerageInfo.EscortHoursPerWeek;
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for escort package {dayCareBrokerageInfo.DayCarePackageId.ToString()} failed");
            }
        }

        public async Task UpdateTransportPackage(DayCareBrokerageInfo dayCareBrokerageInfo)
        {
            // Get package to update
            var transportPackageEntity = await _dbContext.TransportPackages
                .Where(e => e.DayCarePackageId.Equals(dayCareBrokerageInfo.DayCarePackageId))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (transportPackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate transport package for {dayCareBrokerageInfo.DayCarePackageId.ToString()}");
            }

            transportPackageEntity.SupplierId = dayCareBrokerageInfo.TransportSupplierId;
            transportPackageEntity.TransportCostPerDay = dayCareBrokerageInfo.TransportCostPerDay;
            transportPackageEntity.TransportDaysPerWeek = dayCareBrokerageInfo.TransportDaysPerWeek;
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for transport package {dayCareBrokerageInfo.DayCarePackageId.ToString()} failed");
            }
        }

        public async Task UpdateTransportEscortPackage(DayCareBrokerageInfo dayCareBrokerageInfo)
        {
            // Get package to update
            var transportEscortPackageEntity = await _dbContext.TransportEscortPackages
                .Where(e => e.DayCarePackageId.Equals(dayCareBrokerageInfo.DayCarePackageId))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (transportEscortPackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate transport escort package for {dayCareBrokerageInfo.DayCarePackageId.ToString()}");
            }

            transportEscortPackageEntity.SupplierId = dayCareBrokerageInfo.EscortSupplierId;
            transportEscortPackageEntity.TransportEscortCostPerWeek = dayCareBrokerageInfo.TransportEscortCostPerWeek;
            transportEscortPackageEntity.TransportEscortHoursPerWeek = dayCareBrokerageInfo.TransportEscortHoursPerWeek;
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for transport escort package {dayCareBrokerageInfo.DayCarePackageId.ToString()} failed");
            }
        }
    }
}
