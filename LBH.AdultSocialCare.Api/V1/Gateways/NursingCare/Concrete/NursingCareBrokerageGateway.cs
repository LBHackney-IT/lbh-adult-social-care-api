using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete
{
    public class NursingCareBrokerageGateway : INursingCareBrokerageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public NursingCareBrokerageGateway(DatabaseContext databaseContext, IIdentityHelperUseCase identityHelperUseCase)
        {
            _databaseContext = databaseContext;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<NursingCareBrokerageInfoDomain> CreateAsync(NursingCareBrokerageInfo nursingCareBrokerageInfo)
        {
            var entry = await _databaseContext.NursingCareBrokerageInfos.AddAsync(nursingCareBrokerageInfo).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity.ToDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Could not save supplier to database: {ex.InnerException?.Message}", ex);
            }
        }

        public async Task<NursingCareBrokerageInfoDomain> GetAsync(Guid nursingCarePackageId)
        {
            /*var nursingCarePackage = await _databaseContext.NursingCarePackages
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageId).ConfigureAwait(false);*/
            var nursingCarePackage = await _databaseContext.NursingCarePackages
                .Where(nc => nc.Id.Equals(nursingCarePackageId))
                .Select(nc => new NursingCareBrokerageInfoDomain
                {
                    NursingCareBrokerageId = nc.NursingCareBrokerageInfo.NursingCareBrokerageId,
                    NursingCarePackageId = nc.Id,
                    NursingCarePackage = new NursingCarePackageDomain
                    {
                        Id = nc.Id,
                        ClientId = nc.ClientId,
                        IsFixedPeriod = nc.IsFixedPeriod,
                        StartDate = nc.StartDate,
                        EndDate = nc.EndDate,
                        HasRespiteCare = nc.HasRespiteCare,
                        HasDischargePackage = nc.HasDischargePackage,
                        IsThisAnImmediateService = nc.IsThisAnImmediateService,
                        IsThisUserUnderS117 = nc.IsThisUserUnderS117,
                        TypeOfStayId = nc.TypeOfStayId,
                        NeedToAddress = nc.NeedToAddress,
                        TypeOfNursingCareHomeId = nc.TypeOfNursingCareHomeId,
                        CreatorId = nc.CreatorId,
                        UpdaterId = nc.UpdaterId,
                        StatusId = nc.StatusId,
                        SupplierId = nc.SupplierId,
                        StageId = nc.StageId,
                        AssignedUserId = nc.AssignedUserId,
                        ClientName = nc.Client.FirstName,
                        ClientHackneyId = nc.Client.HackneyId,
                        ClientPostCode = nc.Client.PostCode,
                        ClientDateOfBirth = nc.Client.DateOfBirth,
                        ClientPreferredContact = nc.Client.PreferredContact,
                        ClientCanSpeakEnglish = nc.Client.CanSpeakEnglish,
                        StatusName = nc.Status.StatusName,
                        CreatorName = nc.Creator.Name,
                        UpdaterName = nc.Updater.Name,
                        PackageName = PackageTypesConstants.NursingCarePackage,
                        TypeOfCareHomeName = nc.TypeOfCareHome.TypeOfCareHomeName,
                        TypeOfStayOptionName = nc.TypeOfStayOption.OptionName,
                        NursingCareAdditionalNeeds = nc.NursingCareAdditionalNeeds.Select(an => new NursingCareAdditionalNeedsDomain
                        {
                            Id = an.Id,
                            NursingCarePackageId = an.NursingCarePackageId,
                            AdditionalNeedsPaymentTypeId = an.AdditionalNeedsPaymentTypeId,
                            AdditionalNeedsPaymentTypeName = an.AdditionalNeedsPaymentType.OptionName,
                            NeedToAddress = an.NeedToAddress,
                            CreatorId = an.CreatorId,
                            UpdaterId = an.UpdaterId
                        })
                    },
                    NursingCareAdditionalNeedsCosts = nc.NursingCareBrokerageInfo.NursingCareAdditionalNeedsCosts.Select(anc => new NursingCareAdditionalNeedsCostDomain
                    {
                        NursingCareBrokerageId = anc.NursingCareBrokerageId,
                        AdditionalNeedsPaymentTypeId = anc.AdditionalNeedsPaymentTypeId,
                        AdditionalNeedsPaymentTypeName = anc.AdditionalNeedsPaymentType.OptionName,
                        AdditionalNeedsCost = anc.AdditionalNeedsCost,
                        CreatorId = anc.CreatorId,
                        UpdatorId = anc.UpdaterId
                    }),
                    NursingCore = nc.NursingCareBrokerageInfo.NursingCore,
                    StageId = nc.StageId,
                    SupplierId = nc.SupplierId,
                    CreatorId = nc.CreatorId,
                    UpdatorId = nc.UpdaterId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (!nursingCarePackage.NursingCareAdditionalNeedsCosts.Any())
            {
                var nursingCareAdditionalNeedsCosts = await _databaseContext.NursingCareAdditionalNeeds
                    .Where(nc => nc.NursingCarePackageId.Equals(nursingCarePackageId))
                    .Select(an => new NursingCareAdditionalNeedsCostDomain()
                    {
                        AdditionalNeedsPaymentTypeId = an.AdditionalNeedsPaymentTypeId,
                        AdditionalNeedsPaymentTypeName = an.AdditionalNeedsPaymentType.OptionName,
                        AdditionalNeedsCost = 0,
                    })
                    .ToListAsync()
                    .ConfigureAwait(false);

                nursingCarePackage.NursingCareAdditionalNeedsCosts = nursingCareAdditionalNeedsCosts;
            }

            if (nursingCarePackage == null)
            {
                throw new EntityNotFoundException($"Could not find the Nursing Care Package {nursingCarePackageId}");
            }

            return nursingCarePackage;
        }

        public async Task<bool> SetStage(Guid nursingCarePackageId, int stageId)
        {
            var nursingPackage = await _databaseContext.NursingCarePackages
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageId)
                .ConfigureAwait(false);

            if (nursingPackage == null)
            {
                throw new EntityNotFoundException($"Couldn't find nursing care package {nursingCarePackageId.ToString()}");
            }

            if (nursingPackage.StageId == stageId) return false;

            nursingPackage.StageId = stageId;
            if (PackageStageConstants.BrokerageAssignedId == stageId)
                nursingPackage.AssignedUserId = _identityHelperUseCase.GetUserId();
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for nursing care package stage {nursingCarePackageId} failed");
            }
        }
    }
}
