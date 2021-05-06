using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApproveBrokeredBoundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Interfaces
{
    public interface IGetHomeCareApproveBrokeredUseCase
    {
        public Task<HomeCareApproveBrokeredResponse> Execute(Guid homeCarePackageId);
    }
}
