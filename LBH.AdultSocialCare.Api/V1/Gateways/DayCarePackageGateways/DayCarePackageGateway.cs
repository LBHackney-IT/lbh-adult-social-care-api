using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityTimesPerMonthOptionDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways
{
    public class DayCarePackageGateway : IDayCarePackageGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public DayCarePackageGateway(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> CreateDayCarePackage(Infrastructure.Entities.DayCarePackage dayCarePackage)
        {
            var entry = await _dbContext.DayCarePackages.AddAsync(dayCarePackage).ConfigureAwait(false);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.DayCarePackageId;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save day care package to database");
            }
        }

        public async Task<DayCarePackageDomain> UpdateDayCarePackage(DayCarePackageForUpdateDomain dayCarePackageForUpdate)
        {
            var dayCarePackageEntity = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageForUpdate.DayCarePackageId))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            if (dayCarePackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package {dayCarePackageForUpdate.DayCarePackageId.ToString()}");
            }
            // Map fields with auto mapper and save
            _mapper.Map(dayCarePackageForUpdate, dayCarePackageEntity);
            dayCarePackageEntity.DateUpdated = DateTimeOffset.Now;
            // DbUpdateConcurrencyException
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return dayCarePackageEntity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for day care package {dayCarePackageForUpdate.DayCarePackageId.ToString()} failed");
            }
        }

        public async Task<DayCarePackageDomain> GetDayCarePackage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .AsNoTracking()
                .Include(dc => dc.Client)
                .Include(dc => dc.TermTimeConsiderationOption)
                .Include(dc => dc.Creator)
                .Include(dc => dc.Updater)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (dayCarePackage == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package {dayCarePackageId.ToString()}");
            }

            return dayCarePackage.ToDomain();
        }

        public async Task<DayCarePackageForApprovalDetailsDomain> GetDayCarePackageForApprovalDetails(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .AsNoTracking()
                .Select(dc => new DayCarePackageForApprovalDetailsDomain
                {
                    PackageDetails = new PackageDetailsDto
                    {
                        DayCarePackageId = dc.DayCarePackageId,
                        IsFixedPeriodOrOngoing = dc.IsFixedPeriodOrOngoing,
                        StartDate = dc.StartDate,
                        EndDate = dc.EndDate,
                        Monday = dc.Monday,
                        Tuesday = dc.Tuesday,
                        Wednesday = dc.Wednesday,
                        Thursday = dc.Thursday,
                        Friday = dc.Friday,
                        Saturday = dc.Saturday,
                        Sunday = dc.Sunday,
                        TransportNeeded = dc.TransportNeeded,
                        EscortNeeded = dc.EscortNeeded,
                        TermTimeConsiderationOptionName = dc.TermTimeConsiderationOption.OptionName,
                        DayCareOpportunities = dc.DayCarePackageOpportunities.Select(dco => new DayCarePackageOpportunityDomain
                        {
                            DayCarePackageOpportunityId = dco.DayCarePackageOpportunityId,
                            HowLong = new OpportunityLengthOptionDomain
                            {
                                OpportunityLengthOptionId = dco.OpportunityLengthOptionId,
                                OptionName = dco.OpportunityLengthOption.OptionName,
                                TimeInMinutes = dco.OpportunityLengthOption.TimeInMinutes
                            },
                            HowManyTimesPerMonth = new OpportunityTimesPerMonthOptionDomain
                            {
                                OpportunityTimePerMonthOptionId = dco.OpportunityTimePerMonthOptionId,
                                OptionName = dco.OpportunityTimesPerMonthOption.OptionName
                            },
                            OpportunitiesNeedToAddress = dco.OpportunitiesNeedToAddress,
                            DayCarePackageId = dco.DayCarePackageId
                        })
                    },
                    ClientDetails = new ClientDetailsDto
                    {
                        ClientName = dc.Client != null ? $"{dc.Client.FirstName} {dc.Client.MiddleName} {dc.Client.LastName}" : null,
                        HackneyId = dc.Client.HackneyId,
                        DateOfBirth = dc.Client.DateOfBirth,
                        PostCode = dc.Client.PostCode
                    },
                    CostSummary = new CostSummaryDto
                    {
                        CostOfCarePerWeek = 0,
                        ANPPerWeek = 0,
                        TransportCostPerWeek = 0,
                        TotalCostPerWeek = 0
                    },
                    PackageApprovalHistory = dc.DayCareApprovalHistories.Select(ah => new PackageApprovalHistoryDto
                    {
                        HistoryId = ah.HistoryId,
                        DayCarePackageId = ah.DayCarePackageId,
                        DateCreated = ah.DateCreated,
                        CreatorId = ah.CreatorId,
                        CreatorName = ah.Creator.FirstName,
                        PackageStatusId = ah.PackageStatusId,
                        PackageStatusName = ah.PackageStatus.StatusName,
                        LogText = ah.LogText,
                        LogSubText = ah.LogSubText,
                        CreatorRole = ah.CreatorRole
                    })
                }).SingleOrDefaultAsync().ConfigureAwait(false);

            if (dayCarePackage == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package {dayCarePackageId.ToString()}");
            }

            return dayCarePackage;
        }

        public async Task<IEnumerable<DayCarePackageDomain>> GetDayCarePackageList()
        {
            var dayCarePackages = await _dbContext.DayCarePackages
                .Include(dc => dc.Client)
                .Include(dc => dc.TermTimeConsiderationOption)
                .Include(dc => dc.Creator)
                .Include(dc => dc.Updater)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
            return dayCarePackages?.ToDomain();
        }
    }
}
