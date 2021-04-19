using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IDeleteResidentialCareAdditionalNeedsUseCase
    {
        public Task<bool> DeleteAsync(Guid residentialCareAdditionalNeedsId);
    }
}
