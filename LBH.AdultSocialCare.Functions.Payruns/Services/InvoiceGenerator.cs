using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Extensions;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;

namespace LBH.AdultSocialCare.Functions.Payruns.Services
{
    public class InvoiceGenerator
    {
        private readonly IInvoiceGateway _invoiceGateway;
        private readonly IList<FundedNursingCarePrice> _fncPrices;

        private Dictionary<PackageType, List<BaseInvoiceItemsGenerator>> _generators;

        public InvoiceGenerator(IInvoiceGateway invoiceGateway, IList<FundedNursingCarePrice> fncPrices)
        {
            _invoiceGateway = invoiceGateway;
            _fncPrices = fncPrices;
        }

        public async Task<IList<Invoice>> GenerateAsync(IList<CarePackage> packages, DateTimeOffset invoiceEndDate, InvoiceTypes invoiceTypes, long lastInvoiceNumber)
        {
            InitializeGeneratorsAsync();

            var invoices = new List<Invoice>();
            var packageIds = packages
                .Select(package => package.Id)
                .ToList();

            var oldInvoices = await _invoiceGateway.GetInvoicesByPackageIds(packageIds);

            foreach (var package in packages)
            {
                var packageInvoices = oldInvoices.GetValueOrDefault(package.Id) ?? new List<InvoiceDomain>();

                invoices.Add(GenerateInvoice(
                    package, packageInvoices,
                    invoiceEndDate, invoiceTypes, ref lastInvoiceNumber));
            }

            return invoices;
        }

        private Invoice GenerateInvoice(
            CarePackage package, IList<InvoiceDomain> packageInvoices,
            DateTimeOffset invoiceEndDate, InvoiceTypes invoiceTypes, ref long lastInvoiceNumber)
        {
            var invoiceItems = new List<InvoiceItem>();
            var generators = _generators[package.PackageType];

            foreach (var generator in generators)
            {
                if (invoiceTypes.HasFlag(InvoiceTypes.Refund))
                {
                    RejectOutdatedInvoices(package, packageInvoices);

                    invoiceItems.AddRange(generator.CreateRefundItems(package, packageInvoices));
                }

                if (invoiceTypes.HasFlag(InvoiceTypes.Normal))
                {
                    invoiceItems.AddRange(generator.CreateNormalItems(package, packageInvoices, invoiceEndDate));
                }
            }

            var totals = CalculateTotals(invoiceItems);

            return new Invoice
            {
                SupplierId = package.SupplierId.GetValueOrDefault(),
                ServiceUserId = package.ServiceUserId,
                PackageId = package.Id,
                Items = invoiceItems,
                GrossTotal = totals.Gross,
                NetTotal = totals.Net,
                TotalCost = totals.Net, // TODO: VK: Review, remove?
                Number = $"INV-{DateTimeOffset.UtcNow:yyMMdd}-{++lastInvoiceNumber:0000}"
            };
        }

        private static (decimal Gross, decimal Net) CalculateTotals(List<InvoiceItem> invoiceItems)
        {
            var gross = 0.0m;
            var supplierReclaims = 0.0m;

            foreach (var item in invoiceItems)
            {
                switch (item.ClaimCollector)
                {
                    // Supplier reclaims deducted from gross giving a net price
                    case ClaimCollector.Supplier:
                        supplierReclaims += item.TotalCost;
                        break;

                    // Hackney reclaims do not affect totals
                    case ClaimCollector.Hackney:
                        break;

                    // Non-reclaim items compose gross price
                    case null:
                        gross += item.TotalCost;
                        break;
                }
            }

            var net = gross - supplierReclaims;
            return (gross, net);
        }

        private void RejectOutdatedInvoices(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            // there can be valid invoices but not yet paid.
            // After package change they become invalidated, thus rejected
            var packageItems = package.Details.Cast<IPackageItem>().Concat(package.Reclaims);
            var outdatedInvoices = new List<PayrunInvoice>();

            foreach (var packageItem in packageItems)
            {
                outdatedInvoices.AddRange(packageInvoices
                    .Where(invoice =>
                        invoice.Status.In(InvoiceStatus.Accepted, InvoiceStatus.Held) &&
                        invoice.PayrunStatus.In(PayrunStatus.WaitingForApproval, PayrunStatus.WaitingForReview) &&
                        invoice.Items.Any(item => packageItem.IsReferenced(item) && packageItem.Version > item.SourceVersion))
                    .Select(invoice => invoice.PayrunInvoice));
            }

            _invoiceGateway.RejectInvoices(outdatedInvoices);
        }

        private void InitializeGeneratorsAsync()
        {
            _generators = new Dictionary<PackageType, List<BaseInvoiceItemsGenerator>>
            {
                {
                    PackageType.NursingCare, new List<BaseInvoiceItemsGenerator>
                    {
                        new CarePackageDetailGenerator(),
                        new FundedNursingCareGenerator(_fncPrices),
                        new CareChargeGenerator()
                    }
                },
                {
                    PackageType.ResidentialCare, new List<BaseInvoiceItemsGenerator>
                    {
                        new CarePackageDetailGenerator(),
                        new CareChargeGenerator()
                    }
                }
            };
        }
    }
}
