using System;
using System.Linq;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;
using LBH.AdultSocialCare.Functions.Payruns.Tests.Dsl;
using LBH.AdultSocialCare.TestFramework.Extensions;
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
                StartDate = "01-12-2022".ToUtcDate(),
                EndDate = "31-12-2022".ToUtcDate(),
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
                .CreateInvoice("03-12-2022")
                .VerifyLastInvoice((300.0m, "01-12-2022", "03-12-2022"));
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
                .UpdateDetail(d => d.StartDate = "04-12-2022".ToUtcDate())
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

        #endregion Normal finite weekly needs


        #region Refunds for finite details

        [Fact]
        public void ShouldCreateRefundOnPriceChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.Cost = 400.0m)
                .CreateRefund() // compensate overpaid 300
                .VerifyLastInvoice((-300.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundOnStartDateChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.StartDate = "02-12-2022".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-100.0m, "01-12-2022", "07-12-2022")); // use original invoice range
        }

        [Fact]
        public void ShouldCreateRefundOnEndDateChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.EndDate = "06-12-2022".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-100.0m, "01-12-2022", "07-12-2022")); // use original invoice range
        }

        [Fact]
        public void ShouldCreateRefundOnCostAndDatesChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.StartDate = "02-12-2022".ToUtcDate())
                .UpdateDetail(d => d.EndDate = "06-12-2022".ToUtcDate())
                .UpdateDetail(d => d.Cost = 350.0m)
                .CreateRefund() // paid 100 per day for 7 days, now pay 50 per day for 5 days
                .VerifyLastInvoice((-450.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateRefundsWhenMovingIntoPast()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.StartDate = "30-11-2022".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((100.0m, "30-11-2022", "30-11-2022"));
        }

        [Fact]
        public void ShouldCreateRefundWhenMovingIntoFuture()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.StartDate = "01-01-2023".ToUtcDate())
                .CreateRefund()
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
                .UpdateDetail(d => d.Cost = 400.0m)
                .CreateRefund()
                .VerifyLastInvoice(
                    (-300.0m, "01-12-2022", "07-12-2022"),
                    (-300.0m, "08-12-2022", "14-12-2022"));
        }

        [Fact]
        public void ShouldCreateSequentialRefunds()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(r => r.Cost = 400.0m)
                .CreateRefund() // paid 700 - overpaid, compensate 300
                .Pay()
                .UpdateDetail(r => r.Cost = 150.0m)
                .CreateRefund() // paid 400 - overpaid, compensate 250
                .VerifyLastInvoice((-250.0m, "01-12-2022", "07-12-2022"))
                .Pay()
                .UpdateDetail(r => r.Cost = 850.0m)
                .CreateRefund() // paid 150 - underpaid, pay extra 700
                .VerifyLastInvoice((700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldSkipRefundForMigratedItemsBeforeFirstPayrunStart()
        {
            _package.Details.First().StartDate = PayrunConstants.DefaultStartDate.AddDays(-100);

            var invoiceStartDate = PayrunConstants.DefaultStartDate;
            var invoiceEndDate = PayrunConstants.DefaultStartDate.AddDays(6);

            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice(invoiceEndDate)
                .VerifyLastInvoice((700.0m, invoiceStartDate, invoiceEndDate))
                .Pay()
                .UpdateDetail(d => d.Cost = 500.0m)
                .CreateRefund() // just one refund is expected, period before first payrun date is unpaid in our system but should be ignored
                .VerifyLastInvoice((-200.0m, invoiceStartDate, invoiceEndDate));
        }

        #endregion Refunds for finite details

        #region Ongoing weekly needs

        [Fact]
        public void ShouldCreateInvoiceForOngoingWeeklyNeed()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("07-12-2022")
                .VerifyLastInvoice((700.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldCreateInvoicesForSequentialPeriods()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
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
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.EndDate = "05-12-2022".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-200.0m, "01-12-2022", "07-12-2022"));
        }

        [Fact]
        public void ShouldSkipRefundWhenFiniteBecomesOngoing()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = "05-12-2022".ToUtcDate())
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.EndDate = null)
                .CreateRefund()
                .EnsureNoInvoiceGenerated(); // difference will be paid with next normal invoice
        }

        #endregion Ongoing weekly needs
    }
}
