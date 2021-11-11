using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bogus;
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
        private readonly Random _random = new Random();

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

            var invoicesCount = await _database.Invoices.CountAsync();

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
                    var invoice = CreateInvoice(package, invoicesCount++);

                    var payrunInvoice = new PayrunInvoice
                    {
                        Payrun = payrun,
                        Invoice = invoice,
                        InvoiceStatus = InvoiceStatus.Draft
                    };

                    payrun.PayrunInvoices.Add(payrunInvoice);
                }

                payrun.Status = PayrunStatus.WaitingForReview;
                await _database.SaveChangesAsync();
            }
        }

        private Invoice CreateInvoice(CarePackage package, int invoiceIndex)
        {
            var invoice = new Invoice
            {
                PackageId = package.Id,
                ServiceUserId = package.ServiceUserId,
                SupplierId = package.SupplierId.GetValueOrDefault(),
                Number = $"INV {invoiceIndex}",
                TotalCost = 0.0m,
                Items = new List<InvoiceItem>()
            };

            invoice.Items.Add(GenerateInvoiceItem(
                package.PackageType is PackageType.ResidentialCare
                    ? "Residential Care Core"
                    : "Nursing Care Core"));

            if (package.PackageType is PackageType.NursingCare && _random.NextDouble() > 0.5)
            {
                var fnc = GenerateInvoiceItem("Funded Nursing Care");
                fnc.Name += fnc.ClaimCollector is ClaimCollector.Hackney ? " (gross)" : " (net)";

                invoice.Items.Add(fnc);
            }

            var additionalWeeklyNeedsCount = _random.Next(3, 10);
            for (var i = 0; i < additionalWeeklyNeedsCount; i++)
            {
                invoice.Items.Add(GenerateInvoiceItem("Additional Weekly cost"));
            }

            var careChargesCount = _random.Next(3, 10);
            for (var i = 0; i < careChargesCount; i++)
            {
                invoice.Items.Add(GenerateInvoiceItem("Care Charges"));
            }

            return invoice;
        }

        private static InvoiceItem GenerateInvoiceItem(string name)
        {
            var item = new Faker<InvoiceItem>()
                .RuleFor(i => i.Name, name)
                .RuleFor(i => i.WeeklyCost, f => f.Finance.Amount(10.0m, 500.0m))
                .RuleFor(i => i.ToDate, DateTimeOffset.Now)
                .RuleFor(i => i.FromDate, f => f.Date.Recent(45))
                .RuleFor(i => i.ClaimCollector, f => f.PickRandom<ClaimCollector>())
                .RuleFor(i => i.IsReclaim, name == "Funded Nursing Care" || name == "Care Charges")
                .Generate();

            item.Quantity = Math.Round((item.ToDate - item.FromDate).Days / 7M, 2);
            item.TotalCost = Math.Round(item.Quantity * item.WeeklyCost, 2);
            item.PriceEffect = item.IsReclaim.GetValueOrDefault() && item.ClaimCollector is ClaimCollector.Supplier
                ? PriceEffect.Subtract
                : PriceEffect.Add;

            return item;
        }
    }
}
