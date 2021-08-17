using Common.AppConstants.Enums;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Concrete
{
    public class PayRunUseCase : IPayRunUseCase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ISupplierGateway _supplierGateway;
        private readonly IClientsGateway _clientsGateway;
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;
        private readonly IResidentialCarePackageGateway _residentialCarePackageGateway;

        public PayRunUseCase(ITransactionsService transactionsService, ISupplierGateway supplierGateway,
            IClientsGateway clientsGateway, INursingCarePackageGateway nursingCarePackageGateway,
            IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _transactionsService = transactionsService;
            _supplierGateway = supplierGateway;
            _clientsGateway = clientsGateway;
            _nursingCarePackageGateway = nursingCarePackageGateway;
            _residentialCarePackageGateway = residentialCarePackageGateway;
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

        private async Task<Guid?> CreateResidentialRecurringPayRun(PayRunForCreationRequest payRunForCreationRequest)
        {
            // Generate nursing care invoices
            await _nursingCarePackageGateway.GenerateNursingCareInvoices(payRunForCreationRequest.DateTo.Date)
                .ConfigureAwait(false);

            // Generate residential care invoices
            await _residentialCarePackageGateway.GenerateResidentialCareInvoices(payRunForCreationRequest.DateTo.Date)
                .ConfigureAwait(false);

            return await _transactionsService.CreateResidentialRecurringPayRun(payRunForCreationRequest)
                .ConfigureAwait(false);
        }
    }
}
