using System;

namespace LBH.AdultSocialCare.Functions.Payruns.Services
{
    [Flags]
    public enum InvoiceTypes
    {
        Normal = 1,
        Refund = 2,
        All = Normal | Refund
    }
}
