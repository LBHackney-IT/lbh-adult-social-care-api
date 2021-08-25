using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces
{
    public interface IResidentialCareBrokerageGateway
    {
        public Task<ResidentialCareBrokerageInfoDomain> CreateAsync(ResidentialCareBrokerageInfo residentialCareBrokerageInfo);

        Task<ResidentialCareBrokerageInfoDomain> GetAsync(Guid residentialCarePackageId);
        Task<bool> SetStage(Guid residentialCarePackageId, int stageId);
    }
}