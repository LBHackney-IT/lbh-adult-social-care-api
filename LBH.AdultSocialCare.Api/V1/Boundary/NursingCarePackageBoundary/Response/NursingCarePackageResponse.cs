using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Response;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response
{
    public class NursingCarePackageResponse
    {
        public Guid Id { get; set; }

        public Guid? ClientId { get; set; }

        public bool IsFixedPeriod { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public bool IsRespiteCare { get; set; }

        public bool IsDischargePackage { get; set; }

        public bool IsThisAnImmediateService { get; set; }

        public bool IsThisUserUnderS117 { get; set; }

        public int? TypeOfStayId { get; set; }

        public string NeedToAddress { get; set; }

        public int? TypeOfNursingCareHomeId { get; set; }

        public Guid CreatorId { get; set; }

        public Guid? UpdaterId { get; set; }

        public int StatusId { get; set; }

        // From FK values
        public string ClientName { get; set; }

        public string StatusName { get; set; }
        public string CreatorName { get; set; }
        public string UpdaterName { get; set; }
        public string PackageName { get; set; }
        public string TypeOfCareHomeName { get; set; }
        public string TypeOfStayOptionName { get; set; }

        public IEnumerable<NursingCareAdditionalNeedsResponse> NursingCareAdditionalNeeds { get; set; }
    }
}
