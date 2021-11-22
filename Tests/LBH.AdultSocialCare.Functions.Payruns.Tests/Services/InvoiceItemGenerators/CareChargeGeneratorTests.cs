using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;
using Xunit;

namespace LBH.AdultSocialCare.Functions.Payruns.Tests.Services.InvoiceItemGenerators
{
    // TODO: VK: Review tests
    public class CareChargeGeneratorTests
    {
        private readonly CareChargeGenerator _generator;

        public CareChargeGeneratorTests()
        {
            _generator = new CareChargeGenerator();
        }

        [Fact]
        public void ShouldConsiderOnlyActiveElements()
        {
            var package = CreatePackage(4);

            package.Reclaims.ElementAt(0).Status = ReclaimStatus.Ended;
            package.Reclaims.ElementAt(1).Status = ReclaimStatus.Cancelled;
            package.Reclaims.ElementAt(2).StartDate = DateTimeOffset.Now.AddDays(1000);

            var invoiceItems = _generator.Run(package, new List<Invoice>(), DateTimeOffset.Now.AddDays(30)).ToList();
            var activeElement = package.Reclaims.First(el => el.Status is ReclaimStatus.Active);

            invoiceItems.Count.Should().Be(1);
            invoiceItems.First().WeeklyCost.Should().Be(activeElement.Cost);
        }

        [Fact(Skip = "Review")]
        public void ShouldConsiderReclaimDateRange()
        {
            var package = CreatePackage(5);

            var pastReclaim = package.Reclaims.First();
            var futureReclaim = package.Reclaims.Last();

            pastReclaim.StartDate = DateTimeOffset.Now.AddDays(-365);
            pastReclaim.EndDate = DateTimeOffset.Now.AddDays(-265);
            futureReclaim.StartDate = DateTimeOffset.Now.AddDays(265);
            futureReclaim.EndDate = DateTimeOffset.Now.AddDays(365);

            var invoiceItems = _generator.Run(package, new List<Invoice>(), DateTimeOffset.Now.AddDays(30)).ToList();

            invoiceItems.Count.Should().Be(package.Reclaims.Count - 2);
            invoiceItems.Should().NotContain(el => el.WeeklyCost == pastReclaim.Cost);
            invoiceItems.Should().NotContain(el => el.WeeklyCost == futureReclaim.Cost);
        }

        [Fact]
        public void ShouldNotCreateInvoiceItemsWithoutCareCharge()
        {
            var package = new CarePackage();

            var invoices = _generator.Run(package, new List<Invoice>(), DateTimeOffset.Now.AddDays(30));

            invoices.Count().Should().Be(0);
        }

        [Theory]
        [InlineData(ClaimCollector.Hackney, PriceEffect.None)]
        [InlineData(ClaimCollector.Supplier, PriceEffect.Subtract)]
        public void ShouldSetCorrectPriceEffectWhenCollectedByHackney(ClaimCollector collector, PriceEffect priceEffect)
        {
            var package = CreatePackage(1);

            package.Reclaims.First().ClaimCollector = collector;

            var invoiceItems = _generator.Run(package, new List<Invoice>(), DateTimeOffset.Now.AddDays(30)).ToList();

            invoiceItems.Count.Should().Be(1);
            invoiceItems.First().PriceEffect.Should().Be(priceEffect);
        }

        private static CarePackage CreatePackage(int reclaimsCount)
        {
            var package = new CarePackage();

            for (var i = 0; i < reclaimsCount; i++)
            {
                package.Reclaims.Add(new CarePackageReclaim
                {
                    Cost = 1.23m * (i + 1),
                    Status = ReclaimStatus.Active,
                    StartDate = DateTimeOffset.Now.AddDays(-10),
                    EndDate = DateTimeOffset.Now.AddDays(10),
                    Type = ReclaimType.CareCharge,
                    SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                    ClaimCollector = ClaimCollector.Hackney
                });
            }

            return package;
        }
    }
}
