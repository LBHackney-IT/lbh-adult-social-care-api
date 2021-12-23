using System;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;
using LBH.AdultSocialCare.Functions.Payruns.Tests.Dsl;
using LBH.AdultSocialCare.Functions.Payruns.Tests.Extensions;
using Xunit;

namespace LBH.AdultSocialCare.Functions.Payruns.Tests.Services.InvoiceItemGenerators
{
    public class CarePackageDetailOneOffGeneratorTests
    {
        private readonly CarePackage _package;
        private readonly CarePackageDetailOneOffGenerator _generator;

        public CarePackageDetailOneOffGeneratorTests()
        {
            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                SupplierId = 1,
                PackageType = PackageType.NursingCare
            };

            _package.Details.Add(new CarePackageDetail
            {
                Id = Guid.NewGuid(),
                Cost = 100.0m,
                Type = PackageDetailType.CoreCost,
                CostPeriod = PaymentPeriod.OneOff,
                StartDate = "01-12-2022".ToUtcDate(),
                EndDate = "31-12-2022".ToUtcDate(),
                Package = _package
            });

            _generator = new CarePackageDetailOneOffGenerator();
        }

        #region Normal invoices

        [Fact]
        public void ShouldCreateInvoice()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .VerifyLastInvoice((100.0m, "01-12-2022", "31-12-2022")); // since one off is created one time use it's range, not invoice range
        }

        [Fact]
        public void ShouldCreateJustOneInvoiceForEntireRange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("06-12-2022")
                .VerifyLastInvoice((100.0m, "01-12-2022", "31-12-2022"))
                .CreateInvoice("31-01-2022")
                .EnsureNoInvoiceGenerated(); // one-off has been created already
        }

        [Fact]
        public void ShouldConsiderRejectedInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("06-12-2022")
                .Reject()
                .CreateInvoice("31-01-2023")
                .VerifyLastInvoice((100.0m, "01-12-2022", "31-12-2022"));
        }

        [Fact]
        public void ShouldSkipFuturePayments()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("30-11-2022")
                .EnsureNoInvoiceGenerated();
        }

        [Fact]
        public void ShouldCreateInvoiceWhenEndDateWithinPayrunPeriod()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("31-01-2023")
                .VerifyLastInvoice((100.0m, "01-12-2022", "31-12-2022"));
        }

        #endregion Normal invoices

        #region Refunds

        [Fact]
        public void ShouldCreateRefundOnPriceChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("06-12-2022")
                .Pay()
                .UpdateDetail(d => d.Cost = 60.0m)
                .CreateRefund()
                .VerifyLastInvoice((-40.0m, "01-12-2022", "31-12-2022")); // price decrease - overpaid
        }

        [Fact]
        public void ShouldSkipRefundWhenUpdatedStartDateStillInPaidRange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("06-12-2022")
                .Pay()
                .UpdateDetail(d => d.StartDate = "06-12-2022".ToUtcDate())
                .CreateRefund()
                .EnsureNoInvoiceGenerated();
        }

        [Fact]
        public void ShouldCreateRefundWhenMovingIntoFuture()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("06-12-2022")
                .Pay()
                .UpdateDetail(d => d.StartDate = "01-01-2023".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-100.0m, "01-12-2022", "31-12-2022"));
        }

        [Fact]
        public void ShouldCreateSequentialRefunds()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("06-12-2022")
                .Pay()
                .UpdateDetail(d => d.Cost = 75.0m)
                .CreateRefund()
                .VerifyLastInvoice((-25.0m, "01-12-2022", "31-12-2022")) // cost decrease - overpaid
                .Pay()
                .UpdateDetail(d => d.Cost = 140.0m)
                .CreateRefund()
                .VerifyLastInvoice((65.0m, "01-12-2022", "31-12-2022")); // cost increase - underpaid
        }

        #endregion Refunds

        #region Ongoing one-off

        [Fact]
        public void ShouldCreateOneDayInvoiceForOngoingOneOff()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("06-12-2022")
                .VerifyLastInvoice((100.0m, "01-12-2022", "01-12-2022"));
        }

        [Fact]
        public void ShouldCreateSingleOneOffInvoiceForSequentialPeriods()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("06-12-2022")
                .Pay()
                .CreateInvoice("12-12-2022")
                .EnsureNoInvoiceGenerated();
        }

        [Fact]
        public void ShouldRefundOneOffWhenStartDateMovedBeforePaidRangeStart()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("06-12-2022")
                .Pay()
                .UpdateDetail(d => d.StartDate = "29-11-2022".ToUtcDate())
                .UpdateDetail(d => d.Cost = 300.0m)
                .CreateRefund()
                .VerifyLastInvoice(
                    (300.0m, "29-11-2022", "29-11-2022"),   // new payment
                    (-100.0m, "01-12-2022", "01-12-2022")); // refund previous one
        }

        [Fact]
        public void ShouldSkipRefundWhenFiniteBecomeOngoing()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("07-12-2022")
                .Pay()
                .UpdateDetail(d => d.EndDate = null)
                .CreateRefund()
                .EnsureNoInvoiceGenerated();
        }

        #endregion Ongoing one-off
    }
}
