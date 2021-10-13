using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions
{
    public static class GatewayQueryExtensions
    {
        public static IQueryable<ResidentialCarePackage> FilterResidentialCareList(this IQueryable<ResidentialCarePackage> residentialCarePackages, int? statusId, string clientName) =>
            residentialCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientName != null ? h.Client.FirstName.ToLower().Contains(clientName.ToLower()) : h.Equals(h)));

        public static IQueryable<ResidentialCarePackage> FilterApprovedResidentialCareList(this IQueryable<ResidentialCarePackage> residentialCarePackages, int? statusId, int? hackneyId, string clientName,
            Guid? socialWorkerId) =>
            residentialCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId != null ? h.Client.HackneyId.ToString().Contains(hackneyId.ToString()) : h.Equals(h)) &&
                (clientName != null ? h.Client.FirstName.ToLower().Contains(clientName.ToLower()) : h.Equals(h)) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId));

        public static IQueryable<ResidentialCarePackage> FilterBrokeredResidentialCareList(this IQueryable<ResidentialCarePackage> residentialCarePackages, int? statusId, int? hackneyId, string clientName,
            Guid? socialWorkerId, int? stageId) =>
            residentialCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId.Equals(null) || h.Client.HackneyId == hackneyId) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId) &&
                (clientName != null ? h.Client.FirstName.ToLower().Contains(clientName.ToLower()) : h.Equals(h)) &&
                (stageId.Equals(null) || h.StageId == stageId));

        public static IQueryable<Client> FilterByName(this IQueryable<Client> clientsQuery, string name) =>
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

        public static IQueryable<CarePackage> FilterCareChargeCarePackageList(this IQueryable<CarePackage> carePackages, string status, string firstName, string lastName,
            DateTime? dateOfBirth, string postCode, int? mosaicId, DateTimeOffset? modifiedAt, Guid? modifiedBy) =>
            carePackages.Where(c =>
                (firstName != null ? c.ServiceUser.FirstName.ToLower().Contains(firstName.ToLower()) : c.Equals(c)) &&
                (lastName != null ? c.ServiceUser.LastName.ToLower().Contains(lastName.ToLower()) : c.Equals(c)) &&
                (dateOfBirth.Equals(null) || c.ServiceUser.DateOfBirth == dateOfBirth) &&
                (postCode != null ? c.ServiceUser.PostCode.ToLower().Contains(postCode.ToLower()) : c.Equals(c)) &&
                (mosaicId.Equals(null) || c.ServiceUser.HackneyId == mosaicId) &&
                (modifiedBy.Equals(null) || c.UpdaterId == modifiedBy) &&
                (modifiedAt.Equals(null) || c.DateUpdated == modifiedAt) &&
                (status != null ? c.Reclaims.Any(r => r.Type == ReclaimType.CareCharge) == (status == "Existing") : c.Equals(c)));
    }
}
