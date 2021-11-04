using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunDetailsUseCase : IGetPayRunDetailsUseCase
    {
        public async Task<PayRunDetailsViewResponse> ExecuteAsync(Guid payrunId)
        {
            var result = new PayRunDetailsViewResponse
            {
                PayRunId = payrunId,
                DateCreated = DateTimeOffset.Now,
                StartDate = DateTimeOffset.Now.AddDays(-14),
                EndDate = DateTimeOffset.Now,
                PayRunItems = new PagedResponse<PayRunInvoiceResponse>
                {
                    PagingMetaData =
                        new PagingMetaData { CurrentPage = 1, TotalPages = 1, PageSize = 1, TotalCount = 1 },
                    Data = new List<PayRunInvoiceResponse>()
                    {
                        new PayRunInvoiceResponse
                        {
                            Id = Guid.NewGuid(),
                            InvoiceId = Guid.NewGuid(),
                            CarePackageId = Guid.NewGuid(),
                            ServiceUserId = Guid.NewGuid(),
                            ServiceUserName = "Emma Stone",
                            SupplierId = 12,
                            SupplierName = "Derek Drinkwater",
                            InvoiceNumber = "INV 10",
                            PackageTypeId = (int) PackageType.ResidentialCare,
                            PackageType = PackageType.ResidentialCare.GetDisplayName(),
                            GrossTotal = 500,
                            NetTotal = 300,
                            InvoiceStatus = InvoiceStatus.Accepted,
                            AssignedBrokerName = "Herman Ferdinand",
                            InvoiceItems = new List<PayRunInvoiceItemResponse>()
                            {
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Residential Care Core",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 250,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 500,
                                    ClaimCollector = ClaimCollector.Hackney,
                                    ClaimCollectorName = ClaimCollector.Hackney.GetDisplayName()
                                }
                            }
                        }
                    }
                }
            };

            return await Task.FromResult(result);
        }
    }
}
