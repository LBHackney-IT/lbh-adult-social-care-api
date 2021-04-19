using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.HomeCare;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Factories
{

    public static class HomeCarePackageFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static HomeCarePackageDomain ToDomain(HomeCarePackage homeCarePackageEntity)
        {
            return new HomeCarePackageDomain
            {
                Id = homeCarePackageEntity.Id,
                ClientId = homeCarePackageEntity.ClientId,
                Clients = homeCarePackageEntity.Clients,
                StartDate = homeCarePackageEntity.StartDate,
                EndDate = homeCarePackageEntity.EndDate,
                IsFixedPeriod = homeCarePackageEntity.IsFixedPeriod,
                IsOngoingPeriod = homeCarePackageEntity.IsOngoingPeriod,
                IsThisAnImmediateService = homeCarePackageEntity.IsThisAnImmediateService,
                IsThisuserUnderS117 = homeCarePackageEntity.IsThisuserUnderS117,
                CreatorId = homeCarePackageEntity.CreatorId,
                UpdatorId = homeCarePackageEntity.UpdatorId,
                StatusId = homeCarePackageEntity.StatusId,
                Status = homeCarePackageEntity.Status
            };
        }

        public static HomeCarePackage ToEntity(HomeCarePackageDomain homeCarePackageDomain)
        {
            return new HomeCarePackage
            {
                Id = homeCarePackageDomain.Id,
                ClientId = homeCarePackageDomain.ClientId,
                Clients = homeCarePackageDomain.Clients,
                StartDate = homeCarePackageDomain.StartDate,
                EndDate = homeCarePackageDomain.EndDate,
                IsFixedPeriod = homeCarePackageDomain.IsFixedPeriod,
                IsOngoingPeriod = homeCarePackageDomain.IsOngoingPeriod,
                IsThisAnImmediateService = homeCarePackageDomain.IsThisAnImmediateService,
                IsThisuserUnderS117 = homeCarePackageDomain.IsThisuserUnderS117,
                CreatorId = homeCarePackageDomain.CreatorId,
                UpdatorId = homeCarePackageDomain.UpdatorId,
                StatusId = homeCarePackageDomain.StatusId,
                Status = homeCarePackageDomain.Status
            };
        }

        public static HomeCarePackageResponse ToResponse(HomeCarePackageDomain homeCarePackageDomain)
        {
            return new HomeCarePackageResponse
            {
                Id = homeCarePackageDomain.Id,
                ClientId = homeCarePackageDomain.ClientId,
                Clients = homeCarePackageDomain.Clients,
                StartDate = homeCarePackageDomain.StartDate,
                EndDate = homeCarePackageDomain.EndDate,
                IsFixedPeriod = homeCarePackageDomain.IsFixedPeriod,
                IsOngoingPeriod = homeCarePackageDomain.IsOngoingPeriod,
                IsThisAnImmediateService = homeCarePackageDomain.IsThisAnImmediateService,
                IsThisuserUnderS117 = homeCarePackageDomain.IsThisuserUnderS117,
                CreatorId = homeCarePackageDomain.CreatorId,
                UpdatorId = homeCarePackageDomain.UpdatorId,
                StatusId = homeCarePackageDomain.StatusId,
                Status = homeCarePackageDomain.Status
            };
        }

        public static HomeCarePackageDomain ToDomain(HomeCarePackageRequest homeCarePackageEntity)
        {
            return new HomeCarePackageDomain
            {
                Id = homeCarePackageEntity.Id,
                ClientId = homeCarePackageEntity.ClientId,
                StartDate = homeCarePackageEntity.StartDate,
                EndDate = homeCarePackageEntity.EndDate,
                IsFixedPeriod = homeCarePackageEntity.IsFixedPeriod,
                IsOngoingPeriod = homeCarePackageEntity.IsOngoingPeriod,
                IsThisAnImmediateService = homeCarePackageEntity.IsThisAnImmediateService,
                IsThisuserUnderS117 = homeCarePackageEntity.IsThisClientUnderS117,
                CreatorId = homeCarePackageEntity.CreatorId,
                UpdatorId = homeCarePackageEntity.UpdatorId,
                StatusId = homeCarePackageEntity.StatusId
            };
        }

        public static IList<HomeCarePackageDomain> ToDomain(this IList<HomeCarePackage> homeCarePackagesEntity)
        {
            return _mapper.Map<IList<HomeCarePackageDomain>>(homeCarePackagesEntity);
        }

        public static IList<HomeCarePackageResponse> ToResponse(this IList<HomeCarePackageDomain> homeCarePackagesDomain)
        {
            return _mapper.Map<IList<HomeCarePackageResponse>>(homeCarePackagesDomain);
        }
    }

}
