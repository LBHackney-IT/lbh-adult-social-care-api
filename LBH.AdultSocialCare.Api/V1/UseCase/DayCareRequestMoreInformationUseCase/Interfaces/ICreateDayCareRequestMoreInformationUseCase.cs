using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCareRequestMoreInformationUseCase.Interfaces
{
    public interface ICreateDayCareRequestMoreInformationUseCase
    {
        public Task<bool> Execute(DayCareRequestMoreInformationDomain dayCareRequestMoreInformation);
    }
}
