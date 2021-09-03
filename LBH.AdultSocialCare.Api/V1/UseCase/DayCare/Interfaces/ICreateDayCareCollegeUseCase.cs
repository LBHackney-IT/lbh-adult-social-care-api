using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces
{
    public interface ICreateDayCareCollegeUseCase
    {
        Task<int> Execute(DayCareCollegeForCreationDomain dayCareCollegeForCreationDomain);
    }
}
