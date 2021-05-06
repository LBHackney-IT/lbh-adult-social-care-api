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
    }
}
