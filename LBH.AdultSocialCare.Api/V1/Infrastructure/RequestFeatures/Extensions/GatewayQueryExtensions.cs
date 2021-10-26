using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions
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

        public static IQueryable<CarePackage> FilterBrokerViewPackages(this IQueryable<CarePackage> packages, Guid? serviceUserId, string serviceUserName, PackageStatus? status, Guid? brokerId, DateTimeOffset? fromDate, DateTimeOffset? toDate) =>
            packages.Where(package => (serviceUserId == null || package.ServiceUserId.Equals(serviceUserId))
                                && (String.IsNullOrEmpty(serviceUserName)
                                    || package.ServiceUser.FirstName.ToLower().Contains(serviceUserName.ToLower())
                                    || package.ServiceUser.LastName.ToLower().Contains(serviceUserName.ToLower()))
                                && (status == null || package.Status.Equals(status))
                                && (brokerId == null || package.BrokerId.Equals(brokerId))
                                && (fromDate == null || package.DateCreated >= fromDate)
                                && (toDate == null || package.DateCreated <= toDate));

        public static IQueryable<User> FilterAppUsers(this IQueryable<User> users, string searchTerm = "") =>
            users.Where(u => (string.IsNullOrEmpty(searchTerm) || (EF.Functions.ILike(u.Name, $"%{searchTerm}%") || EF.Functions.ILike(u.Email, $"%{searchTerm}%"))));

        public static IQueryable<CarePackage> FilterCareChargeCarePackageList(this IQueryable<CarePackage> carePackages,
            string status, Guid? modifiedBy, string orderByDate)
        {
            var filteredList = carePackages.Where(c =>
                (modifiedBy.Equals(null) || c.UpdaterId == modifiedBy) &&
                (status != null ? c.Reclaims.Any(r => r.Type == ReclaimType.CareCharge && r.SubType != ReclaimSubType.CareChargeProvisional) == (status == "Existing") : c.Equals(c)));

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

        public static IQueryable<ServiceUser> FilterServiceUser(this IQueryable<ServiceUser> serviceUsers, IEnumerable<Guid> serviceUserIds, string firstName, string lastName,
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
    }
}
