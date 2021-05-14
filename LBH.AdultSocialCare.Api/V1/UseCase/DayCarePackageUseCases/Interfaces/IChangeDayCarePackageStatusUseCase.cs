using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface IChangeDayCarePackageStatusUseCase
    {
        Task<Guid> ChangeDayCarePackageStatus(Guid dayCarePackageId, int newStatusId);
        Task<Guid> ApproveDayCarePackageDetails(Guid dayCarePackageId);
        Task<Guid> RejectDayCarePackageDetails(Guid dayCarePackageId);
        Task<Guid> RequestMoreInformationDayCarePackageDetails(Guid dayCarePackageId, string informationText);
        Task<Guid> DayCarePackageBrokerageNew(Guid dayCarePackageId);
        Task<Guid> DayCarePackageBrokerageAssigned(Guid dayCarePackageId);
        Task<Guid> DayCarePackageBrokerageQuerying(Guid dayCarePackageId);
        Task<Guid> DayCarePackageBrokerageSupplierSourced(Guid dayCarePackageId);
        Task<Guid> DayCarePackageBrokeragePricingAgreed(Guid dayCarePackageId);
        Task<Guid> DayCarePackageBrokerageSubmittedForApproval(Guid dayCarePackageId);
        Task<Guid> DayCarePackageBrokeredDealApproved(Guid dayCarePackageId);
        Task<Guid> DayCarePackageBrokeredDealRejected(Guid dayCarePackageId);
        Task<Guid> DayCarePackageBrokeredDealRequestMoreInformation(Guid dayCarePackageId, string informationText);
        Task<Guid> DayCarePackagePackageContracted(Guid dayCarePackageId);
    }
}
