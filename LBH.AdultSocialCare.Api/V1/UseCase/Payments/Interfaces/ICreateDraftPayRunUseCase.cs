using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface ICreateDraftPayRunUseCase
    {
        Task CreateDraftPayRun(DraftPayRunCreationDomain reclaimCreationDomain);
    }
}
