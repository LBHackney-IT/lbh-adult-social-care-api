using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface INursingCarePackageGateway
    {
        public Task<NursingCarePackage> UpsertAsync(NursingCarePackage residentialCarePackage);

        public Task<NursingCarePackage> GetAsync(Guid nursingCarePackageId);
    }
}
