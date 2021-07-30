using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.PrimarySupportReasonBoundary.Response
{
    public class PrimarySupportReasonResponse
    {
        public int PrimarySupportReasonId { get; set; }

        public string PrimarySupportReasonName { get; set; }

        public string CederBudgetCode { get; set; }
    }
}
