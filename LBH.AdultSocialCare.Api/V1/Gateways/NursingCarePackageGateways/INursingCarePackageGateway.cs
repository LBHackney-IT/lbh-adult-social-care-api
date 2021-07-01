using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways
{
    public interface INursingCarePackageGateway
    {
        public Task<NursingCarePackageDomain> UpdateAsync(NursingCarePackageForUpdateDomain nursingCarePackageForUpdate);

        public Task<NursingCarePackageDomain> CreateAsync(NursingCarePackage nursingCarePackageForCreation);

        public Task<NursingCarePackageDomain> GetAsync(Guid nursingCarePackageId);

        public Task<NursingCarePackageDomain> ChangeStatusAsync(Guid nursingCarePackageId, int statusId);

        public Task<IEnumerable<NursingCarePackageDomain>> ListAsync();

        public Task<IEnumerable<TypeOfNursingCareHomeDomain>> GetListOfTypeOfNursingCareHomeAsync();

        public Task<IEnumerable<NursingCareTypeOfStayOptionDomain>> GetListOfNursingCareTypeOfStayOptionAsync();
    }
}
