using System;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Enums
{
    [Flags]
    public enum PackageFields
    {
        None = 0,
        Details = 1,
        Reclaims = 2,
        Settings = 4,
        Supplier = 8,
        Histories = 16,
        ServiceUser = 32,
        PrimarySupportReason = 64,
        Broker = 128,
        Approver = 256,
        All = Details | Reclaims | Settings | Supplier | Histories | ServiceUser | PrimarySupportReason,
        PackageHistory = Broker | Approver | Histories
    }
}
