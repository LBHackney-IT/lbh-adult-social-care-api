using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing
{
    public class InvoiceGenerator
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IFundedNursingCareGateway _fundedNursingCareGateway;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;
        private readonly IDatabaseManager _databaseManager;

        private Dictionary<PackageType, List<BaseInvoiceItemsGenerator>> _generators;

        public InvoiceGenerator(
            ITransactionsService transactionsService, ICarePackageGateway carePackageGateway,
            IFundedNursingCareGateway fundedNursingCareGateway, IIdentityHelperUseCase identityHelperUseCase, IDatabaseManager databaseManager)
        {
            _transactionsService = transactionsService;
            _carePackageGateway = carePackageGateway;
            _fundedNursingCareGateway = fundedNursingCareGateway;
            _identityHelperUseCase = identityHelperUseCase;
            _databaseManager = databaseManager;
        }

        public async Task GenerateUpTo(DateTimeOffset invoiceEndDate)
        {
            InitializeGenerators();

            invoiceEndDate = Dates.Min(invoiceEndDate, DateTimeOffset.Now.Date);

            // Generate invoices in batches, for up to 1000 packages per batch
            var packageIds = await GetUnpaidPackageIds(invoiceEndDate);
            var iterations = Math.Ceiling(packageIds.Count / 1000M);

            for (var i = 0; i < iterations; i++)
            {
                var invoices = new List<InvoiceForCreationRequest>();

                // Get nursing care packages in range
                var selectedIds = packageIds.Skip(i * 1000).Take(1000);
                var packages = await GetUnpaidPackagesByIds(selectedIds.ToList());

                foreach (var package in packages)
                {
                    var coreCost = package.Details.First(d => d.Type is PackageDetailType.CoreCost);

                    // TODO: VK: Add PaidUpTo fields - package or core cost
                    var invoiceStartDate = /* package.PaidUpTo ?? */ coreCost.StartDate;
                    var daysCount = (invoiceEndDate.Date - invoiceStartDate.Date).Days;

                    if (daysCount <= 0) continue;

                    invoices.Add(GenerateInvoice(invoiceEndDate, invoiceStartDate, package));

                    // TODO: VK: Add PaidUpTo fields - package or core cost
                    // package.PreviousPaidUpTo = package.PaidUpTo;
                    // package.PaidUpTo = paidUpTo;
                }

                await _transactionsService.BatchCreateInvoicesUseCase(invoices);
                await _databaseManager.SaveAsync();
            }
        }

        private InvoiceForCreationRequest GenerateInvoice(DateTimeOffset invoiceEndDate, DateTimeOffset invoiceStartDate, CarePackage package)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();
            var generators = _generators[package.PackageType];

            foreach (var generator in generators)
            {
                invoiceItems.AddRange(generator.Run(package, invoiceStartDate, invoiceEndDate));
            }

            foreach (var invoiceItem in invoiceItems)
            {
                invoiceItem.CreatorId = _identityHelperUseCase.GetUserId();
            }

            return new InvoiceForCreationRequest
            {
                SupplierId = package.SupplierId,
                PackageTypeId = (int) package.PackageType, // TODO: VK: TBD
                ServiceUserId = package.ServiceUserId,
                CreatorId = _identityHelperUseCase.GetUserId(),
                DateFrom = invoiceStartDate.Date,
                DateTo = invoiceEndDate,
                PackageId = package.Id,
                InvoiceItems = invoiceItems
            };
        }

        private async Task<List<Guid>> GetUnpaidPackageIds(DateTimeOffset invoiceEndDate)
        {
            return await _carePackageGateway.GetUnpaidPackageIdsAsync(invoiceEndDate);
        }

        private async Task<List<CarePackage>> GetUnpaidPackagesByIds(List<Guid> packageIds)
        {
            return await _carePackageGateway.GetByIdsAsync(packageIds, PackageFields.Details | PackageFields.Reclaims);
        }

        private async void InitializeGenerators()
        {
            _generators = new Dictionary<PackageType, List<BaseInvoiceItemsGenerator>>
            {
                {
                    PackageType.ResidentialCare, new List<BaseInvoiceItemsGenerator>
                    {
                        new CoreCostGenerator("Nursing Care Core Cost"),
                        new AdditionalNeedsCostGenerator(),
                        new FundedNursingCareGenerator(_fundedNursingCareGateway),
                        new CareChargeGenerator()
                    }
                },
                {
                    PackageType.NursingCare, new List<BaseInvoiceItemsGenerator>
                    {
                        new CoreCostGenerator("Nursing Care Core Cost"),
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
