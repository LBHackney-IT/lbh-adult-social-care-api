using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunDetailsUseCase : IGetPayRunDetailsUseCase
    {
        public async Task<PayRunDetailsViewResponse> ExecuteAsync(Guid payrunId, PayRunDetailsQueryParameters parameters)
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
                        new PagingMetaData { CurrentPage = 1, TotalPages = 1, PageSize = 3, TotalCount = 3 },
                    Data = new List<PayRunInvoiceResponse>()
                    {
                        new PayRunInvoiceResponse
                        {
                            Id = Guid.NewGuid(),
                            InvoiceId = Guid.NewGuid(),
                            CarePackageId = Guid.NewGuid(),
                            ServiceUserId = Guid.NewGuid(),
                            ServiceUserName = "James Stephens",
                            SupplierId = 12,
                            SupplierName = "Barchester Healthcare Homes Ltd",
                            InvoiceNumber = "INV 10",
                            PackageTypeId = (int) PackageType.ResidentialCare,
                            PackageType = PackageType.ResidentialCare.GetDisplayName(),
                            GrossTotal = 800,
                            NetTotal = 600,
                            InvoiceStatus = InvoiceStatus.Accepted,
                            AssignedBrokerName = "Derek Ofoborh",
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
                                    IsReclaim = false,
                                    ClaimCollector = ClaimCollector.Hackney,
                                    ClaimCollectorName = ClaimCollector.Hackney.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Funded Nursing Care (net)",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = true,
                                    ClaimCollector = ClaimCollector.Supplier,
                                    ClaimCollectorName = ClaimCollector.Supplier.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Care Charges",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = true,
                                    ClaimCollector = ClaimCollector.Supplier,
                                    ClaimCollectorName = ClaimCollector.Supplier.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Additional Weekly cost",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = false,
                                    ClaimCollector = ClaimCollector.Hackney,
                                    ClaimCollectorName = ClaimCollector.Hackney.GetDisplayName()
                                }
                            }
                        },
                        new PayRunInvoiceResponse
                        {
                            Id = Guid.NewGuid(),
                            InvoiceId = Guid.NewGuid(),
                            CarePackageId = Guid.NewGuid(),
                            ServiceUserId = Guid.NewGuid(),
                            ServiceUserName = "Luke Sully",
                            SupplierId = 12,
                            SupplierName = "Barchester Healthcare Homes Ltd",
                            InvoiceNumber = "INV 11",
                            PackageTypeId = (int) PackageType.ResidentialCare,
                            PackageType = PackageType.ResidentialCare.GetDisplayName(),
                            GrossTotal = 800,
                            NetTotal = 600,
                            InvoiceStatus = InvoiceStatus.Held,
                            AssignedBrokerName = "Derek Ofoborh",
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
                                    IsReclaim = false,
                                    ClaimCollector = ClaimCollector.Hackney,
                                    ClaimCollectorName = ClaimCollector.Hackney.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Funded Nursing Care (net)",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = true,
                                    ClaimCollector = ClaimCollector.Supplier,
                                    ClaimCollectorName = ClaimCollector.Supplier.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Care Charges",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = true,
                                    ClaimCollector = ClaimCollector.Supplier,
                                    ClaimCollectorName = ClaimCollector.Supplier.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Additional Weekly cost",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = false,
                                    ClaimCollector = ClaimCollector.Hackney,
                                    ClaimCollectorName = ClaimCollector.Hackney.GetDisplayName()
                                }
                            }
                        },
                        new PayRunInvoiceResponse
                        {
                            Id = Guid.NewGuid(),
                            InvoiceId = Guid.NewGuid(),
                            CarePackageId = Guid.NewGuid(),
                            ServiceUserId = Guid.NewGuid(),
                            ServiceUserName = "Martin Ayeni",
                            SupplierId = 12,
                            SupplierName = "Barchester Healthcare Homes Ltd",
                            InvoiceNumber = "INV 11",
                            PackageTypeId = (int) PackageType.ResidentialCare,
                            PackageType = PackageType.ResidentialCare.GetDisplayName(),
                            GrossTotal = 800,
                            NetTotal = 600,
                            InvoiceStatus = InvoiceStatus.Rejected,
                            AssignedBrokerName = "Derek Ofoborh",
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
                                    IsReclaim = false,
                                    ClaimCollector = ClaimCollector.Hackney,
                                    ClaimCollectorName = ClaimCollector.Hackney.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Funded Nursing Care (net)",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = true,
                                    ClaimCollector = ClaimCollector.Supplier,
                                    ClaimCollectorName = ClaimCollector.Supplier.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Care Charges",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = true,
                                    ClaimCollector = ClaimCollector.Supplier,
                                    ClaimCollectorName = ClaimCollector.Supplier.GetDisplayName()
                                },
                                new PayRunInvoiceItemResponse
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Additional Weekly cost",
                                    FromDate = DateTimeOffset.Now.AddDays(-14),
                                    ToDate = DateTimeOffset.Now,
                                    Cost = 50,
                                    Days = 14,
                                    Quantity = 2,
                                    Period = "2 weeks",
                                    TotalCost = 100,
                                    IsReclaim = false,
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
