using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Data.Extensions
{
    public static class GatewayQueryExtensions
    {
        public static IQueryable<ServiceUser> FilterByName(this IQueryable<ServiceUser> clientsQuery, string name) =>
            clientsQuery.Where(c => String.IsNullOrEmpty(name)
                                    || c.FirstName.ToLower().Contains(name.ToLower())
                                    || c.LastName.ToLower().Contains(name.ToLower()));

        public static IQueryable<Supplier> FilterByName(this IQueryable<Supplier> clientsQuery, string name) =>
            clientsQuery.Where(s => String.IsNullOrEmpty(name)
                                    || s.SupplierName.ToLower().Contains(name.ToLower()));

        public static IQueryable<CarePackage> FilterBrokerViewPackages(this IQueryable<CarePackage> packages,
            Guid? serviceUserId, string serviceUserName, PackageStatus? status, Guid? brokerId,
            DateTimeOffset? fromDate, DateTimeOffset? toDate)
        {
            var searchTerms = serviceUserName?.Split(' ').ToList();
            string searchTermFirst = searchTerms?.First();
            string searchTermSecond = searchTerms != null && searchTerms.Count > 1 ? searchTerms[1] : null;

            return packages.Where(package => (serviceUserId == null || package.ServiceUserId.Equals(serviceUserId))
                                             && (String.IsNullOrEmpty(searchTermFirst) || package.ServiceUser.FirstName
                                                 .ToLower().Contains(searchTermFirst.ToLower()))
                                             && (searchTermSecond != null
                                                 ? package.ServiceUser.LastName.ToLower()
                                                     .Contains(searchTermSecond.ToLower())
                                                 : package.Equals(package))
                                             && (status == null || package.Status.Equals(status))
                                             && (brokerId == null || package.BrokerId.Equals(brokerId))
                                             && (fromDate == null ||
                                                 package.Details
                                                     .FirstOrDefault(d => d.Type == PackageDetailType.CoreCost)
                                                     .StartDate >= fromDate)
                                             && (toDate == null ||
                                                 package.Details
                                                     .FirstOrDefault(d => d.Type == PackageDetailType.CoreCost)
                                                     .EndDate <= toDate));
        }

        public static IQueryable<CarePackage> FilterApprovableCarePackages(this IQueryable<CarePackage> packages,
            Guid? serviceUserId, string serviceUserName, PackageStatus? packageStatus, PackageType? packageType,
            Guid? approverId, DateTimeOffset? fromDate, DateTimeOffset? toDate, PackageStatus[] statusesToInclude) =>
            packages.Where(package => (serviceUserId == null || package.ServiceUserId.Equals(serviceUserId))
                                      && (String.IsNullOrEmpty(serviceUserName)
                                          || package.ServiceUser.FirstName.ToLower().Contains(serviceUserName.ToLower())
                                          || package.ServiceUser.LastName.ToLower().Contains(serviceUserName.ToLower()))
                                      && ((packageStatus == null && statusesToInclude.Contains(package.Status) ||
                                           package.Status.Equals(packageStatus)))
                                      && (packageType == null || package.PackageType.Equals(packageType))
                                      && (approverId == null || package.ApproverId.Equals(approverId))
                                      && (fromDate == null ||
                                          package.Details.FirstOrDefault(d => d.Type == PackageDetailType.CoreCost)
                                              .StartDate >= fromDate)
                                      && (toDate == null ||
                                          package.Details.FirstOrDefault(d => d.Type == PackageDetailType.CoreCost)
                                              .EndDate <= toDate)); // TODO: VK: Review end date (can be empty)

        public static IQueryable<User> FilterAppUsers(this IQueryable<User> users, string searchTerm = "") =>
            users.Where(u => (string.IsNullOrEmpty(searchTerm) || (EF.Functions.ILike(u.Name, $"%{searchTerm}%") ||
                                                                   EF.Functions.ILike(u.Email, $"%{searchTerm}%"))));

        public static IQueryable<CarePackage> FilterCareChargeCarePackageList(this IQueryable<CarePackage> carePackages,
            string status, Guid? modifiedBy, string orderByDate)
        {
            var filteredList = carePackages.Where(c =>
                (modifiedBy.Equals(null) || c.UpdaterId == modifiedBy) &&
                (status != null
                    ? c.Reclaims.Any(r =>
                          r.Type == ReclaimType.CareCharge && r.SubType != ReclaimSubType.CareChargeProvisional) ==
                      (status == "Existing")
                    : c.Equals(c)));

            switch (orderByDate)
            {
                case "desc":
                    filteredList = filteredList.OrderByDescending(s => s.DateCreated);
                    break;

                case "asc":
                    filteredList = filteredList.OrderBy(s => s.DateCreated);
                    break;

                default:
                    filteredList = filteredList.OrderBy(s => s.DateCreated);
                    break;
            }

            return filteredList;
        }

        public static IQueryable<ServiceUser> FilterServiceUser(this IQueryable<ServiceUser> serviceUsers,
            IEnumerable<Guid> serviceUserIds, string firstName, string lastName,
            string postCode, DateTime? dateOfBirth, int? hackneyId, bool hasPackages)
        {
            var filteredList = serviceUsers.Where(s =>
                (firstName != null ? s.FirstName.ToLower().Contains(firstName.ToLower()) : s.Equals(s)) &&
                (lastName != null ? s.LastName.ToLower().Contains(lastName.ToLower()) : s.Equals(s)) &&
                (dateOfBirth.Equals(null) || s.DateOfBirth == dateOfBirth) &&
                (postCode != null ? s.PostCode.ToLower().Contains(postCode.ToLower()) : s.Equals(s)) &&
                (hackneyId.Equals(null) || s.HackneyId == hackneyId));

            if (hasPackages)
            {
                filteredList = filteredList.Where(su => serviceUserIds.Contains(su.Id));
            }

            return filteredList;
        }

        public static IQueryable<PayrunInvoice> FilterPayRunInvoices(this IQueryable<PayrunInvoice> invoices,
            PayRunDetailsQueryParameters parameters)
        {
            // Explode search term to tokens
            var searchTokens = Regex.Split(parameters.SearchTerm ?? string.Empty, "\\s+").ToList();
            var searchPredicate = PredicateBuilder.New<PayrunInvoice>(true);
            foreach (var searchToken in searchTokens)
            {
                searchPredicate = searchPredicate.Or(e =>
                    EF.Functions.ILike(e.Invoice.ServiceUser.FirstName, $"%{searchToken}%")
                    || EF.Functions.ILike(e.Invoice.ServiceUser.LastName, $"%{searchToken}%")
                    || EF.Functions.ILike(e.InvoiceId.ToString(), $"%{searchToken}%")
                    || EF.Functions.ILike(e.Invoice.Number, $"%{searchToken}%")
                    || EF.Functions.ILike(e.Invoice.Supplier.SupplierName ?? "", $"%{searchToken}%"));
            }

            return invoices.Where(searchPredicate).Where(invoice =>
                (parameters.PackageType == null || invoice.Invoice.Package.PackageType == parameters.PackageType)
                && (parameters.InvoiceStatus == null || invoice.InvoiceStatus == parameters.InvoiceStatus)
                && (parameters.FromDate == null || invoice.Invoice.DateCreated >= parameters.FromDate)
                && (parameters.ToDate == null || invoice.Invoice.DateCreated < parameters.ToDate));
        }

        public static IQueryable<Payrun> FilterPayRunList(this IQueryable<Payrun> payRuns, string searchTerm,
            PayrunType? payrunType, PayrunStatus? payrunStatus, DateTimeOffset? dateFrom,
            DateTimeOffset? dateTo) =>
            payRuns.Where(e => (
                (searchTerm == null || e.Id.ToString().ToLower().Contains(searchTerm.ToLower()) || e.Number.ToLower().Contains(searchTerm.ToLower()))
                && (payrunType == null || e.Type.Equals(payrunType))
                && (payrunStatus == null || e.Status.Equals(payrunStatus))
                && (dateFrom == null || e.DateCreated >= dateFrom)
                && (dateTo == null || e.DateCreated <= dateTo)
            ));
    }
}
