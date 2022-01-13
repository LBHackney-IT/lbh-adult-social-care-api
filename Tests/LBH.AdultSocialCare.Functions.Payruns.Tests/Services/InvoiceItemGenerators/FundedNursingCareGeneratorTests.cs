using System;
using System.Collections.Generic;
using System.Linq;
using FastDeepCloner;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;
using LBH.AdultSocialCare.Functions.Payruns.Tests.Dsl;
using LBH.AdultSocialCare.TestFramework;
using LBH.AdultSocialCare.TestFramework.Extensions;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Functions.Payruns.Tests.Services.InvoiceItemGenerators
{
    public class FundedNursingCareGeneratorTests
    {
        private readonly CarePackage _package;
        private readonly FundedNursingCareGenerator _generator;

        private readonly List<FundedNursingCarePrice> _fncPrices;

        public FundedNursingCareGeneratorTests()
        {
            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                SupplierId = 1,
                PackageType = PackageType.NursingCare
            };

            _package.Reclaims.Add(new CarePackageReclaim
            {
                Id = Guid.NewGuid(),
                Cost = 700.0m,
                Status = ReclaimStatus.Active,
                Type = ReclaimType.Fnc,
                SubType = ReclaimSubType.FncPayment,
                ClaimCollector = ClaimCollector.Supplier,
                StartDate = "01-12-2022".ToUtcDate(),
                EndDate = "31-12-2022".ToUtcDate(),
                Package = _package,
                CurrentDateProvider = new MockCurrentDateProvider { Now = "15-12-2022".ToUtcDate() }
            });

            _fncPrices = new List<FundedNursingCarePrice>
            {
                new FundedNursingCarePrice
                {
                    ActiveFrom = "01-01-2000".ToUtcDate(),
                    ActiveTo = "01-01-2200".ToUtcDate(),
                    PricePerWeek = 700.0m
                }
            };

            var fundedNursingCareGateway = new Mock<IFundedNursingCareGateway>();
            fundedNursingCareGateway
                .Setup(g => g.GetFundedNursingCarePricesAsync())
                .ReturnsAsync(_fncPrices);

            _generator = new FundedNursingCareGenerator(_fncPrices);
        }

        #region Normal finite FNC

        [Fact]
        public void ShouldCreateInvoice()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .VerifyLastInvoice((700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateSeparateInvoicesForAllFncRanges()
        {
            _fncPrices.First().ActiveTo = "07-12-2022".ToUtcDate();

            _fncPrices.Add(new FundedNursingCarePrice
            {
                ActiveFrom = "08-12-2022".ToUtcDate(),
                ActiveTo = "10-12-2022".ToUtcDate(),
                PricePerWeek = 350.0m
            });
            _fncPrices.Add(new FundedNursingCarePrice
            {
                ActiveFrom = "11-12-2022".ToUtcDate(),
                ActiveTo = "01-01-2200".ToUtcDate(),
                PricePerWeek = 175.0m
            });

            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("14-12-2022")
                .VerifyLastInvoice(
                    (700.0m, "01-12-2022", "07-12-2022"),
                    (150.0m, "08-12-2022", "10-12-2022"),
                    (100.0m, "11-12-2022", "14-12-2022"));
        }

        [Fact]
        public void ShouldConsiderExistingInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("03-12-2022")
                .CreateInvoice("04-12-2022")
                .VerifyLastInvoice((100.0m, "04-12-2022", "04-12-2022"));
        }

        [Fact]
        public void ShouldConsiderRejectedInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("03-12-2022")
                .Reject()
                .CreateInvoice("08-12-2022")
                .VerifyLastInvoice((800.0m, "01-12-2022", "08-12-2022"));
        }

        [Fact]
        public void ShouldSkipFuturePayments()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(d => d.StartDate = "04-12-2022".ToUtcDate())
                .CreateInvoice("03-12-2022")
                .EnsureNoInvoiceGenerated();
        }

        [Fact]
        public void ShouldCreateInvoiceWhenEndDateWithinPayrunPeriod()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("31-01-2023")
                .VerifyLastInvoice((3100.0m /* 4wk 3d */, "01-12-2022", "31-12-2022"));
        }

        [Fact]
        public void ShouldCreateInvoiceForPendingReclaimWithinInvoiceRange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(r => r.StartDate = "20-12-2022".ToUtcDate())
                .CreateInvoice("20-12-2022")
                .VerifyLastInvoice((100.0m, "20-12-2022", "20-12-2022"));
        }

        [Fact]
        public void ShouldCreateInvoiceForEndedReclaimWithinInvoiceRange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(r => r.EndDate = "01-12-2022".ToUtcDate())
                .CreateInvoice("07-12-2022")
                .VerifyLastInvoice((100.0m, "01-12-2022", "01-12-2022"));
        }

        [Fact]
        public void ShouldSkipInvoiceForCancelledReclaim()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(r => r.Status = ReclaimStatus.Cancelled)
                .CreateInvoice("07-12-2022")
                .EnsureNoInvoiceGenerated();
        }

        [Fact]
        public void ShouldHandleMultipleReclaims()
        {
            var newReclaim = _package.Reclaims.First().DeepCopy(CloneLevel.FirstLevelOnly);

            newReclaim.Cost = -700.0m;
            newReclaim.SubType = ReclaimSubType.FncReclaim;

            _package.Reclaims.Add(newReclaim);

            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("14-01-2023")
                .VerifyLastInvoice(
                    (3100.0m, "01-12-2022", "31-12-2022"),
                    (-3100.0m, "01-12-2022", "31-12-2022"));
        }

        [Fact]
        public void ShouldSkipHackneyFncReclaim()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(r => r.ClaimCollector = ClaimCollector.Hackney)
                .UpdateReclaim(r => r.SubType = ReclaimSubType.FncReclaim)
                .CreateInvoice("14-01-2023")
                .EnsureNoInvoiceGenerated();
        }

        #endregion Normal finite FNC

        #region Refunds for finite FNC

        [Fact]
        public void ShouldCreateRefundOnStartDateChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.StartDate = "02-12-2022".ToUtcDate())
                .CreateRefund() // paid for 7 days, now pay for 6 days -> return 100 from supplier, use original invoice range
                .VerifyLastInvoice((-100.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundOnEndDateChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(d => d.EndDate = "06-12-2022".ToUtcDate())
                .CreateRefund()
                // FNC payment - paid 100 per day for seven days, now pay 6 days, return 100 from supplier
                .VerifyLastInvoice((- 100.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundOnCostAndDatesChange()
        {
            var experiment = PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay();

            _fncPrices.First().PricePerWeek = 350.0m;

            experiment
                .UpdateReclaim(d => d.StartDate = "02-12-2022".ToUtcDate())
                .UpdateReclaim(d => d.EndDate = "06-12-2022".ToUtcDate())
                .CreateRefund() // paid 100 per day for 7 days, now pay 50 per day for 5 days - return 450 from supplier
                .VerifyLastInvoice((-450.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundsWhenMovingIntoPast()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.StartDate = "30-11-2022".ToUtcDate())
                .CreateRefund() // period is extended 1 day back, for FNC payment should pay 1 day more
                .VerifyLastInvoice((100.0m, "30-11-2022", "30-11-2022"));
        }

        [Fact]
        public void ShouldCreateRefundWhenMovingIntoFuture()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(d => d.StartDate = "01-01-2023".ToUtcDate())
                .CreateRefund() // no need to pay anything for FNC payment, return everything from supplier
                .VerifyLastInvoice((-700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundsForAllInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .CreateInvoice("14-12-2022")
                .Pay()
                .UpdateReclaim(r => r.StartDate = "15-12-2022".ToUtcDate())
                .CreateRefund() // moving forward, for FNC payment return everything from supplier
                .VerifyLastInvoice(
                    (-700.0m, "01-12-2022", "07-12-2022"),
                    (-700.0m, "08-12-2022", "14-12-2022"));
        }

        [Fact]
        public void ShouldCreateSequentialRefunds()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("14-12-2022")
                .Pay()
                .UpdateReclaim(r => r.StartDate = "02-12-2022".ToUtcDate())
                .CreateRefund() // pay one day less, return 100 from supplier
                .VerifyLastInvoice((-100.0m, "01-12-2022", "14-12-2022"))
                .Pay()
                .UpdateReclaim(r => r.StartDate = "04-12-2022".ToUtcDate())
                .CreateRefund() // pay two day less, return 200 from supplier
                .VerifyLastInvoice((-200.0m, "01-12-2022", "14-12-2022"))
                .Pay()
                .UpdateReclaim(r => r.StartDate = "01-12-2022".ToUtcDate())
                .CreateRefund() // bring back to supplier previously returned 100 and 300
                .VerifyLastInvoice((300.0m, "01-12-2022", "14-12-2022"));
        }

        [Fact]
        public void ShouldCreateValidRefundsAfterClaimCollectorSwitch()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("14-12-2022")
                .Pay()
                .UpdateReclaim(r => r.StartDate = "02-12-2022".ToUtcDate())
                .CreateRefund()
                .Pay()
                .UpdateReclaim(r => r.ClaimCollector = ClaimCollector.Hackney)
                .CreateRefund()
                .Pay()
                .UpdateReclaim(r => r.ClaimCollector = ClaimCollector.Supplier)
                .UpdateReclaim(r => r.StartDate = "05-12-2022".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((1000.0m, "01-12-2022", "14-12-2022"))
                .Pay()
                .UpdateReclaim(r => r.StartDate = "01-12-2022".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((400.0m, "01-12-2022", "14-12-2022"));
        }

        [Fact]
        public void ShouldRefundEverythingOnCancellation()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.Status = ReclaimStatus.Cancelled)
                .CreateRefund() // previous cost was paid, supplier was overpaid -> compensate all
                .VerifyLastInvoice((-700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact(Skip = "Review FNC payment refunds collected by Hackney ")]
        public void ShouldSkipRefundOnHackneyReclaimUpdates()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(r => r.ClaimCollector = ClaimCollector.Hackney)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.Cost = 500.0m)
                .CreateRefund()
                .EnsureNoInvoiceGenerated();
        }

        [Fact(Skip = "Review FNC payment refunds collected by Hackney ")]
        public void ShouldSkipRefundOnHackneyReclaimCancellation()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(r => r.ClaimCollector = ClaimCollector.Hackney)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.Status = ReclaimStatus.Cancelled)
                .CreateRefund()
                .EnsureNoInvoiceGenerated();
        }

        #endregion Refunds for finite FNC

        #region Ongoing FNC

        [Fact]
        public void ShouldCreateInvoiceForOngoingCareCharge()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(d => d.EndDate = null)
                .CreateInvoice("07-12-2022")
                .VerifyLastInvoice((700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateInvoicesForSequentialPeriods()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(d => d.EndDate = null)
                .CreateInvoice("07-12-2022")
                .CreateInvoice("14-12-2022")
                .VerifyLastInvoice((700.0m, "08-12-2022", "14-12-2022"))
                .CreateInvoice("14-10-2026")
                .VerifyLastInvoice((140000.0m, "15-12-2022", "14-10-2026"));
        }

        [Fact]
        public void ShouldCreateRefundWhenOngoingBecomesFinite()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(d => d.EndDate = null)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(d => d.EndDate = "05-12-2022".ToUtcDate())
                .CreateRefund() // paid 700, now should pay 500, supplier overpaid, return 200
                .VerifyLastInvoice((-200.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldSkipRefundWhenFiniteBecomesOngoing()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(d => d.EndDate = "05-12-2022".ToUtcDate())
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(d => d.EndDate = null)
                .CreateRefund()
                .EnsureNoInvoiceGenerated(); // difference will be paid with next normal invoice
        }

        #endregion Ongoing FNC
    }
}
