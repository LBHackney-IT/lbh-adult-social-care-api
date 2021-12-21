using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/lookups")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class LookupController : BaseController
    {
        [HttpGet]
        [ResponseCache(Duration = 600, VaryByQueryKeys = new[] { "name" })]
        public ActionResult<List<LookupItemResponse>> GetLookup(string name)
        {
            var lookup = AppDomain.CurrentDomain
                .GetAssemblies()
                .Select(assembly => assembly
                    .GetTypes()
                    .FirstOrDefault(type => type.IsEnum && type.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                .FirstOrDefault(type => type != null);

            if (lookup is null) return NotFound();

            // explicitly mark lookups with [Lookup] to prevent exploring internal code structure from outside reading _any_ enums
            if (!lookup.GetCustomAttributes(typeof(LookupAttribute), false).Any()) return NotFound();

            var values = Enum.GetValues(lookup)
                .Cast<Enum>()
                .Select(value => new LookupItemResponse
                {
                    Id = Convert.ToInt32(value),
                    Name = value.GetDisplayName()
                }).ToList();

            return values;
        }
    }
}
