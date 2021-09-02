using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.NursingCare
{
    public class FundedNursingCarePriceGatewayTests : BaseInMemoryDatabaseTest
    {
        private FundedNursingCareGateway _gateway;

        public FundedNursingCarePriceGatewayTests()
        {
            _gateway = new FundedNursingCareGateway(Context);
        }

        [Fact]
        public async Task ShouldReturnCorrectFncPriceForBoundedRange()
        {
            var activeFrom = DateTimeOffset.Now;
            var activeTo = activeFrom.AddDays(365);
            var currentDate = activeFrom.AddDays(15);
            var price = 123.45m;

            Context.FundedNursingCarePrices.ClearData();
            Context.FundedNursingCarePrices.Add(new FundedNursingCarePrice
            {
                Id = 1,
                ActiveFrom = activeFrom,
                ActiveTo = activeTo,
                PricePerWeek = price
            });
            Context.SaveChanges();

            var result = await _gateway.GetFundedNursingCarePriceAsync(currentDate).ConfigureAwait(false);

            Assert.Equal(result, price);
        }

        [Fact]
        public async Task ShouldReturnZeroWhenNoPriceIsDefined()
        {
            Context.FundedNursingCarePrices.ClearData();
            Context.SaveChanges();

            var result = await _gateway
                .GetFundedNursingCarePriceAsync(DateTimeOffset.Now)
                .ConfigureAwait(false);

            Assert.Equal(0, result);
            // Task GetPrice() => gateway.GetFundedNursingCarePriceAsync(DateTimeOffset.Now);
            //
            // var exception = await Assert.ThrowsAsync<ApiException>(GetPrice).ConfigureAwait(false);
            // Assert.Equal(404, exception?.StatusCode);
        }

        [Fact]
        public async Task ShouldCreateNewFundedNursingCareIfNoRecordsExists()
        {
            var package = await new DataGenerator(Context).GenerateNursingCarePackage().ConfigureAwait(false);

            var fnc = new FundedNursingCareDomain
            {
                CollectorId = 1,
                ReclaimTargetInstitutionId = 2,
                NursingCarePackageId = package.Id
            };

            await _gateway.UpsertFundedNursingCaseAsync(fnc).ConfigureAwait(false);
            var records = await Context.FundedNursingCares.ToListAsync().ConfigureAwait(false);

            Assert.Single(records);
            Assert.Equal(fnc.NursingCarePackageId, records[0].NursingCarePackageId);
            Assert.Equal(fnc.CollectorId, records[0].CollectorId);
            Assert.Equal(fnc.ReclaimTargetInstitutionId, records[0].ReclaimTargetInstitutionId);
        }

        [Fact]
        public async Task ShouldUpdateExistingFundedNursingCare()
        {
            var package = await DataGenerator.GenerateNursingCarePackage().ConfigureAwait(false);

            var originalFnc = CreateFundedNursingCareDomain(package.Id, 2, 1);
            var fncToUpdate = CreateFundedNursingCareDomain(package.Id, 1, 2);

            Context.FundedNursingCares.Add(originalFnc.ToEntity());
            Context.SaveChanges();

            await _gateway.UpsertFundedNursingCaseAsync(fncToUpdate).ConfigureAwait(false);
            var records = await Context.FundedNursingCares.ToListAsync().ConfigureAwait(false);

            Assert.Single(records);
            Assert.Equal(fncToUpdate.NursingCarePackageId, records[0].NursingCarePackageId);
            Assert.Equal(fncToUpdate.CollectorId, records[0].CollectorId);
            Assert.Equal(fncToUpdate.ReclaimTargetInstitutionId, records[0].ReclaimTargetInstitutionId);
        }

        [Fact]
        public async Task ShouldNotFailOnRemovingMissingFundedNursingCare()
        {
            var result = await _gateway.DeleteFundedNursingCareAsync(Guid.Empty).ConfigureAwait(false);

            Assert.False(result);
        }

        [Fact]
        public async Task ShouldRemoveGivenFundedNursingCare()
        {
            var packages = await DataGenerator.GenerateNursingCarePackages(3).ConfigureAwait(false);

            Context.FundedNursingCares.Add(CreateFundedNursingCareDomain(packages[0].Id, 1, 1).ToEntity());
            Context.FundedNursingCares.Add(CreateFundedNursingCareDomain(packages[1].Id, 2, 1).ToEntity());
            Context.FundedNursingCares.Add(CreateFundedNursingCareDomain(packages[2].Id, 2, 2).ToEntity());
            Context.SaveChanges();

            var result = await _gateway.DeleteFundedNursingCareAsync(packages[1].Id).ConfigureAwait(false);

            Assert.True(result);
            Assert.Equal(2, Context.FundedNursingCares.Count());
            Assert.Null(Context.FundedNursingCares.FirstOrDefault(c => c.NursingCarePackageId == packages[1].Id));
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
