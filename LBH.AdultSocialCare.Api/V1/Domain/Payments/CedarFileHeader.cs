using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class CedarFileHeader
    {
        public decimal TotalValueOfInvoices { get; set; }
        public int TotalNumberOfInvoices { get; set; }

    }
}
