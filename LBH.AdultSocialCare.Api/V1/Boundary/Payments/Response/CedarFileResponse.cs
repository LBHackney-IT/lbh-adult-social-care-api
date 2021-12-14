using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class CedarFileResponse
    {
        public MemoryStream Stream { get; set; }
        public string PayRunNumber { get; set; }
    }
}
