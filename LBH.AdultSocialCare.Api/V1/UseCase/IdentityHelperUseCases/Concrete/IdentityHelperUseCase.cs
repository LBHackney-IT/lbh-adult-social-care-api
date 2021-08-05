using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Concrete
{
    public class IdentityHelperUseCase : IIdentityHelperUseCase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityHelperUseCase(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            return new Guid(_httpContextAccessor.HttpContext.User.Identity.GetUserId());
        }

        public Guid GetUserName()
        {
            return new Guid(_httpContextAccessor.HttpContext.User.Identity.GetFullName());
        }
    }
}
