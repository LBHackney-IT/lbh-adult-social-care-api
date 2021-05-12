using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Interfaces
{
    public interface ICreateHomeCareRequestMoreInformationUseCase
    {
        public Task<bool> Execute(HomeCareRequestMoreInformationDomain homeCareRequestMoreInformation);
    }
}
