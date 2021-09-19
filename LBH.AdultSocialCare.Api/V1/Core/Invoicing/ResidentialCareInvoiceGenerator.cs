using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing
{
    public class ResidentialCareInvoiceGenerator : BaseInvoiceGenerator
    {
        private readonly IResidentialCarePackageGateway _residentialCarePackageGateway;

        public ResidentialCareInvoiceGenerator(
            ITransactionsService transactionsService, IIdentityHelperUseCase identityHelperUseCase,
            ITransactionManager transactionManager, IResidentialCarePackageGateway residentialCarePackageGateway,
            ICareChargesGateway careChargesGateway) : base(transactionsService, identityHelperUseCase, transactionManager, careChargesGateway)
        {
            _residentialCarePackageGateway = residentialCarePackageGateway;

            PackageTypeId = PackageTypesConstants.ResidentialCarePackageId;

            Generators = new List<BaseInvoiceItemsGenerator>
            {
                new CoreCostGenerator("Residential Care Core Cost"),
                new AdditionalNeedsCostGenerator(),
                new CareChargeGenerator(careChargesGateway)
            };
        }

        protected override async Task<List<Guid>> GetUnpaidPackageIds(DateTimeOffset invoiceEndDate)
        {
            return await _residentialCarePackageGateway
                .GetUnpaidPackageIdsAsync(invoiceEndDate)
                .ConfigureAwait(false);
        }

        protected override async Task<List<GenericPackage>> GetUnpaidPackagesByIds(List<Guid> packageIds)
        {
            var packages = await _residentialCarePackageGateway.GetPackagesByIds(packageIds).ConfigureAwait(false);
            var genericPackages = packages.ToInvoicingDomain().ToList();

            await FillCareCharges(packageIds, genericPackages).ConfigureAwait(false);

            return genericPackages;
        }

        protected override async Task RefreshPackagesPaidUpToDate(List<GenericPackage> packages, DateTimeOffset invoiceEndDate)
        {
            var residentialCarePackages = packages.Select(p => p.OriginalPackage as ResidentialCarePackage).ToList();

            await _residentialCarePackageGateway
                .RefreshPaidUpToDateAsync(residentialCarePackages, invoiceEndDate)
                .ConfigureAwait(false);
        }
    }
}
