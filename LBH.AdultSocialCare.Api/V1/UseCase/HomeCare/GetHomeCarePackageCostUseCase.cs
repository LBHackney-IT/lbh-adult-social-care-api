using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{
    public class GetHomeCarePackageCostUseCase : IGetHomeCarePackageCostUseCase
    {
        private readonly IHomeCarePackageCostGateway _homeCarePackageCostGateway;

        public GetHomeCarePackageCostUseCase(IHomeCarePackageCostGateway homeCarePackageCostGateway)
        {
            _homeCarePackageCostGateway = homeCarePackageCostGateway;
        }

        public async Task<IList<HomeCarePackageCost>> GetAsync(Guid homeCarePackageId)
        {
            var result = await _homeCarePackageCostGateway.GetListAsync(homeCarePackageId).ConfigureAwait(false);
            return result;
        }
    }
}
