using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions
{
    public static class GatewayQueryExtensions
    {
        public static IQueryable<HomeCarePackage> FilterHomeCareList(this IQueryable<HomeCarePackage> homeCarePackages, int? statusId, string clientName) =>
            homeCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientName != null ? h.Client.FirstName.ToLower().Contains(clientName.ToLower()) : h.Equals(h)));

        public static IQueryable<ResidentialCarePackage> FilterResidentialCareList(this IQueryable<ResidentialCarePackage> residentialCarePackages, int? statusId, string clientName) =>
            residentialCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientName != null ? h.Client.FirstName.ToLower().Contains(clientName.ToLower()) : h.Equals(h)));

        public static IQueryable<NursingCarePackage> FilterNursingCareList(this IQueryable<NursingCarePackage> nursingCarePackages, int? statusId, string clientName) =>
            nursingCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientName != null ? h.Client.FirstName.ToLower().Contains(clientName.ToLower()) : h.Equals(h)));

        public static IQueryable<DayCarePackage> FilterDayCareList(this IQueryable<DayCarePackage> dayCarePackages, int? statusId, string clientName) =>
            dayCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientName != null ? h.Client.FirstName.ToLower().Contains(clientName.ToLower()) : h.Equals(h)));

        public static IQueryable<ResidentialCarePackage> FilterApprovedResidentialCareList(this IQueryable<ResidentialCarePackage> residentialCarePackages, int? statusId, int? hackneyId, string clientName,
            Guid? socialWorkerId) =>
            residentialCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId != null ? h.Client.HackneyId.ToString().Contains(hackneyId.ToString()) : h.Equals(h)) &&
                (clientName != null ? h.Client.FirstName.ToLower().Contains(clientName.ToLower()) : h.Equals(h)) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId));

        public static IQueryable<HomeCarePackage> FilterApprovedHomeCareList(this IQueryable<HomeCarePackage> homeCarePackages, int? statusId, int? hackneyId, string clientName,
            Guid? socialWorkerId) =>
            homeCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId.Equals(null) || h.Client.HackneyId == hackneyId) &&
                (clientName != null ? $"{h.Client.FirstName} {h.Client.LastName}".ToLower().Contains(clientName.ToLower()) : h.Equals(h)) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId));

        public static IQueryable<DayCarePackage> FilterApprovedDayCareList(this IQueryable<DayCarePackage> dayCarePackages, int? statusId, int? hackneyId,
            Guid? socialWorkerId) =>
            dayCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId.Equals(null) || h.Client.HackneyId == hackneyId) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId));

        public static IQueryable<NursingCarePackage> FilterApprovedNursingCareList(this IQueryable<NursingCarePackage> nursingCarePackages, int? statusId, int? hackneyId, string clientName,
            Guid? socialWorkerId) =>
            nursingCarePackages.Where(h =>
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

        public static IQueryable<HomeCarePackage> FilterBrokeredHomeCareList(this IQueryable<HomeCarePackage> homeCarePackages, int? statusId, int? hackneyId, string clientName,
            Guid? socialWorkerId, int? stageId) =>
            homeCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId.Equals(null) || h.Client.HackneyId == hackneyId) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId) &&
                (clientName != null ? $"{h.Client.FirstName} {h.Client.LastName}".ToLower().Contains(clientName.ToLower()) : h.Equals(h)) &&
                (stageId.Equals(null) || h.StageId == stageId));

        public static IQueryable<NursingCarePackage> FilterBrokeredNursingCareList(this IQueryable<NursingCarePackage> nursingCarePackages, int? statusId, int? hackneyId, string clientName,
            Guid? socialWorkerId, int? stageId) =>
            nursingCarePackages.Where(h =>
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

        public static IQueryable<NursingCarePackage> FilterCareChargeNursingCareList(this IQueryable<NursingCarePackage> nursingCarePackages, string firstName, string lastName,
            DateTime? dateOfBirth, string postCode, int? mosaicId, DateTimeOffset? modifiedAt, Guid? modifiedBy) =>
            nursingCarePackages.Where(h =>
            (firstName != null ? h.Client.FirstName.ToLower().Contains(firstName.ToLower()) : h.Equals(h)) &&
            (lastName != null ? h.Client.LastName.ToLower().Contains(lastName.ToLower()) : h.Equals(h)) &&
            (dateOfBirth.Equals(null) || h.Client.DateOfBirth == dateOfBirth) &&
            (postCode != null ? h.Client.PostCode.ToLower().Contains(postCode.ToLower()) : h.Equals(h)) &&
            (mosaicId.Equals(null) || h.Client.HackneyId == mosaicId) &&
            (modifiedBy.Equals(null) || h.UpdaterId == modifiedBy) &&
            (modifiedAt.Equals(null) || h.DateUpdated == modifiedAt));

        public static IQueryable<ResidentialCarePackage> FilterCareChargeResidentialCareList(this IQueryable<ResidentialCarePackage> residentialCarePackages, string firstName, string lastName,
            DateTime? dateOfBirth, string postCode, int? mosaicId, DateTimeOffset? modifiedAt, Guid? modifiedBy) =>
            residentialCarePackages.Where(h =>
                (firstName != null ? h.Client.FirstName.ToLower().Contains(firstName.ToLower()) : h.Equals(h)) &&
                (lastName != null ? h.Client.LastName.ToLower().Contains(lastName.ToLower()) : h.Equals(h)) &&
                (dateOfBirth.Equals(null) || h.Client.DateOfBirth == dateOfBirth) &&
                (postCode != null ? h.Client.PostCode.ToLower().Contains(postCode.ToLower()) : h.Equals(h)) &&
                (mosaicId.Equals(null) || h.Client.HackneyId == mosaicId) &&
                (modifiedBy.Equals(null) || h.UpdaterId == modifiedBy) &&
                (modifiedAt.Equals(null) || h.DateUpdated == modifiedAt));
    }
}
