using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;

namespace LBH.AdultSocialCare.Functions.Payruns.Services
{
    public class InvoiceGenerator
    {
        private readonly IInvoiceGateway _invoiceGateway;
        private readonly IFundedNursingCareGateway _fundedNursingCareGateway;

        private Dictionary<PackageType, List<BaseInvoiceItemsGenerator>> _generators;

        public InvoiceGenerator(
            IInvoiceGateway invoiceGateway, IFundedNursingCareGateway fundedNursingCareGateway)
        {
            _invoiceGateway = invoiceGateway;
            _fundedNursingCareGateway = fundedNursingCareGateway;
        }

        public async Task<IList<Invoice>> GenerateAsync(IList<CarePackage> packages, DateTimeOffset invoiceEndDate, InvoiceTypes invoiceTypes)
        {
            await InitializeGeneratorsAsync();

            var invoices = new List<Invoice>();
            var packageIds = packages
                .Select(package => package.Id)
                .ToList();

            var invoicesCount = await _invoiceGateway.GetInvoicesCountAsync();
            var oldInvoices = await _invoiceGateway.GetInvoicesByPackageIds(packageIds);

            foreach (var package in packages)
            {
                var packageInvoices = oldInvoices.GetValueOrDefault(package.Id) ?? new List<InvoiceDomain>();

                invoices.Add(GenerateInvoice(
                    package, packageInvoices,
                    invoiceEndDate, invoiceTypes, ref invoicesCount));
            }

            return invoices;
        }

        private Invoice GenerateInvoice(
            CarePackage package, IList<InvoiceDomain> packageInvoices,
            DateTimeOffset invoiceEndDate, InvoiceTypes invoiceTypes, ref int invoiceNumber)
        {
            var invoiceItems = new List<InvoiceItem>();
            var generators = _generators[package.PackageType];

            foreach (var generator in generators)
            {
                if (invoiceTypes.HasFlag(InvoiceTypes.Normal))
                {
                    invoiceItems.AddRange(generator.CreateNormalItem(package, packageInvoices, invoiceEndDate));
                }

                if (invoiceTypes.HasFlag(InvoiceTypes.Refund))
                {
                    invoiceItems.AddRange(generator.CreateRefundItem(package, packageInvoices));
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
                TotalCost = totals.Net,             // TODO: VK: Review, remove
                Number = $"INV {++invoiceNumber}"
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

        private async Task InitializeGeneratorsAsync()
        {
            _generators = new Dictionary<PackageType, List<BaseInvoiceItemsGenerator>>
            {
                {
                    PackageType.NursingCare, new List<BaseInvoiceItemsGenerator>
                    {
                        new CarePackageDetailGenerator(),
                        new FundedNursingCareGenerator(_fundedNursingCareGateway),
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

            foreach (var generator in _generators.Values.SelectMany(generators => generators))
            {
                await generator.Initialize();
            }
        }
    }
}
