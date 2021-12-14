using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

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

        Task<List<CarePackage>> GetServiceUserPackagesAsync(Guid serviceUserId, PackageFields fields = PackageFields.None, bool trackChanges = false);

        Task<int> GetServiceUserActivePackagesCount(Guid serviceUserId, PackageType packageType, Guid? excludePackageId = null);

        Task<PagedList<CarePackageApprovableListItemDomain>> GetApprovablePackagesAsync(ApprovableCarePackagesQueryParameters parameters, PackageStatus[] statusesToInclude);

        Task DeletePackage(Guid packageId);
    }
}
