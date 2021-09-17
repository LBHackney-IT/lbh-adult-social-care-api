using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Core.Invoicing.InvoiceItemGenerators
{
    public class CareChargeGeneratorTests
    {
        private readonly CareChargeGenerator _generator;

        public CareChargeGeneratorTests()
        {
            _generator = new CareChargeGenerator(Mock.Of<ICareChargesGateway>());
        }

        [Fact]
        public void ShouldConsiderOnlyActiveElements()
        {
            var elementStatuses = Enum.GetValues(typeof(CareChargeElementStatusEnum));
            var package = CreatePackage(elementStatuses.Length);

            for (var i = 0; i < elementStatuses.Length; i++)
            {
                package.CareCharge.CareChargeElements.ElementAt(i).StatusId = (int) elementStatuses.GetValue(i);
            }

            var invoiceItems = _generator.Run(package, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now.AddDays(30)).ToList();
            var activeElement = package.CareCharge.CareChargeElements.First(el => el.StatusId == (int) CareChargeElementStatusEnum.Active);

            invoiceItems.Count.Should().Be(1);
            invoiceItems.First().PricePerUnit.Should().Be(activeElement.Amount);
        }

        [Fact]
        public void ShouldConsiderElementsDateRange()
        {
            var package = CreatePackage(5);

            var pastElement = package.CareCharge.CareChargeElements.First();
            var futureElement = package.CareCharge.CareChargeElements.Last();

            pastElement.StartDate = DateTimeOffset.Now.AddDays(-365);
            pastElement.EndDate = DateTimeOffset.Now.AddDays(-265);
            futureElement.StartDate = DateTimeOffset.Now.AddDays(265);
            futureElement.EndDate = DateTimeOffset.Now.AddDays(365);

            var invoiceItems = _generator.Run(package, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now.AddDays(30)).ToList();

            invoiceItems.Count.Should().Be(package.CareCharge.CareChargeElements.Count - 2);
            invoiceItems.Should().NotContain(el => el.PricePerUnit == pastElement.Amount);
            invoiceItems.Should().NotContain(el => el.PricePerUnit == futureElement.Amount);
        }

        [Fact]
        public void ShouldNotCreateInvoiceItemsWithoutCareCharge()
        {
            var package = new GenericPackage();

            var invoices = _generator.Run(package, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now.AddDays(30));

            invoices.Count().Should().Be(0);
        }

        [Theory]
        [InlineData(PackageCostClaimersConstants.Hackney, PriceEffect.None)]
        [InlineData(PackageCostClaimersConstants.Supplier, PriceEffect.Subtract)]
        public void ShouldSetCorrectPriceEffectWhenCollectedByHackney(int claimCollectorId, string priceEffect)
        {
            var package = CreatePackage(1);

            package.CareCharge.CareChargeElements.First().ClaimCollector.Id = claimCollectorId;

            var invoiceItems = _generator.Run(package, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now.AddDays(30)).ToList();

            invoiceItems.Count.Should().Be(1);
            invoiceItems.First().PriceEffect.Should().Be(priceEffect);
        }

        private static GenericPackage CreatePackage(int careChargeElementsCount)
        {
            var package = new GenericPackage
            {
                CareCharge = new PackageCareCharge
                {
                    CareChargeElements = new List<CareChargeElement>()
                }
            };

            for (var i = 0; i < careChargeElementsCount; i++)
            {
                package.CareCharge.CareChargeElements.Add(new CareChargeElement
                {
                    Amount = 1.23m * (i + 1),
                    StatusId = (int) CareChargeElementStatusEnum.Active,
                    StartDate = DateTimeOffset.Now.AddDays(-10),
                    EndDate = DateTimeOffset.Now.AddDays(10),
                    CareChargeType = new CareChargeType
                    {
                        Id = (int) CareChargeElementTypeEnum.WithoutPropertyOneToTwelveWeeks,
                        OptionName = CareChargeElementTypeEnum.WithoutPropertyOneToTwelveWeeks.GetDisplayName()
                    },
                    ClaimCollector = new PackageCostClaimer
                    {
                        Id = PackageCostClaimersConstants.Hackney
                    }
                });
            }

            return package;
        }
    }
}
