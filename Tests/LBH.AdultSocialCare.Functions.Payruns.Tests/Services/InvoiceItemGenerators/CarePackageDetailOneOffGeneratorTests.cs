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
                StartDate = "2022-12-01".ToUtcDate(),
                EndDate = "2022-12-31".ToUtcDate(),
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
                .CreateInvoice("2022-12-07")
                .VerifyLastInvoice((100.0m, "2022-12-01", "2022-12-31")); // since one off is created one time use it's range, not invoice range
        }

        [Fact]
        public void ShouldCreateJustOneInvoiceForEntireRange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-06")
                .VerifyLastInvoice((100.0m, "2022-12-01", "2022-12-31"))
                .CreateInvoice("2022-01-31")
                .EnsureNoInvoiceGenerated(); // one-off has been created already
        }

        [Fact]
        public void ShouldConsiderRejectedInvoices()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-06")
                .Reject()
                .CreateInvoice("2023-01-31")
                .VerifyLastInvoice((100.0m, "2022-12-01", "2022-12-31"));
        }

        [Fact]
        public void ShouldSkipFuturePayments()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-11-30")
                .EnsureNoInvoiceGenerated();
        }

        [Fact]
        public void ShouldCreateInvoiceWhenEndDateWithinPayrunPeriod()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2023-01-31")
                .VerifyLastInvoice((100.0m, "2022-12-01", "2022-12-31"));
        }

        #endregion Normal invoices

        #region Refunds

        [Fact]
        public void ShouldCreateRefundOnPriceChange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-06")
                .Pay()
                .UpdateDetail(d => d.Cost = 60.0m)
                .CreateRefund()
                .VerifyLastInvoice((-40.0m, "2022-12-01", "2022-12-31")); // price decrease - overpaid
        }

        [Fact]
        public void ShouldSkipRefundWhenUpdatedStartDateStillInPaidRange()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-06")
                .Pay()
                .UpdateDetail(d => d.StartDate = "2022-12-06".ToUtcDate())
                .CreateRefund()
                .EnsureNoInvoiceGenerated();
        }

        [Fact]
        public void ShouldCreateRefundWhenMovingIntoFuture()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-06")
                .Pay()
                .UpdateDetail(d => d.StartDate = "2023-01-01".ToUtcDate())
                .CreateRefund()
                .VerifyLastInvoice((-100.0m, "2022-12-01", "2022-12-31"));
        }

        [Fact]
        public void ShouldCreateSequentialRefunds()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-06")
                .Pay()
                .UpdateDetail(d => d.Cost = 75.0m)
                .CreateRefund()
                .VerifyLastInvoice((-25.0m, "2022-12-01", "2022-12-31")) // cost decrease - overpaid
                .Pay()
                .UpdateDetail(d => d.Cost = 140.0m)
                .CreateRefund()
                .VerifyLastInvoice((65.0m, "2022-12-01", "2022-12-31")); // cost increase - underpaid
        }

        #endregion Refunds

        #region Ongoing one-off

        [Fact]
        public void ShouldCreateOneDayInvoiceForOngoingOneOff()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("2022-12-06")
                .VerifyLastInvoice((100.0m, "2022-12-01", "2022-12-01"));
        }

        [Fact]
        public void ShouldCreateSingleOneOffInvoiceForSequentialPeriods()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("2022-12-06")
                .Pay()
                .CreateInvoice("2022-12-12")
                .EnsureNoInvoiceGenerated();
        }

        [Fact]
        public void ShouldRefundOneOffWhenStartDateMovedBeforePaidRangeStart()
        {
            PaymentExperiment
                .For(_package, _generator)
                .UpdateDetail(d => d.EndDate = null)
                .CreateInvoice("2022-12-06")
                .Pay()
                .UpdateDetail(d => d.StartDate = "2022-11-29".ToUtcDate())
                .UpdateDetail(d => d.Cost = 300.0m)
                .CreateRefund()
                .VerifyLastInvoice(
                    (300.0m, "2022-11-29", "2022-11-29"),   // new payment
                    (-100.0m, "2022-12-01", "2022-12-01")); // refund previous one
        }

        [Fact]
        public void ShouldSkipRefundWhenFiniteBecomeOngoing()
        {
            PaymentExperiment
                .For(_package, _generator)
                .CreateInvoice("2022-12-07")
                .Pay()
                .UpdateDetail(d => d.EndDate = null)
                .CreateRefund()
                .EnsureNoInvoiceGenerated();
        }

        #endregion Ongoing one-off
    }
}
