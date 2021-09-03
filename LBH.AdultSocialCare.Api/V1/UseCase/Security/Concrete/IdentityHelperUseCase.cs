using System;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
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
