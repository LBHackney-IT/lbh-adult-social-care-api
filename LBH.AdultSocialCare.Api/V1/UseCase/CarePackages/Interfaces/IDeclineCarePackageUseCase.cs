using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IDeclineCarePackageUseCase
    {
        Task ExecuteAsync(Guid packageId, string notes);
    }
}
