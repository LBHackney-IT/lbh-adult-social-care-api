using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPackagePaymentHistoryUseCase : IGetPackagePaymentHistoryUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public GetPackagePaymentHistoryUseCase(ICarePackageGateway carePackageGateway, IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _carePackageGateway = carePackageGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task<PackagePaymentViewResponse> GetAsync(Guid packageId, RequestParameters parameters)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Supplier | PackageFields.ServiceUser, false)
                .EnsureExistsAsync($"Package with id {packageId} not found");

            var invoiceStatuses = new[] { InvoiceStatus.Accepted };
            var payRunStatuses = new[] { PayrunStatus.Approved, PayrunStatus.Paid, PayrunStatus.PaidWithHold };

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
                TotalPaid = payRunInvoices.Sum(pi => pi.Invoice.GrossTotal),
                DateTo = DateTime.Today
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
