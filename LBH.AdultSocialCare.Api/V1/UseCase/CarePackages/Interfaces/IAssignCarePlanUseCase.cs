using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IAssignCarePlanUseCase
    {
        Task ExecuteAsync(CarePlanAssignmentDomain carePlanAssignment);
    }
}
