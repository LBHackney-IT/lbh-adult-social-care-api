using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Concrete
{
    public class ResidentialCareBrokerageGateway : IResidentialCareBrokerageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public ResidentialCareBrokerageGateway(DatabaseContext databaseContext, IIdentityHelperUseCase identityHelperUseCase)
        {
            _databaseContext = databaseContext;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<ResidentialCareBrokerageInfoDomain> CreateAsync(ResidentialCareBrokerageInfo residentialCareBrokerageInfo)
        {
            var entry = await _databaseContext.ResidentialCareBrokerageInfos.AddAsync(residentialCareBrokerageInfo).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity.ToDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Could not save residential brokerage to database: {ex.InnerException?.Message}", ex);
            }
        }

        public async Task<ResidentialCareBrokerageInfoDomain> GetAsync(Guid residentialCarePackageId)
        {
            var residentialCarePackage = await _databaseContext.ResidentialCarePackages
                .Where(nc => nc.Id.Equals(residentialCarePackageId))
                .Select(nc => new ResidentialCareBrokerageInfoDomain
                {
                    ResidentialCareBrokerageId = nc.ResidentialCareBrokerageInfo.Id,
                    ResidentialCarePackageId = nc.Id,
                    ResidentialCarePackage = new ResidentialCarePackageDomain
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
                        TypeOfResidentialCareHomeId = nc.TypeOfResidentialCareHomeId,
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
                        PackageName = PackageTypesConstants.ResidentialCarePackage,
                        TypeOfCareHomeName = nc.TypeOfCareHome.TypeOfCareHomeName,
                        TypeOfStayOptionName = nc.TypeOfStayOption.OptionName,
                        ResidentialCareAdditionalNeeds = nc.ResidentialCareAdditionalNeeds.Select(an => new ResidentialCareAdditionalNeedsDomain
                        {
                            Id = an.Id,
                            ResidentialCarePackageId = an.ResidentialCarePackageId,
                            AdditionalNeedsPaymentTypeId = an.AdditionalNeedsPaymentTypeId,
                            AdditionalNeedsPaymentTypeName = an.AdditionalNeedsPaymentType.OptionName,
                            NeedToAddress = an.NeedToAddress,
                            CreatorId = an.CreatorId,
                            UpdatorId = an.UpdaterId
                        })
                    },
                    ResidentialCareAdditionalNeedsCosts = nc.ResidentialCareBrokerageInfo.ResidentialCareAdditionalNeedsCosts.Select(anc => new ResidentialCareAdditionalNeedsCostDomain
                    {
                        ResidentialCareBrokerageId = anc.ResidentialCareBrokerageId,
                        AdditionalNeedsPaymentTypeId = anc.AdditionalNeedsPaymentTypeId,
                        AdditionalNeedsPaymentTypeName = anc.AdditionalNeedsPaymentType.OptionName,
                        AdditionalNeedsCost = anc.AdditionalNeedsCost
                    }),
                    ResidentialCore = nc.ResidentialCareBrokerageInfo.ResidentialCore,
                    StageId = nc.StageId,
                    HasCareCharges = nc.ResidentialCareBrokerageInfo.HasCareCharges,
                    SupplierId = nc.SupplierId,
                    CreatorId = nc.CreatorId,
                    UpdatorId = nc.UpdaterId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (!residentialCarePackage.ResidentialCareAdditionalNeedsCosts.Any())
            {
                var residentialCareAdditionalNeedsCosts = await _databaseContext.ResidentialCareAdditionalNeeds
                    .Where(nc => nc.ResidentialCarePackageId.Equals(residentialCarePackageId))
                    .Select(an => new ResidentialCareAdditionalNeedsCostDomain()
                    {
                        AdditionalNeedsPaymentTypeId = an.AdditionalNeedsPaymentTypeId,
                        AdditionalNeedsPaymentTypeName = an.AdditionalNeedsPaymentType.OptionName,
                        AdditionalNeedsCost = 0,
                    })
                    .ToListAsync()
                    .ConfigureAwait(false);

                residentialCarePackage.ResidentialCareAdditionalNeedsCosts = residentialCareAdditionalNeedsCosts;
            }

            if (residentialCarePackage == null)
            {
                throw new EntityNotFoundException($"Could not find the Residential Care Package {residentialCarePackageId}");
            }

            return residentialCarePackage;
        }

        public async Task<bool> SetStage(Guid residentialCarePackageId, int stageId)
        {
            var residentialPackage = await _databaseContext.ResidentialCarePackages
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackageId)
                .ConfigureAwait(false);

            if (residentialPackage == null)
            {
                throw new EntityNotFoundException($"Couldn't find residential care package {residentialCarePackageId.ToString()}");
            }

            if (residentialPackage.StageId == stageId) return false;

            residentialPackage.StageId = stageId;
            if (PackageStageConstants.BrokerageAssignedId == stageId)
                residentialPackage.AssignedUserId = _identityHelperUseCase.GetUserId();
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for residential care package stage {residentialCarePackageId} failed");
            }
        }
    }
}
