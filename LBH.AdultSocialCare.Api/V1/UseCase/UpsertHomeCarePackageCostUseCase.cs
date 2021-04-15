using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class UpsertHomeCarePackageCostUseCase : IUpsertHomeCarePackageCostUseCase
    {
        private readonly IHomeCarePackageCostGateway _gateway;
        public UpsertHomeCarePackageCostUseCase(IHomeCarePackageCostGateway homeCarePackageCostGateway)
        {
            _gateway = homeCarePackageCostGateway;
        }

        public async Task<HomeCarePackageCostDomain> ExecuteAsync(HomeCarePackageCostDomain homeCarePackageCost)
        {
            var homeCarePackageCostEntity = HomeCarePackageCostFactory.ToEntity(homeCarePackageCost);
            homeCarePackageCostEntity = await _gateway.UpsertAsync(homeCarePackageCostEntity).ConfigureAwait(false);
            if (homeCarePackageCostEntity == null) return homeCarePackageCost = null;
            else
            {
                homeCarePackageCost = HomeCarePackageCostFactory.ToDomain(homeCarePackageCostEntity);
            }
            return homeCarePackageCost;
        }
    }
}
