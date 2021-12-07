using System;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;
using LBH.AdultSocialCare.Functions.Payruns.Tests.Dsl;
using LBH.AdultSocialCare.Functions.Payruns.Tests.Extensions;
using Xunit;

namespace LBH.AdultSocialCare.Functions.Payruns.Tests.Services.InvoiceItemGenerators
{
    public class CarePackageDetailGeneratorWeeklyTests
    {
        private readonly CarePackage _package;
        private readonly CarePackageDetailPeriodicalGenerator _generator;

        public CarePackageDetailGeneratorWeeklyTests()
        {
            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                SupplierId = 1,
                PackageType = PackageType.ResidentialCare
            };

            _package.Details.Add(new CarePackageDetail
            {
                Id = Guid.NewGuid(),
                Cost = 700.0m,
                Type = PackageDetailType.AdditionalNeed,
                CostPeriod = PaymentPeriod.Weekly,
                StartDate = "2022-12-01".ToUtcDate(),
                EndDate = "2022-12-31".ToUtcDate(),
                Package = _package
            });

            _generator = new CarePackageDetailPeriodicalGenerator();
        }

        #region Normal finite weekly needs

        [Fact]
        public void ShouldCreateInvoice()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-03")
                .VerifyLastInvoice((300.0m, "2022-12-01", "2022-12-03"));
        }

        [Fact]
        public void ShouldConsiderExistingInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-03")
                .CreateInvoice("2022-12-04")
                .VerifyLastInvoice((100.0m, "2022-12-04", "2022-12-04"));
        }

        [Fact]
        public void ShouldConsiderRejectedInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-03")
                .Reject()
                .CreateInvoice("2022-12-08")
                .VerifyLastInvoice((800.0m, "2022-12-01", "2022-12-08"));
        }

        [Fact]
        public void ShouldSkipFuturePayments()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.StartDate = "2022-12-04".ToUtcDate())
                .CreateInvoice("2022-12-03")
                .VerifyLastInvoice(/* none */);
        }

        [Fact]
        public void ShouldCreateInvoiceWhenEndDateWithinPayrunPeriod()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2023-01-31")
                .VerifyLastInvoice((3100.0m /* 4wk 3d */, "2022-12-01", "2022-12-31"));
        }

        #endregion Normal finite weekly needs

        #region Refunds for finite details

        [Fact]
        public void ShouldCreateRefundOnPriceChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.Cost = 400.0m)
                .CreateRefund() // compensate overpaid 300
                .VerifyLastInvoice((-300.0m, "2022-12-01", "2022-12-07"));
        }

        [Fact]
        public void ShouldCreateRefundOnStartDateChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.StartDate = "2022-12-02".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-100.0m, "2022-12-01", "2022-12-07")); // use original invoice range
        }

        [Fact]
        public void ShouldCreateRefundOnEndDateChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.EndDate = "2022-12-06".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-100.0m, "2022-12-01", "2022-12-07")); // use original invoice range
        }

        [Fact]
        public void ShouldCreateRefundOnCostAndDatesChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.StartDate = "2022-12-02".ToUtcDate())
                .UpdateDetail(d => d.EndDate = "2022-12-06".ToUtcDate())
                .UpdateDetail(d => d.Cost = 350.0m)
                .CreateRefund() // paid 100 per day for 7 days, now pay 50 per day for 5 days
                .VerifyLastInvoice((-450.0m, "2022-12-01", "2022-12-07"));
        }

        [Fact]
        public void ShouldCreateRefundsWhenMovingIntoPast()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.StartDate = "2022-11-30".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((100.0m, "2022-11-30", "2022-11-30"));
        }

        [Fact]
        public void ShouldCreateRefundWhenMovingIntoFuture()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.StartDate = "2023-01-01".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-700.0m, "2022-12-01", "2022-12-07"));
        }

        [Fact]
        public void ShouldCreateRefundsForAllInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .CreateInvoice("2022-12-14")
                .Pay()
                .UpdateDetail(d => d.Cost = 400.0m)
                .CreateRefund()
                .VerifyLastInvoice(
                    (-300.0m, "2022-12-01", "2022-12-07"),
                    (-300.0m, "2022-12-08", "2022-12-14"));
        }

        [Fact]
        public void ShouldCreateSequentialRefunds()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(r => r.Cost = 400.0m)
                .CreateRefund() // paid 700 - overpaid, compensate 300
                .Pay()
                .UpdateDetail(r => r.Cost = 150.0m)
                .CreateRefund() // paid 400 - overpaid, compensate 250
                .VerifyLastInvoice((-250.0m, "2022-12-01", "2022-12-07"))
                .Pay()
                .UpdateDetail(r => r.Cost = 850.0m)
                .CreateRefund() // paid 150 - underpaid, pay extra 700
                .VerifyLastInvoice((700.0m, "2022-12-01", "2022-12-07"));
        }

        #endregion Refunds for finite details

        #region Ongoing weekly needs

        [Fact]
        public void ShouldCreateInvoiceForOngoingWeeklyNeed()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("2022-12-07")
                .VerifyLastInvoice((700.0m, "2022-12-01", "2022-12-07"));
        }

        [Fact]
        public void ShouldCreateInvoicesForSequentialPeriods()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("2022-12-07")
                .CreateInvoice("2022-12-14")
                .VerifyLastInvoice((700.0m, "2022-12-08", "2022-12-14"))
                .CreateInvoice("2026-10-14")
                .VerifyLastInvoice((140000.0m, "2022-12-15", "2026-10-14"));
        }

        [Fact]
        public void ShouldCreateRefundWhenOngoingBecomesFinite()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.EndDate = "2022-12-05".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-200.0m, "2022-12-01", "2022-12-07"));
        }

        [Fact]
        public void ShouldSkipRefundWhenFiniteBecomesOngoing()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = "2022-12-05".ToUtcDate())
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.EndDate = null)
                .CreateRefund()
                .VerifyLastInvoice(/* none, difference will be paid with next normal invoice */);
        }

        #endregion Ongoing weekly needs
    }
}
