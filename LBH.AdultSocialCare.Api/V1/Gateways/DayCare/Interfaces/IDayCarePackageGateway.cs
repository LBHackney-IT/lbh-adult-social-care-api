using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces
{
    public interface IDayCarePackageGateway
    {
        Task<Guid> CreateDayCarePackage(DayCarePackage dayCarePackage);
        Task<Guid> CreateDayCarePackageHistory(DayCareApprovalHistory dayCareApprovalHistory);
        Task<DayCarePackageDomain> UpdateDayCarePackage(DayCarePackageForUpdateDomain dayCarePackageForUpdate);
        Task<DayCarePackageDomain> GetDayCarePackage(Guid dayCarePackageId);
        Task<Guid> UpdateDayCarePackageStatus(Guid dayCarePackageId, int newStatusId);
        Task<int> GetDayCareStatusByName(string statusName);
        Task<DayCarePackageForApprovalDetailsDomain> GetDayCarePackageForApprovalDetails(Guid dayCarePackageId);
        Task<DayCarePackageForBrokerageDomain> GetDayCarePackageForBrokerageDetails(Guid dayCarePackageId);
        Task<IEnumerable<DayCarePackageDomain>> GetDayCarePackageList();
        Task CreateEscortPackage(EscortPackage escortPackage);
        Task CreateTransportPackage(TransportPackage transportPackage);
        Task CreateTransportEscortPackage(TransportEscortPackage transportEscortPackage);
    }
}