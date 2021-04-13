using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageDomain> ExecuteAsync(ResidentialCarePackageDomain residentialCarePackage);
    }
}