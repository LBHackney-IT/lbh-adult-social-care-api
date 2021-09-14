using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.AppConstants.Enums;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.BusinessRules;
using LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing;
using LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing.Generators;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class PayRunUseCase : IPayRunUseCase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ISupplierGateway _supplierGateway;
        private readonly IClientsGateway _clientsGateway;
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;
        private readonly IFundedNursingCareGateway _fundedNursingCareGateway;
        private readonly IResidentialCarePackageGateway _residentialCarePackageGateway;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public PayRunUseCase(ITransactionsService transactionsService, ISupplierGateway supplierGateway,
            IClientsGateway clientsGateway, INursingCarePackageGateway nursingCarePackageGateway,
            IFundedNursingCareGateway fundedNursingCareGateway, IResidentialCarePackageGateway residentialCarePackageGateway,
            IIdentityHelperUseCase identityHelperUseCase)
        {
            _transactionsService = transactionsService;
            _supplierGateway = supplierGateway;
            _clientsGateway = clientsGateway;
            _nursingCarePackageGateway = nursingCarePackageGateway;
            _fundedNursingCareGateway = fundedNursingCareGateway;
            _residentialCarePackageGateway = residentialCarePackageGateway;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<Guid?> CreateNewPayRunUseCase(string payRunType, PayRunForCreationRequest payRunForCreationRequest)
        {
            if (!PayRunTypeEnum.ResidentialRecurring.EnumIsDefined(payRunType) && !PayRunSubTypeEnum.DirectPaymentsReleaseHolds.EnumIsDefined(payRunType))
            {
                throw new EntityNotFoundException("The pay run type is not valid. Please check and try again");
            }

            return payRunType switch
            {
                nameof(PayRunTypeEnum.ResidentialRecurring) => await CreateResidentialRecurringPayRun(payRunForCreationRequest).ConfigureAwait(false),
                nameof(PayRunTypeEnum.DirectPayments) => await _transactionsService.CreateDirectPaymentsPayRun(payRunForCreationRequest)
                    .ConfigureAwait(false),
                nameof(PayRunTypeEnum.HomeCare) => await _transactionsService.CreateHomeCarePayRun(payRunForCreationRequest)
                    .ConfigureAwait(false),
                nameof(PayRunSubTypeEnum.ResidentialReleaseHolds) => await _transactionsService.CreateResidentialReleaseHoldsPayRun(payRunForCreationRequest)
                    .ConfigureAwait(false),
                nameof(PayRunSubTypeEnum.DirectPaymentsReleaseHolds) => await
                    _transactionsService.CreateDirectPaymentsReleaseHoldsPayRun(payRunForCreationRequest)
                        .ConfigureAwait(false),
                _ => throw new EntityNotFoundException("The pay run type is not valid. Please check and try again")
            };
        }

        public async Task<PagedPayRunSummaryResponse> GetPayRunSummaryListUseCase(PayRunSummaryListParameters parameters)
        {
            return await _transactionsService.GetPayRunSummaryList(parameters).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ReleasedHoldsByTypeResponse>> GetReleasedHoldsCountUseCase(DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null)
        {
            return await _transactionsService.GetReleasedHoldsCount(fromDate, toDate).ConfigureAwait(false);
        }

        public async Task<PagedHeldInvoiceResponse> GetHeldInvoicePaymentsUseCase(HeldInvoicePaymentParameters parameters)
        {
            var heldInvoicesRes = await _transactionsService.GetHeldInvoicePaymentsUseCase(parameters).ConfigureAwait(false);
            var supplierIds = new List<long>();
            var serviceUserIds = new List<Guid>();

            var heldInvoicePayments = (heldInvoicesRes.Data ?? Array.Empty<HeldInvoiceResponse>()).ToList();
            foreach (var invoice in heldInvoicePayments.SelectMany(payRun => payRun.Invoices))
            {
                supplierIds.Add(invoice.SupplierId);
                serviceUserIds.Add(invoice.ServiceUserId);
            }

            supplierIds = supplierIds.Distinct().ToList();
            serviceUserIds = serviceUserIds.Distinct().ToList();

            // Get supplier names
            var suppliers = await _supplierGateway.GetSupplierMinimalInList(supplierIds).ConfigureAwait(false);
            var supplierList = suppliers.ToList();

            // Get service user names
            var clients = await _clientsGateway.GetClientMinimalInList(serviceUserIds).ConfigureAwait(false);
            var clientList = clients.ToList();

            // Add supplier and service user names to invoices
            foreach (var invoice in heldInvoicePayments.SelectMany(payRun => payRun.Invoices))
            {
                invoice.SupplierName = supplierList.FirstOrDefault(s => s.Id == invoice.SupplierId)?.SupplierName ?? "";
                invoice.ServiceUserName = clientList.FirstOrDefault(s => s.ClientId == invoice.ServiceUserId)?.ClientName ?? "";
            }

            return new PagedHeldInvoiceResponse
            {
                PagingMetaData = heldInvoicesRes.PagingMetaData,
                Data = heldInvoicesRes.Data
            };
        }

        public async Task<PayRunDetailsResponse> GetSinglePayRunDetailsUseCase(Guid payRunId, InvoiceListParameters parameters)
        {
            var payRun = await _transactionsService.GetSinglePayRunDetailsUseCase(payRunId, parameters)
                .ConfigureAwait(false);
            var supplierIds = new List<long>();
            var serviceUserIds = new List<Guid>();

            var payRunInvoices = (payRun.Invoices.Invoices ?? Array.Empty<InvoiceResponse>()).ToList();
            foreach (var invoice in payRunInvoices)
            {
                supplierIds.Add(invoice.SupplierId);
                serviceUserIds.Add(invoice.ServiceUserId);
            }

            supplierIds = supplierIds.Distinct().ToList();
            serviceUserIds = serviceUserIds.Distinct().ToList();

            // Get supplier names
            var suppliers = await _supplierGateway.GetSupplierMinimalInList(supplierIds).ConfigureAwait(false);
            var supplierList = suppliers.ToList();

            // Get service user names
            var clients = await _clientsGateway.GetClientMinimalInList(serviceUserIds).ConfigureAwait(false);
            var clientList = clients.ToList();

            // Add supplier and service user names to invoices
            foreach (var invoice in payRunInvoices)
            {
                invoice.SupplierName = supplierList.FirstOrDefault(s => s.Id == invoice.SupplierId)?.SupplierName ?? "";
                invoice.ServiceUserName = clientList.FirstOrDefault(s => s.ClientId == invoice.ServiceUserId)?.ClientName ?? "";
            }

            return new PayRunDetailsResponse
            {
                PayRunDetails = payRun.PayRunDetails,
                Invoices = new PagedInvoiceResponse
                {
                    PagingMetaData = payRun.Invoices.PagingMetaData,
                    Invoices = payRunInvoices
                }
            };
        }

        private async Task<Guid?> CreateResidentialRecurringPayRun(PayRunForCreationRequest request)
        {
            await GenerateNursingCareInvoices(request.DateTo.Date).ConfigureAwait(false);
            await GenerateResidentialCareInvoices(request.DateTo.Date).ConfigureAwait(false);

            return await _transactionsService
                .CreateResidentialRecurringPayRun(request)
                .ConfigureAwait(false);
        }

        private async Task GenerateNursingCareInvoices(DateTimeOffset dateTo)
        {
            var fncPrices = await _fundedNursingCareGateway
                .GetFundedNursingCarePricesAsync()
                .ConfigureAwait(false);

            var invoiceGenerator = new InvoiceGenerator(_transactionsService, _identityHelperUseCase)
            {
                PackageTypeId = PackageTypesConstants.NursingCarePackageId,

                GetUnpaidPackageIds = _nursingCarePackageGateway.GetUnpaidPackageIdsAsync,
                GetUnpaidPackagesByIds = GetUnpaidNursingCarePackages,
                RefreshPaidUpToDate = RefreshNursingCarePackagePaidUpToDate,

                Generators = new List<IInvoiceItemsGenerator>
                {
                    new CoreCostGenerator("Residential Care Core Cost"),
                    new AdditionalNeedsCostGenerator(),
                    new FundedNursingCareGenerator(fncPrices.ToList()),
                    new CareChargeGenerator()
                }
            };

            await invoiceGenerator.GenerateUpTo(dateTo).ConfigureAwait(false);
        }

        private async Task GenerateResidentialCareInvoices(DateTimeOffset dateTo)
        {
            var invoiceGenerator = new InvoiceGenerator(_transactionsService, _identityHelperUseCase)
            {
                PackageTypeId = PackageTypesConstants.ResidentialCarePackageId,

                GetUnpaidPackageIds = _residentialCarePackageGateway.GetUnpaidPackageIdsAsync,
                GetUnpaidPackagesByIds = GetUnpaidResidentialCarePackages,
                RefreshPaidUpToDate = RefreshResidentialCarePackagePaidUpToDate,

                Generators = new List<IInvoiceItemsGenerator>
                {
                    new CoreCostGenerator("Nursing Care Core Cost"),
                    new AdditionalNeedsCostGenerator(),
                    new CareChargeGenerator()
                }
            };

            await invoiceGenerator.GenerateUpTo(dateTo).ConfigureAwait(false);
        }

        #region Package / GenericPackage adapter methods

        private async Task<List<GenericPackage>> GetUnpaidNursingCarePackages(List<Guid> ids)
        {
            var packages = await _nursingCarePackageGateway.GetFullPackagesByIds(ids).ConfigureAwait(false);

            return packages.ToInvoicingDomain().ToList();
        }

        private async Task RefreshNursingCarePackagePaidUpToDate(List<GenericPackage> packages, DateTimeOffset paidUpTo)
        {
            var nursingCarePackages = packages.Select(p => p.OriginalPackage as NursingCarePackage).ToList();

            await _nursingCarePackageGateway.RefreshPaidUpToDateAsync(nursingCarePackages, paidUpTo).ConfigureAwait(false);
        }

        private async Task<List<GenericPackage>> GetUnpaidResidentialCarePackages(List<Guid> ids)
        {
            var packages = await _residentialCarePackageGateway.GetPackagesByIds(ids).ConfigureAwait(false);

            return packages.ToInvoicingDomain().ToList();
        }

        private async Task RefreshResidentialCarePackagePaidUpToDate(List<GenericPackage> packages, DateTimeOffset paidUpTo)
        {
            var nursingCarePackages = packages.Select(p => p.OriginalPackage as NursingCarePackage).ToList();

            await _residentialCarePackageGateway.RefreshPaidUpToDateAsync(nursingCarePackages, paidUpTo).ConfigureAwait(false);
        }

        #endregion
    }
}
