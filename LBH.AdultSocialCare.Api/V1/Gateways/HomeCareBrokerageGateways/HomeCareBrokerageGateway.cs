using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareBrokerageGateways
{
    public class HomeCareBrokerageGateway : IHomeCareBrokerageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public HomeCareBrokerageGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<HomeCareBrokerageCreationDomain> CreateAsync(Guid homeCarePackageId,
            HomeCareBrokerageCreationDomain homeCareBrokerageCreation)
        {
            IList<HomeCarePackageCost> itemsToDelete = await _databaseContext.HomeCarePackageCosts
                .Where(item => item.HomeCarePackageId == homeCarePackageId)
                .ToListAsync()
                .ConfigureAwait(false);

            if (itemsToDelete.Count > 0)
            {
                foreach (var item in itemsToDelete) _databaseContext.HomeCarePackageCosts.Remove(item);

                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            }

            foreach (var homeCarePackageCostInput in homeCareBrokerageCreation.HomeCarePackageCost)
            {
                var homeCarePackageCostToCreate = new HomeCarePackageCost
                {
                    HomeCarePackageId = homeCarePackageId,
                    HomeCareServiceTypeId = homeCarePackageCostInput.HomeCareServiceTypeId,
                    CarerTypeId = homeCarePackageCostInput.CarerTypeId,
                    IsSecondaryCarer = homeCarePackageCostInput.IsSecondaryCarer,
                    HoursPerWeek = homeCarePackageCostInput.HoursPerWeek,
                    CostPerHour = homeCarePackageCostInput.CostPerHour,
                    TotalCost = homeCarePackageCostInput.TotalCost
                };

                await _databaseContext.HomeCarePackageCosts.AddAsync(homeCarePackageCostToCreate).ConfigureAwait(false);
            }

            var success = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) > 0;

            return success
                ? homeCareBrokerageCreation
                : null;
        }

        public async Task<HomeCareBrokerageDomain> GetAsync(Guid homeCarePackageId)
        {
            var homeCarePackage = await _databaseContext.HomeCarePackage
                .Where(item => item.Id == homeCarePackageId)
                .Include(item => item.Client)
                .Include(item => item.Supplier)
                .Include(item => item.Status)
                .Include(item => item.Stage)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (homeCarePackage == null)
                throw new ApiException($"Could not find the Home Care Package {homeCarePackageId}");

            var homeCarePackageSlot = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId)
                .ToListAsync()
                .ConfigureAwait(false);

            if (homeCarePackageSlot == null)
                throw new ApiException($"Could not find the Home Care Package Slot {homeCarePackageId}");

            var homeCarePackageCostList = new List<HomeCarePackageCost>();

            //Calculate home care services primary carer hours
            var serviceHoursPerWeek = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId)
                .GroupBy(l => l.ServiceId)
                .Select(cl => new HomeCarePackageCost
                {
                    HomeCareServiceTypeId = cl.Key,
                    HoursPerWeek = cl.Sum(c => c.PrimaryInMinutes)
                }).ToListAsync().ConfigureAwait(false);

            foreach (var item in serviceHoursPerWeek)
            {
                var homeCarePackageCostPrimary = new HomeCarePackageCost
                {
                    HomeCarePackageId = homeCarePackageId,
                    HomeCareServiceTypeId = item.HomeCareServiceTypeId,
                    HoursPerWeek = item.HoursPerWeek / 60
                };
                homeCarePackageCostList.Add(homeCarePackageCostPrimary);
            }

            //Calculate home care services secondary carer hours
            var secondaryCarerHours = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId
                               && item.ServiceId == 1)
                .GroupBy(l => l.ServiceId)
                .Select(cl => new HomeCarePackageCost
                {
                    HomeCareServiceTypeId = cl.Key,
                    HoursPerWeek = cl.Sum(c => c.SecondaryInMinutes)
                }).ToListAsync().ConfigureAwait(false);

            foreach (var item in secondaryCarerHours)
            {
                var homeCarePackageCostSecondary = new HomeCarePackageCost
                {
                    HomeCarePackageId = homeCarePackageId,
                    HomeCareServiceTypeId = item.HomeCareServiceTypeId,
                    IsSecondaryCarer = true,
                    HoursPerWeek = item.HoursPerWeek / 60
                };
                homeCarePackageCostList.Add(homeCarePackageCostSecondary);
            }

            IList<HomeCarePackageSlots> timeSlotList = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageId
                               && item.ServiceId == 1)
                .ToListAsync()
                .ConfigureAwait(false);

            if (timeSlotList.Count > 0)
            {
                var callTypes = new Dictionary<int, int> { { 1, 30 }, { 2, 45 }, { 3, 60 } };
                var homeCareServiceType = 1;
                foreach (var item in callTypes)
                {
                    var items = item.Value != 60 ? timeSlotList.Where(minutes => minutes.PrimaryInMinutes == item.Value) : timeSlotList.Where(minutes => minutes.PrimaryInMinutes >= item.Value);
                    var homeCarePackageCostPrimaryDetail =
                        new HomeCarePackageCost
                        {
                            HomeCarePackageId = homeCarePackageId,
                            HomeCareServiceTypeId = homeCareServiceType,
                            CarerTypeId = item.Key
                        };
                    homeCarePackageCostPrimaryDetail.CarerType = await _databaseContext.CarerTypes
                        .FirstOrDefaultAsync(carerType =>
                            carerType.CarerTypeId == homeCarePackageCostPrimaryDetail.CarerTypeId)
                        .ConfigureAwait(false);
                    homeCarePackageCostPrimaryDetail.HoursPerWeek = (double) items.Sum(c => c.PrimaryInMinutes) / 60;
                    homeCarePackageCostList.Add(homeCarePackageCostPrimaryDetail);
                }
            }

            var homeCareBrokerageDomain = new HomeCareBrokerageDomain
            {
                HomeCarePackage = homeCarePackage.ToDomain(),
                HomeCarePackageCost = homeCarePackageCostList.ToDomain()
            };
            return homeCareBrokerageDomain;
        }
    }
}
