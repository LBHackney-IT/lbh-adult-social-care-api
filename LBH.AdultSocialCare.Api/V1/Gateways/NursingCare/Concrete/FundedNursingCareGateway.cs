using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                return await _context.FundedNursingCarePrices
                    .Where(price => price.ActiveFrom <= date && (price.ActiveTo == null || price.ActiveTo >= date))
                    .Select(price => price.PricePerWeek)
                    .SingleAsync()
                    .ConfigureAwait(false);
            }
            catch (InvalidOperationException)
            {
                throw new ApiException($"No FNC price defined for {date.Date}", (int) HttpStatusCode.NotFound);
            }
        }

        private async Task<FundedNursingCare> FindFundedNursingCare(Guid packageId)
        {
            return await _context.FundedNursingCares
                .Where(care => care.NursingCarePackageId == packageId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
