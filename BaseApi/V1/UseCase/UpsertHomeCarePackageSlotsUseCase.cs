using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class UpsertHomeCarePackageSlotsUseCase : IUpsertHomeCarePackageSlotsUseCase
    {
        private readonly IHomeCarePackageSlotsGateway _gateway;
        public UpsertHomeCarePackageSlotsUseCase(IHomeCarePackageSlotsGateway homeCarePackageSlotsGateway)
        {
            _gateway = homeCarePackageSlotsGateway;
        }
        public async Task<HomeCarePackageSlotsDomain> ExecuteAsync(HomeCarePackageSlotsDomain homeCarePackageSlots)
        {
            HomeCarePackageSlotsList homeCarePackageSlotsEntity = HomeCarePackageSlotsFactory.ToEntity(homeCarePackageSlots);
            homeCarePackageSlotsEntity = await _gateway.UpsertAsync(homeCarePackageSlotsEntity).ConfigureAwait(false);
            if (homeCarePackageSlotsEntity == null) return homeCarePackageSlots = null;
            else
            {
                homeCarePackageSlots = HomeCarePackageSlotsFactory.ToDomain(homeCarePackageSlotsEntity);
            }
            return homeCarePackageSlots;
        }
    }
}
