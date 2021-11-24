using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetHeldInvoicesUseCase : IGetHeldInvoicesUseCase
    {
        public async Task<PagedResponse<HeldInvoiceItemResponse>> ExecuteAsync(PayRunDetailsQueryParameters parameters)
        {
            var result = new PagedResponse<HeldInvoiceItemResponse>
            {
                PagingMetaData = new PagingMetaData { CurrentPage = 1, TotalPages = 1, PageSize = 2, TotalCount = 2 },
                Data = new List<HeldInvoiceItemResponse>()
                {
                    new HeldInvoiceItemResponse
                    {
                        PayRunId = Guid.NewGuid(),
                        PayRunNumber = Guid.NewGuid().ToString()[..6],
                        DateCreated = DateTimeOffset.Now,
                        StartDate = DateTimeOffset.Now,
                        EndDate = DateTimeOffset.Now.AddDays(-5),
                        Invoice = new PayRunInvoiceResponse
                        {
                            Id = Guid.NewGuid(),
                            InvoiceId = Guid.NewGuid(),
                            CarePackageId = Guid.NewGuid(),
                            ServiceUserId = Guid.NewGuid(),
                            ServiceUserName = "Name One",
                            SupplierId = 1,
                            SupplierName = "Supplier One",
                            InvoiceNumber = "INV 1",
                            PackageTypeId = (int) PackageType.ResidentialCare,
                            PackageType = PackageType.ResidentialCare.GetDisplayName(),
                            GrossTotal = 300,
                            NetTotal = 200,
                            SupplierReclaimsTotal = 100,
                            HackneyReclaimsTotal = 100,
                            InvoiceStatus = InvoiceStatus.Held,
                            AssignedBrokerName = "Derek Ofoborh",
                            InvoiceItems = new List<PayRunInvoiceItemResponse>()
                            {
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Residential Care Core",
                                    FromDate = DateTimeOffset.Now.AddDays(-30),
                                    ToDate = DateTimeOffset.Now.AddDays(-5),
                                    Cost = 300,
                                    Quantity = 1,
                                    TotalCost = 300,
                                    ClaimCollector = null
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Care Charge One",
                                    FromDate = DateTimeOffset.Now.AddDays(-30),
                                    ToDate = DateTimeOffset.Now.AddDays(-5),
                                    Cost = 100,
                                    Quantity = 1,
                                    TotalCost = 100,
                                    ClaimCollector = ClaimCollector.Hackney
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Care Charge Two",
                                    FromDate = DateTimeOffset.Now.AddDays(-30),
                                    ToDate = DateTimeOffset.Now.AddDays(-5),
                                    Cost = 100,
                                    Quantity = 1,
                                    TotalCost = 100,
                                    ClaimCollector = ClaimCollector.Supplier
                                }
                            }
                        }
                    },
                    new HeldInvoiceItemResponse
                    {
                        PayRunId = Guid.NewGuid(),
                        PayRunNumber = Guid.NewGuid().ToString()[..6],
                        DateCreated = DateTimeOffset.Now,
                        StartDate = DateTimeOffset.Now,
                        EndDate = DateTimeOffset.Now.AddDays(-5),
                        Invoice = new PayRunInvoiceResponse
                        {
                            Id = Guid.NewGuid(),
                            InvoiceId = Guid.NewGuid(),
                            CarePackageId = Guid.NewGuid(),
                            ServiceUserId = Guid.NewGuid(),
                            ServiceUserName = "Name Two",
                            SupplierId = 1,
                            SupplierName = "Supplier Two",
                            InvoiceNumber = "INV 1",
                            PackageTypeId = (int) PackageType.NursingCare,
                            PackageType = PackageType.NursingCare.GetDisplayName(),
                            GrossTotal = 400,
                            NetTotal = 200,
                            SupplierReclaimsTotal = 200,
                            HackneyReclaimsTotal = 100,
                            InvoiceStatus = InvoiceStatus.Held,
                            AssignedBrokerName = "Derek Ofoborh",
                            InvoiceItems = new List<PayRunInvoiceItemResponse>()
                            {
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Nursing Care Core",
                                    FromDate = DateTimeOffset.Now.AddDays(-30),
                                    ToDate = DateTimeOffset.Now.AddDays(-5),
                                    Cost = 300,
                                    Quantity = 1,
                                    TotalCost = 300,
                                    ClaimCollector = null
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Care Charge One",
                                    FromDate = DateTimeOffset.Now.AddDays(-30),
                                    ToDate = DateTimeOffset.Now.AddDays(-5),
                                    Cost = 100,
                                    Quantity = 1,
                                    TotalCost = 100,
                                    ClaimCollector = ClaimCollector.Hackney
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "FNC",
                                    FromDate = DateTimeOffset.Now.AddDays(-30),
                                    ToDate = DateTimeOffset.Now.AddDays(-5),
                                    Cost = 200,
                                    Quantity = 1,
                                    TotalCost = 200,
                                    ClaimCollector = ClaimCollector.Supplier
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
