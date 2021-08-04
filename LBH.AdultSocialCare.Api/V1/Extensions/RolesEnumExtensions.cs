using System;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="RolesEnum"/>.
    /// </summary>
    public static class RolesEnumExtensions
    {
        /// <summary>
        /// Returns an unique Id associated with the given role.
        /// </summary>
        public static Guid GetId(this RolesEnum role)
        {
            return new Guid(role.ToDescription());
        }
    }
}