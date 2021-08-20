using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Interfaces
{
    public interface ICreateDayCareCollegeUseCase
    {
        Task<int> Execute(DayCareCollegeForCreationDomain dayCareCollegeForCreationDomain);
    }
}
