using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces
{
    public interface IResidentialCarePackageGateway
    {
        public Task<ResidentialCarePackageDomain> UpdateAsync(ResidentialCarePackageForUpdateDomain residentialCarePackageForUpdate);

        public Task<ResidentialCarePackageDomain> CreateAsync(ResidentialCarePackage residentialCarePackageForCreation);

        public Task<ResidentialCarePackageDomain> GetAsync(Guid residentialCarePackageId);

        public Task<ResidentialCarePackagePlainDomain> GetPlainAsync(Guid residentialCarePackageId);

        public Task<ResidentialCarePackagePlainDomain> CheckResidentialCarePackageExistsAsync(Guid residentialCarePackageId);

        public Task<ResidentialCarePackageDomain> ChangeStatusAsync(Guid residentialCarePackageId, int statusId);

        public Task<IEnumerable<ResidentialCarePackageDomain>> ListAsync();

        public Task<IEnumerable<TypeOfResidentialCareHomeDomain>> GetListOfTypeOfResidentialCareHomeAsync();

        public Task<IEnumerable<ResidentialCareTypeOfStayOptionDomain>> GetListOfResidentialCareTypeOfStayOptionAsync();

        Task<int> GetClientPackagesCountAsync(Guid clientId);

        Task<List<Guid>> GetUnpaidPackageIdsAsync(DateTimeOffset dateTo);

        Task<List<ResidentialCarePackage>> GetPackagesByIds(List<Guid> packageIds);

        Task<bool> ResetResidentialInvoicePaidUpToDate(List<Guid> residentialCarePackageIds);

        Task RefreshPaidUpToDateAsync(List<ResidentialCarePackage> nursingCarePackages, DateTimeOffset paidUpTo);
    }
}
