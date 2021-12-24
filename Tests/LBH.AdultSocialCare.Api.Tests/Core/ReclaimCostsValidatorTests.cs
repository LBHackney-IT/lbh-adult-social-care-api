using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Data.Constants.Enums;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.Core
{
    public class ReclaimCostsValidatorTests
    {
        [Fact]
        public void ShouldPassWhenReclaimsLessThanCosts()
        {
            var package = TestDataHelper
                .CreateCarePackage()
                .AddCoreCost(1000.0m, "01-12-2022", "31-12-2022")
                .AddWeeklyNeed(500.0m, "01-12-2022", "15-12-2022")
                .AddCareChargeProvisional(250.0m, ClaimCollector.Supplier, "01-12-2022", "31-12-2022")
                .SetCurrentDate("01-12-2022");

            FluentActions.Invoking(() =>
                ReclaimCostValidator.Validate(package)).Should().NotThrow();
        }

        [Fact]
        public void ShouldFailWhenReclaimsExceedsCoreCost()
        {
            var package = TestDataHelper
                .CreateCarePackage()
                .AddCoreCost(1000.0m, "01-12-2022", "31-12-2022")
                .AddCareChargeProvisional(2500.0m, ClaimCollector.Supplier, "01-12-2022", "31-12-2022")
                .SetCurrentDate("01-12-2022");

            FluentActions.Invoking(() =>
                ReclaimCostValidator.Validate(package)).Should().Throw<ApiException>();
        }

        [Fact]
        public void ShouldFailWhenReclaimsExceedsCoreCostAfterAdditionalNeedEnded()
        {
            var package = TestDataHelper
                .CreateCarePackage()
                .AddCoreCost(2000.0m, "01-12-2022", "31-12-2022")
                .AddWeeklyNeed(1000.0m, "01-12-2022", "15-12-2022")
                .AddCareChargeProvisional(2500.0m, ClaimCollector.Supplier, "01-12-2022", "31-12-2022")
                .SetCurrentDate("01-12-2022");

            FluentActions.Invoking(() =>
                ReclaimCostValidator.Validate(package)).Should().Throw<ApiException>();
        }
    }
}
