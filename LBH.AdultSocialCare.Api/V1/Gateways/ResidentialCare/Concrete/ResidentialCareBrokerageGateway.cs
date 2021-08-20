using System;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                throw new DbSaveFailedException("Could not save residential brokerage to database" + ex.Message);
            }
        }

        public async Task<ResidentialCareBrokerageInfoDomain> GetAsync(Guid residentialCarePackageId)
        {
            var residentialCarePackage = await _databaseContext.ResidentialCarePackages
                .Include(item => item.Client)
                .Include(item => item.Status)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .Include(item => item.ResidentialCareBrokerageInfo)
                .Include(item => item.Stage)
                .Include(item => item.Supplier)
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackageId).ConfigureAwait(false);

            if (residentialCarePackage == null)
            {
                throw new EntityNotFoundException($"Could not find the Residential Care Package {residentialCarePackageId}");
            }

            return new ResidentialCareBrokerageInfoDomain
            {
                Id = residentialCarePackage.ResidentialCareBrokerageInfo?.Id ?? Guid.Empty,
                ResidentialCarePackageId = residentialCarePackageId,
                ResidentialCarePackage = residentialCarePackage.ToDomain(),
                ResidentialCore = residentialCarePackage.ResidentialCareBrokerageInfo?.ResidentialCore ?? 0,
                AdditionalNeedsPayment = residentialCarePackage.ResidentialCareBrokerageInfo?.AdditionalNeedsPayment ?? 0,
                AdditionalNeedsPaymentOneOff = residentialCarePackage.ResidentialCareBrokerageInfo?.AdditionalNeedsPaymentOneOff ?? 0,
            };
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
