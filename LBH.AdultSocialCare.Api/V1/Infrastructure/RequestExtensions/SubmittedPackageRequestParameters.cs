using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions
{
    public class SubmittedPackageRequestParameters : RequestParameters
    {
        public int? StatusId { get; set; }
        public string ClientName { get; set; }
    }
}
