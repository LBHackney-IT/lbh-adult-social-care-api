using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete
{
    public class FundedNursingCareGateway : IFundedNursingCaseGateway
    {
        private readonly DatabaseContext _context;

        public FundedNursingCareGateway(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<FundedNursingCareDomain> UpsertFundedNursingCase(FundedNursingCareDomain fundedNursingCareDomain)
        {
            var fundedCareToUpdate = await FindFundedNursingCare(fundedNursingCareDomain.NursingCarePackageId)
                .ConfigureAwait(false);

            if (fundedCareToUpdate is null)
            {
                var newFundedNursingCare = await _context.FundedNursingCares
                    .AddAsync(fundedNursingCareDomain.ToEntity())
                    .ConfigureAwait(false);

                return newFundedNursingCare.Entity.ToDomain();
            }

            fundedCareToUpdate.CollectorId = fundedNursingCareDomain.CollectorId;
            fundedCareToUpdate.ReclaimTargetInstitutionId = fundedNursingCareDomain.ReclaimTargetInstitutionId;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return fundedCareToUpdate.ToDomain();
        }

        public async Task<bool> DeleteFundedNursingCare(Guid packageId)
        {
            var fundedCare = await FindFundedNursingCare(packageId).ConfigureAwait(false);
            var rowsAffected = 0;

            if (fundedCare != null)
            {
                _context.Remove(fundedCare);
                rowsAffected = await _context.SaveChangesAsync().ConfigureAwait(false);
            }

            return rowsAffected > 1;
        }

        public async Task<decimal> GetFundedNursingCarePrice(DateTimeOffset date)
        {
            var price = await GetFundedNursingCarePriceFromDb(date).ConfigureAwait(false);
            return price?.PricePerWeek ?? 0;
        }

        public async Task<FundedNursingCarePriceDomain> GetFundedNursingCarePricing(DateTimeOffset dateTime)
        {
            var fncPrice = await GetFundedNursingCarePriceFromDb(dateTime).ConfigureAwait(false);
            return fncPrice?.ToDomain();
        }

        public async Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricingInRange(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var fncPrices = await _context.FundedNursingCarePrices
                .Where(cp => cp.ActiveFrom.Date >= startDate.Date && cp.ActiveTo.Date >= endDate.Date).ToListAsync()
                .ConfigureAwait(false);
            return fncPrices.ToDomain();
        }

        public async Task<FundedNursingCareDomain> GetPackageFundedNursingCare(Guid nursingCarePackageId)
        {
            var fundedNursingCare = await FindFundedNursingCare(nursingCarePackageId).ConfigureAwait(false);
            return fundedNursingCare?.ToDomain();
        }

        private async Task<FundedNursingCare> FindFundedNursingCare(Guid packageId)
        {
            return await _context.FundedNursingCares
                .Where(care => care.NursingCarePackageId == packageId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        private async Task<FundedNursingCarePrice> GetFundedNursingCarePriceFromDb(DateTimeOffset date)
        {
            try
            {
                return await _context.FundedNursingCarePrices
                    .Where(price => price.ActiveFrom <= date && (price.ActiveTo == null || price.ActiveTo >= date))
                    .SingleOrDefaultAsync()
                    .ConfigureAwait(false);
            }
            catch (InvalidOperationException)
            {
                // throw new ApiException($"No FNC price defined for {date.Date}", (int) HttpStatusCode.NotFound);
                return null;
            }
        }
    }
}
