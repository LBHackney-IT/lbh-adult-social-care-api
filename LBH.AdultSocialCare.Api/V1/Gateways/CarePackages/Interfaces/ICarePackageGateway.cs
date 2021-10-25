using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces
{
    public interface ICarePackageGateway
    {
        Task<BrokerPackageViewDomain> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters);

        Task<CarePackage> GetPackageAsync(Guid packageId, PackageFields fields = PackageFields.None, bool trackChanges = false);

        Task<CarePackage> GetPackagePlainAsync(Guid packageId, bool trackChanges = false);

        Task<List<CarePackageReclaim>> GetCarePackageReclaimsAsync(Guid packageId, ReclaimType type,
            ReclaimSubType? subType = null, bool trackChanges = false);

        Task<IEnumerable<CarePackageListItemDomain>> GetAllPackagesAsync();

        void Create(CarePackage newCarePackage);

        Task DeleteReclaimsForPackage(Guid packageId, ReclaimType reclaimType);

        Task<List<Guid>> GetUnpaidPackageIdsAsync(DateTimeOffset dateTo);

        Task<List<CarePackage>> GetByIdsAsync(IEnumerable<Guid> packageIds, PackageFields fields = PackageFields.All);

        Task<List<CarePackage>> GetServiceUserPackagesAsync(Guid serviceUserId, PackageFields fields = PackageFields.None, bool trackChanges = false);

        Task<int> GetServiceUserActivePackagesCount(Guid serviceUserId, PackageType packageType, Guid? excludePackageId = null);

        Task DeletePackage(Guid packageId);
    }
}
