using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        public ActionResult<List<LookupItemResponse>> GetLookup(string name)
        {
            // TODO: VK: Add some [Lookup] attribute to avoid accessing any enum for security reason
            // TODO: VK: Consider [OptionName] attribute to keep separated strings for lookups and some other strings
            // TODO: VK: optimize, look just for enums in Data assembly, add output caching

            var lookup = AppDomain.CurrentDomain
                .GetAssemblies()
                .Select(assembly => assembly
                    .GetTypes()
                    .FirstOrDefault(type => type.IsEnum && type.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                .FirstOrDefault(type => type != null);

            if (lookup is null) return NotFound();

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
