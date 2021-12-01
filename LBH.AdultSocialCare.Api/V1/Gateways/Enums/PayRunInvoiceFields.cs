using System;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Enums
{
    [Flags]
    public enum PayRunInvoiceFields
    {
        None = 0,
        Creator = 1,
        Updater = 2,
        Payrun = 4,
        Invoice = 8,
        InvoiceItems = 16,
        Package = 32,
        Supplier = 64,
        ServiceUser = 128,
        All = Creator | Updater | Payrun | Invoice | InvoiceItems | Package | Supplier | ServiceUser
    }
}
