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
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing
{
    public class NursingCareInvoiceGenerator : BaseInvoiceGenerator
    {
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;

        public NursingCareInvoiceGenerator(
            ITransactionsService transactionsService, IIdentityHelperUseCase identityHelperUseCase,
            IDatabaseManager databaseManager, INursingCarePackageGateway nursingCarePackageGateway,
            ICareChargesGateway careChargesGateway, IFundedNursingCareGateway fundedNursingCareGateway) : base(transactionsService, identityHelperUseCase, databaseManager, careChargesGateway)
        {
            _nursingCarePackageGateway = nursingCarePackageGateway;

            PackageTypeId = PackageTypesConstants.NursingCarePackageId;

            Generators = new List<BaseInvoiceItemsGenerator>
            {
                new CoreCostGenerator("Nursing Care Core Cost"),
                new AdditionalNeedsCostGenerator(),
                new FundedNursingCareGenerator(fundedNursingCareGateway),
                new CareChargeGenerator(careChargesGateway)
            };
        }

        protected override async Task<List<Guid>> GetUnpaidPackageIds(DateTimeOffset invoiceEndDate)
        {
            return await _nursingCarePackageGateway
                .GetUnpaidPackageIdsAsync(invoiceEndDate)
                .ConfigureAwait(false);
        }

        protected override async Task<List<GenericPackage>> GetUnpaidPackagesByIds(List<Guid> packageIds)
        {
            var packages = await _nursingCarePackageGateway.GetFullPackagesByIds(packageIds).ConfigureAwait(false);
            var genericPackages = packages.ToInvoicingDomain().ToList();

            await FillCareCharges(packageIds, genericPackages).ConfigureAwait(false);

            return genericPackages;
        }

        protected override async Task RefreshPackagesPaidUpToDate(List<GenericPackage> packages, DateTimeOffset invoiceEndDate)
        {
            var nursingCarePackages = packages.Select(p => p.OriginalPackage as NursingCarePackage).ToList();

            await _nursingCarePackageGateway
                .RefreshPaidUpToDateAsync(nursingCarePackages, invoiceEndDate)
                .ConfigureAwait(false);
        }
    }
}
