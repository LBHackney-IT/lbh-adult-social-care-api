using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;

namespace LBH.AdultSocialCare.Api.V1.BusinessRules
{
    public class GenericPackage
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public int? SupplierId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? PaidUpTo { get; set; }
        public BrokerageInfo BrokerageInfo { get; set; }
        public PackageCareChargeDomain CareCharge { get; set; }

        public object OriginalPackage { get; set; }
    }

    public class BrokerageInfo
    {
        public decimal Core { get; set; }
        public ICollection<AdditionalNeedsCost> AdditionalNeedsCosts { get; set; }
    }

    public class AdditionalNeedsCost
    {
        public AdditionalNeedsPaymentTypeDomain AdditionalNeedsPaymentType { get; set; }

        public decimal Cost { get; set; }
    }

    public class PackageCareChargeDomain
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public int PackageTypeId { get; set; }
        public bool IsProvisional { get; set; }
        public ICollection<CareChargeElementDomain> CareChargeElements { get; set; }
    }

    public class CareChargeElementDomain
    {
        public Guid Id { get; set; }
        public Guid CareChargeId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int ClaimCollectorId { get; set; }
        public string ClaimReasons { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset? PaidUpTo { get; set; }
        public DateTimeOffset? PreviousPaidUpTo { get; set; }
        public PackageCareCharge PackageCareCharge { get; set; }
        public CareChargeStatus CareChargeStatus { get; set; }
        public CareChargeType CareChargeType { get; set; }
        public PackageCostClaimer ClaimCollector { get; set; }
    }
}
