using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CareChargesGateway : ICareChargesGateway
    {
        private readonly DatabaseContext _dbContext;

        public CareChargesGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProvisionalCareChargeAmountPlainDomain> GetUsingServiceUserIdAsync(Guid serviceUserId)
        {
            // Get client age
            var clientBirthDate = await _dbContext.Clients.Where(c => c.Id.Equals(serviceUserId)).Select(c => c.DateOfBirth)
                .SingleOrDefaultAsync().ConfigureAwait(false);
            if (clientBirthDate == null)
            {
                throw new ApiException($"Service user with Id {serviceUserId} not found");
            }

            var clientAge = clientBirthDate.GetAge(DateTime.Now);
            var todayDate = DateTimeOffset.Now.Date;

            // Use age to get provisional amount range
            var provisionalAmount = await _dbContext.ProvisionalCareChargeAmounts
                .Where(pca => (clientAge >= pca.AgeFrom && clientAge <= pca.AgeTo) &&
                              (todayDate >= EF.Property<DateTime>(pca, nameof(pca.StartDate)).Date &&
                               (pca.EndDate == null || todayDate <= EF.Property<DateTime>(pca, nameof(pca.EndDate)).Date)))
                .OrderBy(pca => pca.StartDate)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return provisionalAmount?.ToDomain();
        }

        public async Task<IEnumerable<CareChargeElementPlainDomain>> CreateCareChargeElementsAsync(IEnumerable<CareChargeElementPlainDomain> elementDomains)
        {
            var newElements = new List<CareChargeElement>();

            await using var transaction = await _dbContext.Database.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                foreach (var domain in elementDomains)
                {
                    var element = domain.ToEntity();
                    newElements.Add(element);

                    _dbContext.CareChargeElements.Add(element);
                }

                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                await transaction.CommitAsync().ConfigureAwait(false);

                return newElements.ToPlainDomain();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                throw new DbSaveFailedException("Saving care charge element failed", ex);
            }
        }
    }
}
