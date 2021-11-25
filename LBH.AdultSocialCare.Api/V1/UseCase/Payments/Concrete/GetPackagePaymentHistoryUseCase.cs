using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPackagePaymentHistoryUseCase : IGetPackagePaymentHistoryUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;
        private readonly IPayRunGateway _payRunGateway;

        public GetPackagePaymentHistoryUseCase(ICarePackageGateway carePackageGateway, IPayRunInvoiceGateway payRunInvoiceGateway, IPayRunGateway payRunGateway)
        {
            _carePackageGateway = carePackageGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
            _payRunGateway = payRunGateway;
        }

        public async Task<PackagePaymentViewResponse> GetAsync(Guid packageId, RequestParameters parameters)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Supplier | PackageFields.ServiceUser, false)
                .EnsureExistsAsync($"Package with id {packageId} not found");

            var invoiceStatuses = new[] { InvoiceStatus.Accepted };
            var payRunStatuses = new[] { PayrunStatus.Approved, PayrunStatus.Paid, PayrunStatus.PaidWithHold };
            var payRunTypes = new[]
            {
                PayrunType.ResidentialRecurring, PayrunType.DirectPayments, PayrunType.ResidentialReleasedHolds,
                PayrunType.DirectPaymentsReleasedHolds
            };

            var packageLatestPayRun =
                await _payRunGateway.GetPackageLatestPayRunAsync(packageId, payRunTypes, payRunStatuses, invoiceStatuses);

            var payRunInvoices = await _payRunInvoiceGateway.GetPackageInvoicesAsync(packageId, parameters, payRunStatuses,
                invoiceStatuses, PayRunInvoiceFields.Invoice | PayRunInvoiceFields.Payrun, false);

            var payments = new PagedResponse<PackagePaymentItemResponse>
            {
                PagingMetaData = payRunInvoices.PagingMetaData,
                Data = payRunInvoices.Select(i => new PackagePaymentItemResponse
                {
                    PeriodFrom = i.Payrun.StartDate.Date,
                    PeriodTo = i.Payrun.EndDate.Date,
                    PayRunId = i.PayrunId,
                    InvoiceId = i.InvoiceId,
                    AmountPaid = decimal.Round(i.Invoice.GrossTotal, 2)
                })
            };

            var packagePayment = new PackageTotalPaymentResponse
            {
                PackageId = package.Id,
                TotalPaid = decimal.Round(payRunInvoices.Sum(pi => pi.Invoice.GrossTotal), 2),
                DateTo = packageLatestPayRun != null ? packageLatestPayRun.EndDate.Date : DateTime.Today
            };

            return new PackagePaymentViewResponse
            {
                PackageId = package.Id,
                ServiceUserName = package.ServiceUser.FirstName,
                SupplierId = package.SupplierId ?? 0,
                SupplierName = package.Supplier.SupplierName,
                PackageType = package.PackageType,
                Payments = payments,
                PackagePayment = packagePayment
            };
        }
    }
}
