using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;
using LBH.AdultSocialCare.TestFramework.Extensions;

namespace LBH.AdultSocialCare.Functions.Payruns.Tests.Dsl
{
    public class PaymentExperiment
    {
        private readonly CarePackage _package;
        private readonly BaseInvoiceItemsGenerator _generator;

        private InvoiceDomain _lastInvoice;
        private readonly List<InvoiceDomain> _invoices = new List<InvoiceDomain>();

        private PaymentExperiment(CarePackage package, BaseInvoiceItemsGenerator generator)
        {
            _package = package;
            _generator = generator;
        }

        public static PaymentExperiment For(CarePackage package, BaseInvoiceItemsGenerator generator)
        {
            return new PaymentExperiment(package, generator);
        }

        public PaymentExperiment CreateInvoice(string endDate)
        {
            CreateInvoice(endDate.ToUtcDate());
            return this;
        }

        public PaymentExperiment CreateInvoice(DateTimeOffset endDate)
        {
            CreateInvoice(_generator.CreateNormalItems(_package, _invoices, endDate));
            return this;
        }

        public PaymentExperiment CreateRefund()
        {
            CreateInvoice(_generator.CreateRefundItems(_package, _invoices));
            return this;
        }

        public PaymentExperiment UpdateReclaim(Action<CarePackageReclaim> action)
        {
            return UpdateReclaim(_package.Reclaims.First().Id, action);
        }

        public PaymentExperiment UpdateReclaim(Guid id, Action<CarePackageReclaim> action)
        {
            var reclaim = _package.Reclaims.First(r => r.Id == id);

            action(reclaim);
            reclaim.Version += 1;

            return this;
        }

        public PaymentExperiment UpdateDetail(Action<CarePackageDetail> action)
        {
            action(_package.Details.First());
            _package.Details.First().Version += 1;

            return this;
        }

        public PaymentExperiment Reject()
        {
            _invoices.Last().PayrunInvoice.InvoiceStatus = InvoiceStatus.Rejected;
            return this;
        }

        public PaymentExperiment Pay()
        {
            foreach (var invoice in _invoices.Where(invoice => invoice.Status is InvoiceStatus.Accepted))
            {
                invoice.PayrunStatus = PayrunStatus.Paid;
            }

            return this;
        }

        public PaymentExperiment VerifyLastInvoice(params (decimal Cost, string StartDate, string EndDate)[] expectations)
        {
            return VerifyLastInvoice(expectations.Select(e => (
                e.Cost,
                e.StartDate.ToUtcDate(),
                e.EndDate.ToUtcDate())).ToArray());
        }

        public PaymentExperiment VerifyLastInvoice(params (decimal Cost, DateTimeOffset StartDate, DateTimeOffset EndDate)[] expectations)
        {
            _lastInvoice.Items.Count.Should().Be(expectations.Length);

            foreach (var (cost, startDate, endDate) in expectations)
            {
                _lastInvoice.Items.Should().ContainSingle(item =>
                    item.TotalCost == cost &&
                    item.FromDate == startDate &&
                    item.ToDate == endDate);
            }

            return this;
        }

        public PaymentExperiment EnsureNoInvoiceGenerated()
        {
            _lastInvoice.Items.Count.Should().Be(0);
            return this;
        }

        private void CreateInvoice(IEnumerable<InvoiceItem> items)
        {
            var invoice = new InvoiceDomain
            {
                Items = items.ToList(),
                PackageId = _package.Id,
                PayrunStatus = PayrunStatus.WaitingForReview,
                PayrunInvoice = new PayrunInvoice
                {
                    InvoiceStatus = InvoiceStatus.Accepted
                }
            };

            _invoices.Add(invoice);
            _lastInvoice = invoice;
        }
    }
}
