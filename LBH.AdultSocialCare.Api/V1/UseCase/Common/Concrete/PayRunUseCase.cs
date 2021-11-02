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
using LBH.AdultSocialCare.Api.V1.Core.Invoicing;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class PayRunUseCase : IPayRunUseCase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly InvoiceGenerator _invoiceGenerator;
        private readonly ISupplierGateway _supplierGateway;
        private readonly IClientsGateway _clientsGateway;

        public PayRunUseCase(
            ITransactionsService transactionsService, InvoiceGenerator invoiceGenerator,
            ISupplierGateway supplierGateway, IClientsGateway clientsGateway)
        {
            _transactionsService = transactionsService;
            _invoiceGenerator = invoiceGenerator;
            _supplierGateway = supplierGateway;
            _clientsGateway = clientsGateway;
        }

        public async Task<Guid?> CreateNewPayRunUseCase(string payRunType, PayRunForCreationRequest payRunForCreationRequest)
        {
            if (!PayrunType.ResidentialRecurring.EnumIsDefined(payRunType) && !PayRunSubTypeEnum.DirectPaymentsReleaseHolds.EnumIsDefined(payRunType))
            {
                throw new EntityNotFoundException("The pay run type is not valid. Please check and try again");
            }

            return payRunType switch
            {
                nameof(PayrunType.ResidentialRecurring) => await CreateResidentialRecurringPayRun(payRunForCreationRequest).ConfigureAwait(false),
                nameof(PayrunType.DirectPayments) => await _transactionsService.CreateDirectPaymentsPayRun(payRunForCreationRequest)
                    .ConfigureAwait(false),
                nameof(PayrunType.HomeCare) => await _transactionsService.CreateHomeCarePayRun(payRunForCreationRequest)
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
                invoice.ServiceUserName = clientList.FirstOrDefault(s => s.Id == invoice.ServiceUserId)?.Name ?? "";
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
                invoice.ServiceUserName = clientList.FirstOrDefault(s => s.Id == invoice.ServiceUserId)?.Name ?? "";
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
            await _invoiceGenerator.GenerateUpTo(request.DateTo.Date);

            return await _transactionsService
                .CreateResidentialRecurringPayRun(request)
                .ConfigureAwait(false);
        }
    }
}
