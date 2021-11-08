using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunDetailsUseCase : IGetPayRunDetailsUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public GetPayRunDetailsUseCase(IPayRunGateway payRunGateway, IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _payRunGateway = payRunGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task<PayRunDetailsViewResponse> ExecuteAsync(Guid payrunId, PayRunDetailsQueryParameters parameters)
        {
            // Get pay run
            var payRun = await _payRunGateway.GetPayRunAsync(payrunId);
            if (payRun == null)
            {
                return GenerateDummyPayRunData(payrunId);
            }

            // Get pay run items
            var payRunInvoices =
                await _payRunInvoiceGateway.GetPayRunInvoicesSummaryAsync(payrunId, parameters);
            var result = CreateResponse(payRun, payRunInvoices, payRunInvoices.PagingMetaData);
            return result;
        }

        private static PayRunDetailsViewResponse GenerateDummyPayRunData(Guid payrunId)
        {
            return new PayRunDetailsViewResponse
            {
                PayRunId = payrunId,
                PayRunNumber = payrunId.ToString().Substring(0, 6),
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
                            InvoiceId = Guid.NewGuid(),
                            CarePackageId = Guid.NewGuid(),
                            ServiceUserId = Guid.NewGuid(),
                            ServiceUserName = "Martin Ayeni",
                            SupplierId = 12,
                            SupplierName = "Barchester Healthcare Homes Ltd",
                            InvoiceNumber = "INV 12",
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
        }

        private static PayRunDetailsViewResponse CreateResponse(Payrun payrun, IEnumerable<PayRunInvoiceDomain> payRunInvoices, PagingMetaData pagingMetaData)
        {
            var result = new PayRunDetailsViewResponse
            {
                PayRunId = payrun.Id,
                PayRunNumber = payrun.Id.ToString().Substring(0, 6),
                DateCreated = payrun.DateCreated,
                StartDate = payrun.StartDate,
                EndDate = payrun.EndDate
            };

            //
            var invoices = new List<PayRunInvoiceResponse>();

            foreach (var invoice in payRunInvoices)
            {
                var (grossTotal, netTotal) = CalculateTotals(invoice.InvoiceItems);
                var invoiceRes = new PayRunInvoiceResponse
                {
                    InvoiceId = invoice.InvoiceId,
                    CarePackageId = invoice.CarePackageId,
                    ServiceUserId = invoice.ServiceUserId,
                    ServiceUserName = invoice.ServiceUserName,
                    SupplierId = invoice.SupplierId,
                    SupplierName = invoice.SupplierName,
                    InvoiceNumber = invoice.InvoiceNumber,
                    PackageTypeId = (int) invoice.PackageType,
                    PackageType = invoice.PackageType.GetDisplayName(),
                    GrossTotal = grossTotal,
                    NetTotal = netTotal,
                    InvoiceStatus = invoice.InvoiceStatus,
                    AssignedBrokerName = invoice.AssignedBrokerName,
                    InvoiceItems = invoice.InvoiceItems.Select(ii => new PayRunInvoiceItemResponse
                    {
                        Id = ii.Id,
                        Name = ii.Name,
                        FromDate = ii.FromDate,
                        ToDate = ii.ToDate,
                        Cost = ii.Cost,
                        Days = (ii.ToDate - ii.FromDate).Days,
                        Quantity = ii.Quantity,
                        Period = $"{(ii.ToDate - ii.FromDate).Days} days",
                        TotalCost = ii.TotalCost,
                        IsReclaim = ii.IsReclaim,
                        ClaimCollector = ii.ClaimCollector,
                        ClaimCollectorName = ii.ClaimCollector.GetDisplayName()
                    })
                };
                invoices.Add(invoiceRes);
            }

            result.PayRunItems = new PagedResponse<PayRunInvoiceResponse>
            {
                PagingMetaData = pagingMetaData,
                Data = invoices
            };

            return result;
        }

        private static (decimal, decimal) CalculateTotals(IEnumerable<PayRunInvoiceItemDomain> invoiceItems)
        {
            var grossTotal = 0M;
            var netTotal = 0M;

            foreach (var invoiceItem in invoiceItems)
            {
                if (invoiceItem.IsReclaim == false && invoiceItem.PriceEffect == PriceEffect.Add)
                {
                    grossTotal += invoiceItem.TotalCost;
                    netTotal += invoiceItem.TotalCost;
                }

                if (invoiceItem.IsReclaim && invoiceItem.ClaimCollector == ClaimCollector.Supplier && invoiceItem.PriceEffect == PriceEffect.Subtract)
                {
                    netTotal -= invoiceItem.TotalCost;
                }
            }

            return (grossTotal, netTotal);
        }
    }
}
