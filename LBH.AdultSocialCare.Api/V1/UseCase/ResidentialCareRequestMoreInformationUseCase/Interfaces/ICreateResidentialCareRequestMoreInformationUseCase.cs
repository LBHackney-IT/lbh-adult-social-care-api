using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareRequestMoreInformationUseCase.Interfaces
{
    public interface ICreateResidentialCareRequestMoreInformationUseCase
    {
        public Task<bool> Execute(ResidentialCareRequestMoreInformationDomain residentialCareRequestMoreInformation);
    }
}
