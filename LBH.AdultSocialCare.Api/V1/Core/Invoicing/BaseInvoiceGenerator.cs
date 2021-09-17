using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing
{
    public abstract class BaseInvoiceGenerator
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;
        private readonly ITransactionManager _transactionManager;
        private readonly ICareChargesGateway _careChargesGateway;

        protected BaseInvoiceGenerator(
            ITransactionsService transactionsService, IIdentityHelperUseCase identityHelperUseCase,
            ITransactionManager transactionManager, ICareChargesGateway careChargesGateway)
        {
            _transactionsService = transactionsService;
            _identityHelperUseCase = identityHelperUseCase;
            _transactionManager = transactionManager;
            _careChargesGateway = careChargesGateway;
        }

        protected int PackageTypeId { get; set; }

        protected List<BaseInvoiceItemsGenerator> Generators { get; set; }

        protected abstract Task<List<Guid>> GetUnpaidPackageIds(DateTimeOffset invoiceEndDate);

        protected abstract Task<List<GenericPackage>> GetUnpaidPackagesByIds(List<Guid> packageIds);

        protected abstract Task RefreshPackagesPaidUpToDate(List<GenericPackage> packages, DateTimeOffset invoiceEndDate);

        public async Task GenerateUpTo(DateTimeOffset invoiceEndDate)
        {
            InitializeGenerators();

            invoiceEndDate = Dates.Min(invoiceEndDate, DateTimeOffset.Now.Date);

            // Generate invoices in batches, for up to 1000 packages per batch
            var packageIds = await GetUnpaidPackageIds(invoiceEndDate).ConfigureAwait(false);
            var iterations = Math.Ceiling(packageIds.Count / 1000M);

            for (var i = 0; i < iterations; i++)
            {
                var affectedPackages = new List<GenericPackage>();
                var invoices = new List<InvoiceForCreationRequest>();

                // Get nursing care packages in range
                var selectedIds = packageIds.Skip(i * 1000).Take(1000);
                var packages = await GetUnpaidPackagesByIds(selectedIds.ToList()).ConfigureAwait(false);

                foreach (var package in packages)
                {
                    var invoiceStartDate = package.PaidUpTo ?? package.StartDate;
                    var daysCount = (invoiceEndDate.Date - invoiceStartDate.Date).Days;

                    if (daysCount <= 0) continue;

                    invoices.Add(GenerateInvoice(invoiceEndDate, invoiceStartDate, package));

                    affectedPackages.Add(package);
                }

                await _transactionsService.BatchCreateInvoicesUseCase(invoices).ConfigureAwait(false);
                await UpdateInvoicingStateAsync(invoiceEndDate, affectedPackages).ConfigureAwait(false);
            }
        }

        private async void InitializeGenerators()
        {
            foreach (var generator in Generators)
            {
                await generator.Initialize().ConfigureAwait(false);
            }
        }

        private InvoiceForCreationRequest GenerateInvoice(DateTimeOffset invoiceEndDate, DateTimeOffset invoiceStartDate, GenericPackage package)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();

            foreach (var generator in Generators)
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
                PackageTypeId = PackageTypeId,
                ServiceUserId = package.ClientId,
                CreatorId = _identityHelperUseCase.GetUserId(),
                DateFrom = invoiceStartDate.Date,
                DateTo = invoiceEndDate,
                PackageId = package.Id,
                InvoiceItems = invoiceItems
            };
        }

        private async Task UpdateInvoicingStateAsync(DateTimeOffset invoiceEndDate, List<GenericPackage> affectedPackages)
        {
            await using var transaction = await _transactionManager.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                await RefreshPackagesPaidUpToDate(affectedPackages, invoiceEndDate).ConfigureAwait(false);

                foreach (var generator in Generators)
                {
                    await generator.OnInvoiceBatchGenerated(invoiceEndDate).ConfigureAwait(false);
                }

                await transaction.CommitAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                throw;
            }
        }

        protected async Task FillCareCharges(IEnumerable<Guid> ids, IEnumerable<GenericPackage> genericPackages)
        {
            var careCharges = await _careChargesGateway.GetCareChargesAsync(ids).ConfigureAwait(false);

            // TODO: VK: Workaround to be removed after all packages are be in same table
            var packageDictionary = genericPackages.ToDictionary(package => package.Id);

            foreach (var careCharge in careCharges)
            {
                if (packageDictionary.ContainsKey(careCharge.PackageId))
                {
                    packageDictionary[careCharge.PackageId].CareCharge = careCharge;
                }
            }
        }
    }
}
