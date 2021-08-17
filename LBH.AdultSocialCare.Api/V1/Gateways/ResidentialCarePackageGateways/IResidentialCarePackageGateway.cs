using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways
{
    public interface IResidentialCarePackageGateway
    {
        public Task<ResidentialCarePackageDomain> UpdateAsync(ResidentialCarePackageForUpdateDomain residentialCarePackageForUpdate);

        public Task<ResidentialCarePackageDomain> CreateAsync(ResidentialCarePackage residentialCarePackageForCreation);

        public Task<ResidentialCarePackageDomain> GetAsync(Guid residentialCarePackageId);

        public Task<ResidentialCarePackageDomain> ChangeStatusAsync(Guid residentialCarePackageId, int statusId);

        public Task<IEnumerable<ResidentialCarePackageDomain>> ListAsync();

        public Task<IEnumerable<TypeOfResidentialCareHomeDomain>> GetListOfTypeOfResidentialCareHomeAsync();

        public Task<IEnumerable<ResidentialCareTypeOfStayOptionDomain>> GetListOfResidentialCareTypeOfStayOptionAsync();

        public Task<int> GetClientPackagesCountAsync(Guid clientId);

        Task<bool> GenerateResidentialCareInvoices(DateTimeOffset dateTo);

        Task<bool> ResetResidentialInvoicePaidUpToDate(List<Guid> residentialCarePackageIds);
    }
}
