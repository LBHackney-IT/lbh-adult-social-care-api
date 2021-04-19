using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
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

        public Task<NursingCarePackage> ChangeStatusAsync(Guid nursingCarePackageId, int statusId);

        public Task<IList<NursingCarePackage>> ListAsync();

        public Task<IList<TypeOfNursingCareHome>> GetListOfTypeOfNursingCareHomeAsync();
    }
}
