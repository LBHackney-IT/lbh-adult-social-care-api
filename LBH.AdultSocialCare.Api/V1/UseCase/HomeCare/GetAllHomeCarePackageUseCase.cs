using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{
    public class GetAllHomeCarePackageUseCase : IGetAllHomeCarePackageUseCase
    {
        private readonly IHomeCarePackageGateway _homeCarePackageGateway;

        public GetAllHomeCarePackageUseCase(IHomeCarePackageGateway homeCarePackageGateway)
        {
            _homeCarePackageGateway = homeCarePackageGateway;
        }

        public async Task<IList<HomeCarePackage>> GetAllAsync()
        {
            var homeCarePackages = await _homeCarePackageGateway.ListAsync().ConfigureAwait(false);
            return homeCarePackages;
        }
    }
}
