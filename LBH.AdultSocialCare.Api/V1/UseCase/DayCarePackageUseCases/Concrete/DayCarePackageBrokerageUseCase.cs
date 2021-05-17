using LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Exceptions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class DayCarePackageBrokerageUseCase : IDayCarePackageBrokerageUseCase
    {
        private readonly IDayCareBrokerageInfoGateway _dayCareBrokerageInfoGateway;
        private readonly IDayCarePackageGateway _dayCarePackageGateway;

        public DayCarePackageBrokerageUseCase(IDayCareBrokerageInfoGateway dayCareBrokerageInfoGateway, IDayCarePackageGateway dayCarePackageGateway)
        {
            _dayCareBrokerageInfoGateway = dayCareBrokerageInfoGateway;
            _dayCarePackageGateway = dayCarePackageGateway;
        }

        public async Task<DayCarePackageForBrokerageResponse> GetDayCarePackageForBrokerage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dayCarePackageGateway.GetDayCarePackageForBrokerageDetails(dayCarePackageId).ConfigureAwait(false);
            return dayCarePackage.ToResponse();
        }

        public async Task<IEnumerable<DayCareBrokerageStageResponse>> GetDayCarePackageBrokerageStages()
        {
            var stages = await _dayCareBrokerageInfoGateway.GetDayCareBrokerageStages().ConfigureAwait(false);
            return stages.ToResponse();
        }

        public async Task<Guid> CreateDayPackageBrokerageInfo(DayCareBrokerageInfoForCreationDomain dayCareBrokerageInfoForCreationDomain)
        {
            var dayCarePackageBrokerageInfo = await _dayCareBrokerageInfoGateway
                .GetDayCareBrokerageInfoForPackage(dayCareBrokerageInfoForCreationDomain.DayCarePackageId)
                .ConfigureAwait(false);
            if (dayCarePackageBrokerageInfo != null)
            {
                throw new EntityConflictException(
                    $"Day care package with id {dayCareBrokerageInfoForCreationDomain.DayCarePackageId} already has brokerage info. Use update to change values");
            }
            var brokerageInfoEntity = dayCareBrokerageInfoForCreationDomain.ToDb();
            var id = await _dayCareBrokerageInfoGateway.CreateDayCareBrokerageInfo(brokerageInfoEntity).ConfigureAwait(false);
            return id;
        }
    }
}
