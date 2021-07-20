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
        public static IQueryable<HomeCarePackage> FilterHomeCareList(this IQueryable<HomeCarePackage> homeCarePackages, int? statusId, Guid? clientId) =>
            homeCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientId.Equals(null) || h.ClientId == clientId));

        public static IQueryable<ResidentialCarePackage> FilterResidentialCareList(this IQueryable<ResidentialCarePackage> residentialCarePackages, int? statusId, Guid? clientId) =>
            residentialCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientId.Equals(null) || h.ClientId == clientId));

        public static IQueryable<NursingCarePackage> FilterNursingCareList(this IQueryable<NursingCarePackage> nursingCarePackages, int? statusId, Guid? clientId) =>
            nursingCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientId.Equals(null) || h.ClientId == clientId));

        public static IQueryable<DayCarePackage> FilterDayCareList(this IQueryable<DayCarePackage> dayCarePackages, int? statusId, Guid? clientId) =>
            dayCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (clientId.Equals(null) || h.ClientId == clientId));

        public static IQueryable<ResidentialCarePackage> FilterApprovedResidentialCareList(this IQueryable<ResidentialCarePackage> residentialCarePackages, int? statusId, int? hackneyId, Guid? clientId,
            Guid? socialWorkerId) =>
            residentialCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId.Equals(null) || h.Client.HackneyId == hackneyId) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId) &&
                (clientId.Equals(null) || h.ClientId == clientId));

        public static IQueryable<HomeCarePackage> FilterApprovedHomeCareList(this IQueryable<HomeCarePackage> homeCarePackages, int? statusId, int? hackneyId, Guid? clientId,
            Guid? socialWorkerId) =>
            homeCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId.Equals(null) || h.Client.HackneyId == hackneyId) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId) &&
                (clientId.Equals(null) || h.ClientId == clientId));

        public static IQueryable<DayCarePackage> FilterApprovedDayCareList(this IQueryable<DayCarePackage> dayCarePackages, int? statusId, int? hackneyId, Guid? clientId,
            Guid? socialWorkerId) =>
            dayCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId.Equals(null) || h.Client.HackneyId == hackneyId) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId) &&
                (clientId.Equals(null) || h.ClientId == clientId));

        public static IQueryable<NursingCarePackage> FilterApprovedNursingCareList(this IQueryable<NursingCarePackage> nursingCarePackages, int? statusId, int? hackneyId, Guid? clientId,
            Guid? socialWorkerId) =>
            nursingCarePackages.Where(h =>
                (statusId.Equals(null) || h.StatusId == statusId) &&
                (hackneyId.Equals(null) || h.Client.HackneyId == hackneyId) &&
                (socialWorkerId.Equals(null) || h.CreatorId == socialWorkerId) &&
                (clientId.Equals(null) || h.ClientId == clientId));
    }
}
