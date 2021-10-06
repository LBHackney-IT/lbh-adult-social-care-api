using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageGateway
    {
        Task<BrokerPackageViewDomain> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters);

        Task<CarePackage> GetPackageAsync(Guid packageId, PackageFields fields = PackageFields.All);

        Task<CarePackage> GetPackagePlainAsync(Guid packageId, bool trackChanges = false);

        Task<IEnumerable<CarePackageListItemDomain>> GetAllPackagesAsync();

        Task<CarePackageSettingsDomain> GetCarePackageSettingsAsync(Guid carePackageId);

        void Create(CarePackage newCarePackage);

        Task<List<Guid>> GetUnpaidPackageIdsAsync(DateTimeOffset dateTo);

        Task<List<CarePackage>> GetByIdsAsync(IEnumerable<Guid> packageIds, PackageFields fields = PackageFields.All);
    }
}
