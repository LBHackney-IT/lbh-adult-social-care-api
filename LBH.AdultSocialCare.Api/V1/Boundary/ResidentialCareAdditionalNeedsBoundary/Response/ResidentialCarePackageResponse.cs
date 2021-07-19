using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response
{
    public class ResidentialCarePackageResponse
    {
        public Guid Id { get; set; }

        public Guid? ClientId { get; set; }

        public bool IsFixedPeriod { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public bool HasRespiteCare { get; set; }

        public bool HasDischargePackage { get; set; }

        public bool IsThisAnImmediateService { get; set; }

        public bool IsThisUserUnderS117 { get; set; }

        public int? TypeOfStayId { get; set; }

        public string NeedToAddress { get; set; }

        public int? TypeOfResidentialCareHomeId { get; set; }

        public Guid CreatorId { get; set; }

        public Guid? UpdaterId { get; set; }

        public int StatusId { get; set; }

        // From FK values
        public string ClientName { get; set; }
        public int ClientHackneyId { get; set; }
        public string ClientPostCode { get; set; }
        public DateTime? ClientDateOfBirth { get; set; }
        public string ClientPreferredContact { get; set; }
        public string ClientCanSpeakEnglish { get; set; }

        public string StatusName { get; set; }
        public string CreatorName { get; set; }
        public string UpdaterName { get; set; }
        public string PackageName { get; set; }
        public string TypeOfCareHomeName { get; set; }
        public string TypeOfStayOptionName { get; set; }

        public IEnumerable<ResidentialCareAdditionalNeedsResponse> ResidentialCareAdditionalNeeds { get; set; }
    }
}
