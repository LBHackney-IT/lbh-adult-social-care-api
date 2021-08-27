using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Profiles;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.NursingCare
{
    public class FundedNursingCarePriceGatewayTests
    {
        public FundedNursingCarePriceGatewayTests()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();
            DomainToEntityFactory.Configure(mapper);
            EntityToDomainFactory.Configure(mapper);
        }

        [Fact]
        public async Task ShouldReturnCorrectFncPriceForBoundedRange()
        {
            await using var context = DatabaseFactory.GetInMemoryDatabase();
            var gateway = new FundedNursingCareGateway(context);

            var activeFrom = DateTimeOffset.Now;
            var activeTo = activeFrom.AddDays(365);
            var currentDate = activeFrom.AddDays(15);
            var price = 123.45m;

            context.FundedNursingCarePrices.Add(new FundedNursingCarePrice
            {
                Id = 1,
                ActiveFrom = activeFrom,
                ActiveTo = activeTo,
                PricePerWeek = price
            });
            context.SaveChanges();

            var result = await gateway.GetFundedNursingCarePriceAsync(currentDate).ConfigureAwait(false);

            Assert.Equal(result, price);
        }

        [Fact]
        public async Task ShouldReturnZeroWhenNoPriceIsDefined()
        {
            await using var context = DatabaseFactory.GetInMemoryDatabase();
            var gateway = new FundedNursingCareGateway(context);

            var result = await gateway.GetFundedNursingCarePriceAsync(DateTimeOffset.Now).ConfigureAwait(false);

            Assert.Equal(0, result);
            // Task GetPrice() => gateway.GetFundedNursingCarePriceAsync(DateTimeOffset.Now);
            //
            // var exception = await Assert.ThrowsAsync<ApiException>(GetPrice).ConfigureAwait(false);
            // Assert.Equal(404, exception?.StatusCode);
        }

        [Fact]
        public async Task ShouldCreateNewFundedNursingCareIfNoRecordsExists()
        {
            await using var context = DatabaseFactory.GetInMemoryDatabase();
            var gateway = new FundedNursingCareGateway(context);

            var fnc = new FundedNursingCareDomain
            {
                CollectorId = 1,
                ReclaimTargetInstitutionId = 2,
                NursingCarePackageId = Guid.NewGuid()
            };

            await gateway.UpsertFundedNursingCaseAsync(fnc).ConfigureAwait(false);
            var records = await context.FundedNursingCares.ToListAsync().ConfigureAwait(false);

            Assert.Single(records);
            Assert.Equal(fnc.NursingCarePackageId, records[0].NursingCarePackageId);
            Assert.Equal(fnc.CollectorId, records[0].CollectorId);
            Assert.Equal(fnc.ReclaimTargetInstitutionId, records[0].ReclaimTargetInstitutionId);
        }

        [Fact]
        public async Task ShouldUpdateExistingFundedNursingCare()
        {
            await using var context = DatabaseFactory.GetInMemoryDatabase();
            var gateway = new FundedNursingCareGateway(context);

            var packageId = Guid.NewGuid();
            var originalFnc = CreateFundedNursingCareDomain(packageId, 2, 1);
            var fncToUpdate = CreateFundedNursingCareDomain(packageId, 1, 2);

            context.FundedNursingCares.Add(originalFnc.ToEntity());
            context.SaveChanges();

            await gateway.UpsertFundedNursingCaseAsync(fncToUpdate).ConfigureAwait(false);
            var records = await context.FundedNursingCares.ToListAsync().ConfigureAwait(false);

            Assert.Single(records);
            Assert.Equal(fncToUpdate.NursingCarePackageId, records[0].NursingCarePackageId);
            Assert.Equal(fncToUpdate.CollectorId, records[0].CollectorId);
            Assert.Equal(fncToUpdate.ReclaimTargetInstitutionId, records[0].ReclaimTargetInstitutionId);
        }

        [Fact]
        public async Task ShouldNotFailOnRemovingMissingFundedNursingCare()
        {
            await using var context = DatabaseFactory.GetInMemoryDatabase();
            var gateway = new FundedNursingCareGateway(context);

            var result = await gateway.DeleteFundedNursingCareAsync(Guid.Empty).ConfigureAwait(false);

            Assert.False(result);
        }

        [Fact]
        public async Task ShouldRemoveGivenFundedNursingCare()
        {
            await using var context = DatabaseFactory.GetInMemoryDatabase();
            var gateway = new FundedNursingCareGateway(context);

            var packageToRemoveId = Guid.NewGuid();

            context.FundedNursingCares.Add(CreateFundedNursingCareDomain(Guid.NewGuid(), 1, 1).ToEntity());
            context.FundedNursingCares.Add(CreateFundedNursingCareDomain(packageToRemoveId, 2, 1).ToEntity());
            context.FundedNursingCares.Add(CreateFundedNursingCareDomain(Guid.NewGuid(), 2, 2).ToEntity());
            context.SaveChanges();

            var result = await gateway.DeleteFundedNursingCareAsync(packageToRemoveId).ConfigureAwait(false);

            Assert.True(result);
            Assert.Equal(2, context.FundedNursingCares.Count());
            Assert.Null(context.FundedNursingCares.FirstOrDefault(c => c.NursingCarePackageId == packageToRemoveId));
        }

        private static FundedNursingCareDomain CreateFundedNursingCareDomain(Guid packageId, int collectorId, int reclaimTargetInstitutionId)
        {
            return new FundedNursingCareDomain
            {
                CollectorId = collectorId,
                ReclaimTargetInstitutionId = reclaimTargetInstitutionId,
                NursingCarePackageId = packageId
            };
        }
    }
}
