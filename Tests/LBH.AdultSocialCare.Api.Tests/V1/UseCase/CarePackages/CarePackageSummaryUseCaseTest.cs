using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.TestFramework.Extensions;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class CarePackageSummaryUseCaseTest : BaseTest
    {
        private readonly CarePackage _package;
        private readonly GetCarePackageSummaryUseCase _useCase;

        private readonly DateTime _startDate = DateTime.Now.AddDays(-30);
        private readonly DateTime _endDate = DateTime.Now.AddDays(10);

        public CarePackageSummaryUseCaseTest()
        {
            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.NursingCare,
                PackageScheduling = PackageScheduling.Temporary,
                Supplier = new Supplier(),
                ServiceUser = new ServiceUser(),
                Settings = new CarePackageSettings()
            };

            var gateway = new Mock<ICarePackageGateway>();
            gateway
                .Setup(m => m.GetPackageAsync(_package.Id, PackageFields.All, false))
                .ReturnsAsync(_package);

            _useCase = new GetCarePackageSummaryUseCase(gateway.Object);
        }

        [Theory]
        [InlineData(ReclaimType.Fnc, ClaimCollector.Supplier, 100)] // core + FNC - FNC
        [InlineData(ReclaimType.Fnc, ClaimCollector.Hackney, 120)] // core + FNC, no FNC deduction for Hackney
        [InlineData(ReclaimType.CareCharge, ClaimCollector.Supplier, 80)]
        [InlineData(ReclaimType.CareCharge, ClaimCollector.Hackney, 100)]
        public async Task ShouldConsiderReclaimCollector(ReclaimType reclaimType, ClaimCollector collector, decimal totalWeeklyCost)
        {
            AddCoreCost(100);
            AddReclaim(20, reclaimType, collector);

            var summary = await _useCase.ExecuteAsync(_package.Id);

            summary.TotalWeeklyCost.Should().Be(totalWeeklyCost);
        }

        [Fact]
        public async Task ShouldConsiderAdditionalNeedCostPeriod()
        {
            AddCoreCost(100.0m);
            AddAdditionalNeed(20.0m, PaymentPeriod.Weekly);
            AddAdditionalNeed(20.0m, PaymentPeriod.Weekly);
            AddAdditionalNeed(30.0m, PaymentPeriod.OneOff);
            AddAdditionalNeed(30.0m, PaymentPeriod.OneOff);

            var summary = await _useCase.ExecuteAsync(_package.Id);

            summary.TotalWeeklyCost.Should().Be(140.0m);
            summary.OneOffCost.Should().Be(60.0m);
        }

        [Theory]
        //          FNC                    | CareCharge            | Hackney & Supplier sub totals
        [InlineData(ClaimCollector.Hackney, ClaimCollector.Supplier, -10, -80)]
        [InlineData(ClaimCollector.Hackney, ClaimCollector.Hackney, -90, 0)]
        [InlineData(ClaimCollector.Supplier, ClaimCollector.Hackney, -80, -10)]
        [InlineData(ClaimCollector.Supplier, ClaimCollector.Supplier, 0, -90)]
        public async Task ShouldFillReclaimsSubTotals(
            ClaimCollector fncCollector, ClaimCollector careChargesCollector, decimal hackneySubTotal, decimal supplierSubTotal)
        {
            AddCoreCost(100.0m);
            AddReclaim(10.0m, ReclaimType.Fnc, fncCollector);
            AddReclaim(30.0m, ReclaimType.CareCharge, careChargesCollector);
            AddReclaim(50.0m, ReclaimType.CareCharge, careChargesCollector);

            var summary = await _useCase.ExecuteAsync(_package.Id);

            summary.HackneyReclaims?.SubTotal.Should().Be(hackneySubTotal);
            summary.SupplierReclaims?.SubTotal.Should().Be(supplierSubTotal);
        }

        [Fact]
        public void ShouldFailOnMissingPackage()
        {
            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(Guid.NewGuid()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);
        }

        private void AddCoreCost(decimal coreCost)
        {
            _package.Details.Add(new CarePackageDetail
            {
                Cost = coreCost,
                Type = PackageDetailType.CoreCost,
                StartDate = _startDate,
                EndDate = _endDate
            });
        }

        private void AddReclaim(decimal cost, ReclaimType type, ClaimCollector collector)
        {
            var reclaim = new CarePackageReclaim
            {
                Cost = cost,
                Type = type,
                SubType = type is ReclaimType.Fnc
                    ? ReclaimSubType.FncPayment
                    : ReclaimSubType.CareChargeProvisional,
                ClaimCollector = collector,
                StartDate = _startDate,
                EndDate = _endDate,
                Status = ReclaimStatus.Active
            };

            _package.Reclaims.Add(reclaim);

            if (type is ReclaimType.Fnc)
            {
                var fncReclaim = reclaim.DeepCopy();

                fncReclaim.Cost = Decimal.Negate(reclaim.Cost);
                fncReclaim.SubType = ReclaimSubType.FncReclaim;

                _package.Reclaims.Add(fncReclaim);
            }
        }

        private void AddAdditionalNeed(decimal cost, PaymentPeriod period)
        {
            _package.Details.Add(new CarePackageDetail
            {
                Cost = cost,
                Type = PackageDetailType.AdditionalNeed,
                CostPeriod = period,
                StartDate = _startDate,
                EndDate = _endDate
            });
        }
    }
}
