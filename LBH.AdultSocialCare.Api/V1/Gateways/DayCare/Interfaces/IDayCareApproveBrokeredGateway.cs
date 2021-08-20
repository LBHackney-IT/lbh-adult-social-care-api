using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces
{
    public interface IDayCareApproveBrokeredGateway
    {
        public Task<DayCareApproveBrokeredDomain> GetAsync(Guid dayCarePackageId);
    }
}
