using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Interfaces
{
    public interface ICreateNursingCareRequestMoreInformationUseCase
    {
        public Task<bool> Execute(NursingCareRequestMoreInformationDomain nursingCareRequestMoreInformation);
    }
}
