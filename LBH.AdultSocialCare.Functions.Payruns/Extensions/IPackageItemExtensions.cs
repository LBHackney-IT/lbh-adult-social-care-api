using System;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IPackageItemExtensions
    {
        public static bool IsReferenced(this IPackageItem packageItem, InvoiceItem invoiceItem)
        {
            return packageItem switch
            {
                CarePackageDetail _ => packageItem.Id == invoiceItem.CarePackageDetailId,
                CarePackageReclaim _ => packageItem.Id == invoiceItem.CarePackageReclaimId,
                _ => throw new InvalidOperationException($"Unsupported package item type {packageItem.GetType()}")
            };
        }
    }
}
