using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareBrokerageGateways
{
    public interface INursingCareBrokerageGateway
    {
        public Task<NursingCareBrokerageInfoDomain> CreateAsync(NursingCareBrokerageInfo nursingCareBrokerageInfo);

        Task<NursingCareBrokerageInfoDomain> GetAsync(Guid nursingCarePackageId);

        Task<bool> SetStage(Guid nursingCarePackageId, int stageId);
    }
}
