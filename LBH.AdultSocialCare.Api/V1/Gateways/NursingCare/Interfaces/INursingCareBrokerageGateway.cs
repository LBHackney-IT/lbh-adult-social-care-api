using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface INursingCareBrokerageGateway
    {
        public Task<NursingCareBrokerageInfoDomain> CreateAsync(NursingCareBrokerageInfo nursingCareBrokerageInfo);

        Task<NursingCareBrokerageInfoDomain> GetAsync(Guid nursingCarePackageId);

        Task<bool> SetStage(Guid nursingCarePackageId, int stageId);
    }
}
