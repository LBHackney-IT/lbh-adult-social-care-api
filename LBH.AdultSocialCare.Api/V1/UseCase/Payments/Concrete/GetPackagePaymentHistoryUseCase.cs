using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPackagePaymentHistoryUseCase : IGetPackagePaymentHistoryUseCase
    {
        public async Task<PackagePaymentViewResponse> GetAsync(Guid packageId, RequestParameters parameters)
        {
            var result = new PackagePaymentViewResponse
            {
                PackageId = packageId,
                ServiceUserName = "James Stephens",
                SupplierId = 1234567899,
                SupplierName = "Barchester Healthcare Homes Ltd",
                PackageType = PackageType.ResidentialCare,
                Payments = new PagedResponse<PackagePaymentItemResponse>
                {
                    PagingMetaData = new PagingMetaData
                    {
                        CurrentPage = 1,
                        TotalPages = 1,
                        PageSize = 10,
                        TotalCount = 5
                    },
                    Data = new List<PackagePaymentItemResponse>
                    {
                        new PackagePaymentItemResponse
                        {
                            PeriodFrom = new DateTime(2021,8,28),
                            PeriodTo = new DateTime(2021,8,1),
                            PayRunId = packageId,
                            InvoiceId = Guid.NewGuid(),
                            AmountPaid = decimal.Round(8888.88M, 2)
                        },
                        new PackagePaymentItemResponse
                        {
                            PeriodFrom = new DateTime(2021,8,28),
                            PeriodTo = new DateTime(2021,8,1),
                            PayRunId = packageId,
                            InvoiceId = Guid.NewGuid(),
                            AmountPaid = decimal.Round(8888.88M, 2)
                        },
                        new PackagePaymentItemResponse
                        {
                            PeriodFrom = new DateTime(2021,8,28),
                            PeriodTo = new DateTime(2021,8,1),
                            PayRunId = packageId,
                            InvoiceId = Guid.NewGuid(),
                            AmountPaid = decimal.Round(8888.88M, 2)
                        },
                        new PackagePaymentItemResponse
                        {
                            PeriodFrom = new DateTime(2021,8,28),
                            PeriodTo = new DateTime(2021,8,1),
                            PayRunId = packageId,
                            InvoiceId = Guid.NewGuid(),
                            AmountPaid = decimal.Round(8888.88M, 2)
                        },
                        new PackagePaymentItemResponse
                        {
                            PeriodFrom = new DateTime(2021,8,28),
                            PeriodTo = new DateTime(2021,8,1),
                            PayRunId = packageId,
                            InvoiceId = Guid.NewGuid(),
                            AmountPaid = decimal.Round(8888.88M, 2)
                        }
                    }
                },
                PackagePayment = new PackageTotalPaymentResponse
                {
                    PackageId = packageId,
                    TotalPaid = decimal.Round(888888M, 2),
                    DateTo = new DateTime(2021, 9, 1)
                }
            };
            return await Task.FromResult(result);
        }
    }
}
