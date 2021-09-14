using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing.Generators;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing
{
    public class InvoiceGenerator
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public InvoiceGenerator(ITransactionsService transactionsService, IIdentityHelperUseCase identityHelperUseCase)
        {
            _transactionsService = transactionsService;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public int PackageTypeId { get; set; }

        public List<IInvoiceItemsGenerator> Generators { get; set; }

        public Func<DateTimeOffset, Task<List<Guid>>> GetUnpaidPackageIds { get; set; }

        public Func<List<Guid>, Task<List<GenericPackage>>> GetUnpaidPackagesByIds { get; set; }

        public Func<List<GenericPackage>, DateTimeOffset, Task> RefreshPaidUpToDate { get; set; }

        public async Task GenerateUpTo(DateTimeOffset invoiceEndDate)
        {
            invoiceEndDate = Dates.Min(invoiceEndDate, DateTimeOffset.Now.Date);

            var affectedPackages = new List<GenericPackage>();
            var packageIds = await GetUnpaidPackageIds.Invoke(invoiceEndDate).ConfigureAwait(false);

            // Generate invoices in batches, for up to 1000 packages per batch
            var iterations = Math.Ceiling(packageIds.Count / 1000M);

            for (var i = 0; i < iterations; i++)
            {
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
                await RefreshPaidUpToDate(affectedPackages, invoiceEndDate).ConfigureAwait(false);
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
    }
}
