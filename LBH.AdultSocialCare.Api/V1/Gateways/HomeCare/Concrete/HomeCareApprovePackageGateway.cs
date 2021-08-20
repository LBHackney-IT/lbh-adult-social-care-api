using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Concrete
{
    public class HomeCareApprovePackageGateway : IHomeCareApprovePackageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public HomeCareApprovePackageGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<HomeCareApprovePackageDomain> GetAsync(Guid homeCarePackageId)
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
                throw new ApiException($"Could not find the Home Care Package Slot {homeCarePackageId}");
            }

            var homeCareApprovePackageDomain = new HomeCareApprovePackageDomain()
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
