using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators;

namespace LBH.AdultSocialCare.Functions.Payruns.Services
{
    public class InvoiceGenerator
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IFundedNursingCareGateway _fundedNursingCareGateway;

        private Dictionary<PackageType, List<BaseInvoiceItemsGenerator>> _generators;

        public InvoiceGenerator(
            ICarePackageGateway carePackageGateway, IFundedNursingCareGateway fundedNursingCareGateway)
        {
            _carePackageGateway = carePackageGateway;
            _fundedNursingCareGateway = fundedNursingCareGateway;
        }

        public async Task<IList<Invoice>> GenerateAsync(IList<CarePackage> packages, DateTimeOffset invoiceEndDate)
        {
            await InitializeGeneratorsAsync();

            var invoices = new List<Invoice>();
            var invoicesCount = await _carePackageGateway.GetInvoicesCountAsync(); // TODO: VK: Review invoice numbering

            foreach (var package in packages)
            {
                var coreCost = package.Details.First(d => d.Type is PackageDetailType.CoreCost);

                // TODO: VK: Review and remove
                var invoiceStartDate = /* package.PaidUpTo ?? */ coreCost.StartDate;
                var daysCount = (invoiceEndDate.Date - invoiceStartDate.Date).Days;

                if (daysCount <= 0) continue;

                invoices.Add(GenerateInvoice(invoiceEndDate, invoiceStartDate, package, ref invoicesCount));
            }

            return invoices;
        }

        private Invoice GenerateInvoice(DateTimeOffset invoiceEndDate, DateTimeOffset invoiceStartDate, CarePackage package, ref int invoiceNumber)
        {
            var invoiceItems = new List<InvoiceItem>();
            var generators = _generators[package.PackageType];

            foreach (var generator in generators)
            {
                invoiceItems.AddRange(generator.Run(package, invoiceStartDate, invoiceEndDate));
            }

            return new Invoice
            {
                SupplierId = package.SupplierId.GetValueOrDefault(),
                ServiceUserId = package.ServiceUserId,
                PackageId = package.Id,
                Items = invoiceItems,
                TotalCost = CalculateTotalCost(invoiceItems),
                Number = $"INV {++invoiceNumber}"
            };
        }

        private static decimal CalculateTotalCost(List<InvoiceItem> invoiceItems)
        {
            var totalCost = 0.0m;

            foreach (var invoiceItem in invoiceItems)
            {
                switch (invoiceItem.PriceEffect)
                {
                    case PriceEffect.Add:
                        totalCost += invoiceItem.TotalCost;
                        break;

                    case PriceEffect.Subtract:
                        totalCost -= invoiceItem.TotalCost;
                        break;
                }
            }

            return totalCost;
        }

        private async Task InitializeGeneratorsAsync()
        {
            _generators = new Dictionary<PackageType, List<BaseInvoiceItemsGenerator>>
            {
                {
                    PackageType.ResidentialCare, new List<BaseInvoiceItemsGenerator>
                    {
                        new CoreCostGenerator(),
                        new AdditionalNeedsCostGenerator(),
                        new FundedNursingCareGenerator(_fundedNursingCareGateway),
                        new CareChargeGenerator()
                    }
                },
                {
                    PackageType.NursingCare, new List<BaseInvoiceItemsGenerator>
                    {
                        new CoreCostGenerator(),
                        new AdditionalNeedsCostGenerator(),
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
