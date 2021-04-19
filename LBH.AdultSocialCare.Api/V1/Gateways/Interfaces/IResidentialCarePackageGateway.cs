using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IResidentialCarePackageGateway
    {
        public Task<ResidentialCarePackage> UpsertAsync(ResidentialCarePackage residentialCarePackage);

        public Task<ResidentialCarePackage> GetAsync(Guid residentialCarePackageId);

        public Task<ResidentialCarePackage> ChangeStatusAsync(Guid residentialCarePackageId, int statusId);

        public Task<IList<ResidentialCarePackage>> ListAsync();

        public Task<IList<TypeOfResidentialCareHome>> GetListOfTypeOfResidentialCareHomeAsync();
    }
}
