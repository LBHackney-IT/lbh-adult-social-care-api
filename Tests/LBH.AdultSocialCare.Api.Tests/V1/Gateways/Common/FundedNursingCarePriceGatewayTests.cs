using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.Common
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
    }
}
