using System;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Enums
{
    [Flags]
    public enum PayRunFields
    {
        None = 0,
        Creator = 1,
        Updater = 2,
        PayrunInvoices = 4,
        PayrunHistories = 8,
        All = Creator | Updater | PayrunInvoices | PayrunHistories
    }
}
