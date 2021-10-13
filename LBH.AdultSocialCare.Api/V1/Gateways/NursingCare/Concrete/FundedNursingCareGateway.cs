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
    public class FundedNursingCareGateway : IFundedNursingCareGateway
    {
        private readonly DatabaseContext _context;

        public FundedNursingCareGateway(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetFundedNursingCarePriceAsync(DateTimeOffset date)
        {
            var price = await GetFundedNursingCarePriceFromDbAsync(date).ConfigureAwait(false);
            return price?.PricePerWeek ?? 0;
        }

        public async Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricesAsync()
        {
            var fncPrice = await _context.FundedNursingCarePrices
                .ToListAsync()
                .ConfigureAwait(false);

            return fncPrice?.ToDomain();
        }

        public async Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricingInRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var (minStartDate, minEndDate) = await GetMinPriceStartAndEndDateAsync(startDate, endDate).ConfigureAwait(false);
            var fncPrices = await _context.FundedNursingCarePrices
                .Where(cp =>
                    (_context.CompareDates(cp.ActiveFrom, minStartDate) == 1 ||
                     _context.CompareDates(cp.ActiveFrom, minStartDate) == 0) &&
                    (_context.CompareDates(minEndDate, cp.ActiveTo) == 1 ||
                     _context.CompareDates(minEndDate, cp.ActiveTo) == 0)).ToListAsync()
                .ConfigureAwait(false);
            return fncPrices.ToDomain();
        }

        private async Task<FundedNursingCarePrice> GetFundedNursingCarePriceFromDbAsync(DateTimeOffset date)
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

        private async Task<(DateTimeOffset, DateTimeOffset)> GetMinPriceStartAndEndDateAsync(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var startDates = await _context.FundedNursingCarePrices.Where(cp =>
                    (_context.CompareDates(cp.ActiveTo, startDate) == 1 ||
                     _context.CompareDates(cp.ActiveTo, startDate) == 0) &&
                    (_context.CompareDates(endDate, cp.ActiveFrom) == 1 ||
                     _context.CompareDates(endDate, cp.ActiveFrom) == 0))
                .OrderBy(cp => cp.ActiveFrom)
                .Take(2)
                .Select(cp => cp.ActiveFrom)
                .ToListAsync()
                .ConfigureAwait(false);

            var endDates = await _context.FundedNursingCarePrices.Where(cp =>
                    (_context.CompareDates(cp.ActiveTo, startDate) == 1 ||
                     _context.CompareDates(cp.ActiveTo, startDate) == 0) &&
                    (_context.CompareDates(endDate, cp.ActiveFrom) == 1 ||
                     _context.CompareDates(endDate, cp.ActiveFrom) == 0))
                .OrderByDescending(cp => cp.ActiveTo)
                .Take(2)
                .Select(cp => cp.ActiveTo)
                .ToListAsync()
                .ConfigureAwait(false);

            return (startDates.ToArray().Min(), endDates.ToArray().Max());
        }
    }
}
