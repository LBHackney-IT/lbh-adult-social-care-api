using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Interfaces
{
    public interface IGetHomeCareApproveBrokeredUseCase
    {
        public Task<HomeCareApproveBrokeredResponse> Execute(Guid homeCarePackageId);
    }
}
