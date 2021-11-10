using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Functions.Payruns.Services
{
    public class FakeInvoiceGenerator
    {
        private readonly DatabaseContext _database;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FakeInvoiceGenerator(DatabaseContext database, IHttpContextAccessor httpContextAccessor)
        {
            _database = database;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task GenerateInvoices()
        {
            // TODO: VK: Completely fake implementation
            var draftPayruns = await _database.Payruns
                .Where(p => p.Status == PayrunStatus.Draft)
                .ToListAsync();

            var invoiceIndex = 1;

            foreach (var payrun in draftPayruns)
            {
                // TODO: VK: Don't have a logged-in user in lambda, so impersonate it as a payrun creator
                // Consider having a dedicated user to run lambda functions
                var userIdClaim = new Claim(ClaimTypes.NameIdentifier, payrun.CreatorId.ToString());
                ((ClaimsIdentity) _httpContextAccessor.HttpContext.User.Identity).AddClaim(userIdClaim);

                var packages = await _database.CarePackages
                    .Where(p => p.Status == PackageStatus.Approved &&
                                !_database.Invoices.Any(i => i.PackageId == p.Id))
                    .ToListAsync();

                foreach (var package in packages)
                {
                    var invoice = CreateInvoice(package, ref invoiceIndex);

                    var payrunInvoice = new PayrunInvoice
                    {
                        Payrun = payrun,
                        Invoice = invoice,
                        InvoiceStatus = InvoiceStatus.Draft
                    };

                    payrun.Status = PayrunStatus.WaitingForReview;
                    payrun.PayrunInvoices.Add(payrunInvoice);

                    await _database.SaveChangesAsync();
                }
            }
        }

        private static Invoice CreateInvoice(CarePackage package, ref int invoiceIndex)
        {
            return new Invoice
            {
                PackageId = package.Id,
                ServiceUserId = package.ServiceUserId,
                SupplierId = package.SupplierId.GetValueOrDefault(),
                Number = $"INV-{invoiceIndex++}",
                TotalCost = 1000,
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        Name = "Residential Care Core",
                        FromDate = DateTimeOffset.Now.AddDays(-14),
                        ToDate = DateTimeOffset.Now,
                        WeeklyCost = 250,
                        Quantity = 2,
                        TotalCost = 500,
                        IsReclaim = false,
                        ClaimCollector = ClaimCollector.Hackney
                    },
                    new InvoiceItem
                    {
                        Name = "Funded Nursing Care (net)",
                        FromDate = DateTimeOffset.Now.AddDays(-14),
                        ToDate = DateTimeOffset.Now,
                        WeeklyCost = 100,
                        Quantity = 2,
                        TotalCost = 100,
                        IsReclaim = true,
                        ClaimCollector = ClaimCollector.Supplier
                    },
                    new InvoiceItem
                    {
                        Name = "Care Charges",
                        FromDate = DateTimeOffset.Now.AddDays(-14),
                        ToDate = DateTimeOffset.Now,
                        WeeklyCost = 100,
                        Quantity = 2,
                        TotalCost = 200,
                        IsReclaim = true,
                        ClaimCollector = ClaimCollector.Supplier
                    },
                    new InvoiceItem
                    {
                        Name = "Additional Weekly cost",
                        FromDate = DateTimeOffset.Now.AddDays(-14),
                        ToDate = DateTimeOffset.Now,
                        WeeklyCost = 100,
                        Quantity = 2,
                        TotalCost = 200,
                        IsReclaim = false,
                        ClaimCollector = ClaimCollector.Hackney
                    }
                }
            };
        }
    }
}
