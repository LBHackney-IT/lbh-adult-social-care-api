using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareApproveBrokeredDomains;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApproveBrokeredGateways
{
    public class HomeCareApproveBrokeredGateway : IHomeCareApproveBrokeredGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public HomeCareApproveBrokeredGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<HomeCareApproveBrokeredDomain> GetAsync(Guid homeCarePackageId)
        {
            var homeCarePackage = await _databaseContext.HomeCarePackage
                .Where(item => item.Id == homeCarePackageId)
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.Stage)
                .Include(item => item.Supplier)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var homeCarePackageSlot = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId)
                .ToListAsync()
                .ConfigureAwait(false);

            if (homeCarePackageSlot == null)
            {
                throw new ErrorException($"Could not find the Home Care Package Slot {homeCarePackageId}");
            }

            var homeCareApprovePackageDomain = new HomeCareApproveBrokeredDomain()
            {
                HomeCarePackage = homeCarePackage.ToDomain(),
                HoursPerWeek = await HoursPerWeek(homeCarePackageId).ConfigureAwait(false),
                CostOfCare = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                HomeCarePackageBreakDown = new HomeCarePackageBreakDownDomain()
                {
                    PersonalCareTotalHours = await PackageBreakDown(homeCarePackageId, 1).ConfigureAwait(false),
                    DomesticTotalHours = await PackageBreakDown(homeCarePackageId, 2).ConfigureAwait(false),
                    EscortTotalHours = await PackageBreakDown(homeCarePackageId, 3).ConfigureAwait(false),
                    NightOwlTotalHours = await PackageBreakDown(homeCarePackageId, 4).ConfigureAwait(false),
                    SleepingNightsTotalHours = await PackageBreakDown(homeCarePackageId, 5).ConfigureAwait(false),
                    WakingNightsTotalHours = await PackageBreakDown(homeCarePackageId, 6).ConfigureAwait(false)
                },
                HomeCarePackageElementsCosting = new HomeCarePackageElementsCostingDomain()
                {
                    PrimaryCarer = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.HomeCareServiceTypeId == 1 && item.IsSecondaryCarer == false).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                    SecondaryCarer = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.HomeCareServiceTypeId == 1 && item.IsSecondaryCarer == true).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                    Domestic = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.HomeCareServiceTypeId == 2).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                    Escort = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.HomeCareServiceTypeId == 3).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                    NightOwl = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.HomeCareServiceTypeId == 4).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                    SleepingNights = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.HomeCareServiceTypeId == 5).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                    WakingNights = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.HomeCareServiceTypeId == 6).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                }
            };

            return homeCareApprovePackageDomain;
        }

        private async Task<double> HoursPerWeek(Guid homeCarePackageId)
        {
            var hoursPerWeekPrimary = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId).SumAsync(c => c.PrimaryInMinutes)
                .ConfigureAwait(false);
            var hoursPerWeekSecondary = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId).SumAsync(c => c.SecondaryInMinutes)
                .ConfigureAwait(false);

            return MinutesToHour(hoursPerWeekPrimary + hoursPerWeekSecondary);
        }

        private async Task<double> PackageBreakDown(Guid homeCarePackageId, int serviceId)
        {
            var packageBreakdown = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId && item.ServiceId == serviceId)
                .SumAsync(c => c.PrimaryInMinutes).ConfigureAwait(false);
            if (serviceId == 1)
            {
                packageBreakdown += await _databaseContext.HomeCarePackageSlots
                    .Where(item => item.HomeCarePackageId == homeCarePackageId && item.ServiceId == serviceId)
                    .SumAsync(c => c.SecondaryInMinutes).ConfigureAwait(false);
            }

            return MinutesToHour(packageBreakdown);
        }

        private static double MinutesToHour(double minutes)
        {
            return (minutes / 60);
        }

    }
}
