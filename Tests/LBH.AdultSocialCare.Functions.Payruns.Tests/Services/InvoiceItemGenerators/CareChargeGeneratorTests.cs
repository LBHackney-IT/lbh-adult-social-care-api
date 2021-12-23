using System;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;
using LBH.AdultSocialCare.Functions.Payruns.Tests.Dsl;
using LBH.AdultSocialCare.Functions.Payruns.Tests.Extensions;
using LBH.AdultSocialCare.TestFramework;
using Xunit;

namespace LBH.AdultSocialCare.Functions.Payruns.Tests.Services.InvoiceItemGenerators
{
    public class CareChargeGeneratorTests
    {
        private readonly CarePackage _package;
        private readonly CareChargeGenerator _generator;

        public CareChargeGeneratorTests()
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
                Type = ReclaimType.CareCharge,
                ClaimCollector = ClaimCollector.Supplier,
                StartDate = "01-12-2022".ToUtcDate(),
                EndDate = "31-12-2022".ToUtcDate(),
                Package = _package,
                CurrentDateProvider = new MockCurrentDateProvider { Now = "15-12-2022".ToUtcDate() }
            });

            _generator = new CareChargeGenerator();
        }

        #region Normal finite care charges

        [Fact]
        public void ShouldCreateInvoice()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .VerifyLastInvoice((700.0m, "01-12-2022", "07-12-2022"));
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
        public void ShouldSkipHackneyCareCharges()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateReclaim(r => r.ClaimCollector = ClaimCollector.Hackney)
                .CreateInvoice("07-12-2022")
                .EnsureNoInvoiceGenerated();
        }

        #endregion Normal finite care charges

        #region Refunds for finite care charges

        [Fact]
        public void ShouldCreateRefundOnPriceChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.Cost = 400.0m)
                .CreateRefund() // deducted 700, now should deduct just 400 -> underpaid, add 300
                .VerifyLastInvoice((300.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundOnStartDateChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.StartDate = "02-12-2022".ToUtcDate())
                .CreateRefund() // deducted for 7 days, now deducted for 6 days -> refund 100, use original invoice range
                .VerifyLastInvoice((100.0m, "01-12-2022", "07-12-2022"));
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
                .VerifyLastInvoice((100.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundOnCostAndDatesChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(d => d.StartDate = "02-12-2022".ToUtcDate())
                .UpdateReclaim(d => d.EndDate = "06-12-2022".ToUtcDate())
                .UpdateReclaim(d => d.Cost = 350.0m)
                .CreateRefund() // paid 100 per day for 7 days, now pay 50 per day for 5 days
                .VerifyLastInvoice((450.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundsWhenMovingIntoPast()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.StartDate = "30-11-2022".ToUtcDate())
                .CreateRefund() // period is extended 1 day back, cost hasn't deducted -> supplier overpaid
                .VerifyLastInvoice((-100.0m, "30-11-2022", "30-11-2022"));
        }

        [Fact]
        public void ShouldCreateRefundWhenMovingIntoFuture()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(d => d.StartDate = "01-01-2023".ToUtcDate())
                .CreateRefund() // no cost should be deducted now, supplier underpaid - compensate
                .VerifyLastInvoice((700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundsForAllInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .CreateInvoice("14-12-2022")
                .Pay()
                .UpdateReclaim(r => r.Cost = 400.0m)
                .CreateRefund() // deducted 700, now should deduct just 400 -> underpaid, add 300 refund for each previous invoice
                .VerifyLastInvoice(
                    (300.0m, "01-12-2022", "07-12-2022"),
                    (300.0m, "08-12-2022", "14-12-2022"));
        }

        [Fact]
        public void ShouldCreateSequentialRefunds()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.Cost = 400.0m)
                .CreateRefund() // deducted 700, now should deduct 400 -> underpaid, add 300
                .Pay()
                .UpdateReclaim(r => r.Cost = 150.0m)
                .CreateRefund() // deducted 400, now should deduct 150 -> underpaid, add 250
                .VerifyLastInvoice((250.0m, "01-12-2022", "07-12-2022"))
                .Pay()
                .UpdateReclaim(r => r.Cost = 850.0m)
                .CreateRefund() // deducted 150, now should deduct 850 -> overpaid, return 700 from supplier
                .VerifyLastInvoice((-700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateValidRefundsAfterClaimCollectorSwitch()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.Cost = 400.0m)
                .CreateRefund()
                .Pay()
                .UpdateReclaim(r => r.ClaimCollector = ClaimCollector.Hackney)
                .CreateRefund()
                .Pay()
                .UpdateReclaim(r => r.ClaimCollector = ClaimCollector.Supplier)
                .UpdateReclaim(r => r.Cost = 125.0m)
                .CreateRefund()
                .VerifyLastInvoice((-125.0m, "01-12-2022", "07-12-2022"))
                .Pay()
                .UpdateReclaim(r => r.Cost = 150.0m)
                .CreateRefund()
                .VerifyLastInvoice((-25.0m, "01-12-2022", "07-12-2022"))
                .Pay()
                .UpdateReclaim(r => r.Cost = 100.0m)
                .CreateRefund()
                .VerifyLastInvoice((50.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldRefundEverythingOnCancellation()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateReclaim(r => r.Status = ReclaimStatus.Cancelled)
                .CreateRefund() // previous cost was deducted, so supplier was underpaid -> compensate all
                .VerifyLastInvoice((700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
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

        [Fact]
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

        #endregion Refunds for finite care charges

        #region Ongoing care charges

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
                .CreateRefund() // deducted 700, now should deduct 500, supplier underpaid
                .VerifyLastInvoice((200.0m, "01-12-2022", "07-12-2022"));
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

        #endregion
    }
}
