using System;
using System.Linq;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Core.Invoicing.InvoiceItemGenerators
{
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
            var elementStatuses = Enum.GetValues(typeof(ReclaimStatus));
            var package = CreatePackage(elementStatuses.Length);

            for (var i = 0; i < elementStatuses.Length; i++)
            {
                package.Reclaims.ElementAt(i).Status = (ReclaimStatus) i;
            }

            var invoiceItems = _generator.Run(package, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now.AddDays(30)).ToList();
            var activeElement = package.Reclaims.First(el => el.Status is ReclaimStatus.Active);

            invoiceItems.Count.Should().Be(1);
            invoiceItems.First().PricePerUnit.Should().Be(activeElement.Cost);
        }

        [Fact]
        public void ShouldConsiderReclaimDateRange()
        {
            var package = CreatePackage(5);

            var pastReclaim = package.Reclaims.First();
            var futureReclaim = package.Reclaims.Last();

            pastReclaim.StartDate = DateTimeOffset.Now.AddDays(-365);
            pastReclaim.EndDate = DateTimeOffset.Now.AddDays(-265);
            futureReclaim.StartDate = DateTimeOffset.Now.AddDays(265);
            futureReclaim.EndDate = DateTimeOffset.Now.AddDays(365);

            var invoiceItems = _generator.Run(package, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now.AddDays(30)).ToList();

            invoiceItems.Count.Should().Be(package.Reclaims.Count - 2);
            invoiceItems.Should().NotContain(el => el.PricePerUnit == pastReclaim.Cost);
            invoiceItems.Should().NotContain(el => el.PricePerUnit == futureReclaim.Cost);
        }

        [Fact]
        public void ShouldNotCreateInvoiceItemsWithoutCareCharge()
        {
            var package = new CarePackage();

            var invoices = _generator.Run(package, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now.AddDays(30));

            invoices.Count().Should().Be(0);
        }

        [Theory]
        [InlineData(ClaimCollector.Hackney, PriceEffect.None)]
        [InlineData(ClaimCollector.Supplier, PriceEffect.Subtract)]
        public void ShouldSetCorrectPriceEffectWhenCollectedByHackney(ClaimCollector collector, string priceEffect)
        {
            var package = CreatePackage(1);

            package.Reclaims.First().ClaimCollector = collector;

            var invoiceItems = _generator.Run(package, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now.AddDays(30)).ToList();

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
