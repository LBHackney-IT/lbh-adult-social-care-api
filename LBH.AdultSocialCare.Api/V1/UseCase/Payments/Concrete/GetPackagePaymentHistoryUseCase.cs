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
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.Extensions;
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
            var payRunStatuses = new[] { PayrunStatus.Paid, PayrunStatus.PaidWithHold };

            var packageLatestPayRun =
                await _payRunGateway.GetPackageLatestPayRunAsync(packageId, payRunStatuses, invoiceStatuses);

            var allInvoices = await _payRunInvoiceGateway.GetPackageInvoicesAsync(packageId, payRunStatuses,
                invoiceStatuses, PayRunInvoiceFields.Invoice | PayRunInvoiceFields.Payrun, false);

            var payRunInvoices = allInvoices
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();
            var pagedInvoices = PagedList<PayrunInvoice>.ToPagedList(payRunInvoices, allInvoices.Count, parameters.PageNumber,
                parameters.PageSize);


            var payments = new PagedResponse<PackagePaymentItemResponse>
            {
                PagingMetaData = pagedInvoices.PagingMetaData,
                Data = pagedInvoices.Select(i => new PackagePaymentItemResponse
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
                TotalPaid = decimal.Round(allInvoices.Sum(pi => pi.Invoice.GrossTotal), 2),
                DateTo = packageLatestPayRun != null ? packageLatestPayRun.EndDate.Date : DateTime.Today
            };

            return new PackagePaymentViewResponse
            {
                PackageId = package.Id,
                ServiceUserName = package.ServiceUser.FirstName,
                CedarId = package.Supplier.CedarId ?? 0,
                SupplierName = package.Supplier.SupplierName,
                PackageType = package.PackageType,
                Payments = payments,
                PackagePayment = packagePayment
            };
        }
    }
}
