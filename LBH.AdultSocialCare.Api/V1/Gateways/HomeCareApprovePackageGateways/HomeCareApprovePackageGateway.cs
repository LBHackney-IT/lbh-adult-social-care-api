using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovePackageGateways
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
                HoursPerWeek = await _databaseContext.HomeCarePackageSlots
                            .Where(item => item.HomeCarePackageId == homeCarePackageId).SumAsync(c => c.PrimaryInMinutes / 60).ConfigureAwait(false),
                CostOfCare = await _databaseContext.HomeCarePackageCosts
                            .Where(item => item.HomeCarePackageId == homeCarePackageId).SumAsync(c => c.CostPerHour).ConfigureAwait(false),
                HomeCarePackageBreakDown = new HomeCarePackageBreakDownDomain()
                {
                    PersonalCareTotalHours = await _databaseContext.HomeCarePackageSlots
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.ServiceId == 1).SumAsync(c => c.PrimaryInMinutes / 60).ConfigureAwait(false),
                    DomesticTotalHours = await _databaseContext.HomeCarePackageSlots
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.ServiceId == 2).SumAsync(c => c.PrimaryInMinutes / 60).ConfigureAwait(false),
                    EscortTotalHours = await _databaseContext.HomeCarePackageSlots
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.ServiceId == 3).SumAsync(c => c.PrimaryInMinutes / 60).ConfigureAwait(false),
                    NightOwlTotalHours = await _databaseContext.HomeCarePackageSlots
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.ServiceId == 4).SumAsync(c => c.PrimaryInMinutes / 60).ConfigureAwait(false),
                    SleepingNightsTotalHours = await _databaseContext.HomeCarePackageSlots
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.ServiceId == 5).SumAsync(c => c.PrimaryInMinutes / 60).ConfigureAwait(false),
                    WakingNightsTotalHours = await _databaseContext.HomeCarePackageSlots
                            .Where(item => item.HomeCarePackageId == homeCarePackageId && item.ServiceId == 6).SumAsync(c => c.PrimaryInMinutes / 60).ConfigureAwait(false)
                }
            };

            return homeCareApprovePackageDomain;
        }
    }
}
