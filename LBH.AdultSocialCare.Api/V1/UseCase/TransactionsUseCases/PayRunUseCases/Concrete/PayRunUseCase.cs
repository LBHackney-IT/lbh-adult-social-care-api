using Common.AppConstants.Enums;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Concrete
{
    public class PayRunUseCase : IPayRunUseCase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ISupplierGateway _supplierGateway;

        public PayRunUseCase(ITransactionsService transactionsService, ISupplierGateway supplierGateway)
        {
            _transactionsService = transactionsService;
            _supplierGateway = supplierGateway;
        }

        public async Task<Guid?> CreateNewPayRunUseCase(string payRunType, PayRunForCreationRequest payRunForCreationRequest)
        {
            if (!PayRunTypeEnum.ResidentialRecurring.EnumIsDefined(payRunType) && !PayRunSubTypeEnum.DirectPaymentsReleaseHolds.EnumIsDefined(payRunType))
            {
                throw new EntityNotFoundException("The pay run type is not valid. Please check and try again");
            }

            return payRunType switch
            {
                nameof(PayRunTypeEnum.ResidentialRecurring) => await _transactionsService.CreateResidentialRecurringPayRun(payRunForCreationRequest)
                    .ConfigureAwait(false),
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

        public async Task<IEnumerable<HeldInvoiceResponse>> GetHeldInvoicePaymentsUseCase()
        {
            var heldInvoicesRes = await _transactionsService.GetHeldInvoicePaymentsUseCase().ConfigureAwait(false);
            var supplierIds = new List<long>();
            var serviceUserIds = new List<Guid>();

            var heldInvoicePayments = (heldInvoicesRes ?? Array.Empty<HeldInvoiceResponse>()).ToList();
            foreach (var payRun in heldInvoicePayments)
            {
                foreach (var invoice in payRun.Invoices)
                {
                    supplierIds.Add(invoice.SupplierId);
                    serviceUserIds.Add(invoice.ServiceUserId);
                }
            }

            supplierIds = supplierIds.Distinct().ToList();
            serviceUserIds = serviceUserIds.Distinct().ToList();

            // Get supplier names
            var suppliers = await _supplierGateway.GetSupplierMinimalInList(supplierIds).ConfigureAwait(false);
            var supplierList = suppliers.ToList();
            foreach (var payRun in heldInvoicePayments)
            {
                foreach (var invoice in payRun.Invoices)
                {
                    invoice.SupplierName = supplierList.FirstOrDefault(s => s.Id == invoice.SupplierId)?.SupplierName ?? "";
                }
            }

            // Get service user names
            return heldInvoicePayments;
        }
    }
}
