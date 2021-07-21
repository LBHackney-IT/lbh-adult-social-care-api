using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    public class BaseController : Controller
    {
        //todo commented for now it cause error while getting data after created.
        //public BaseController()
        //{
        //    ConfigureJsonSerializer();
        //}

        public string GetCorrelationId()
        {
            StringValues correlationId;
            HttpContext.Request.Headers.TryGetValue(Constants.CorrelationId, out correlationId);

            if (!correlationId.Any())
                throw new KeyNotFoundException("Request is missing a correlationId");

            return correlationId.First();
        }

        //public static void ConfigureJsonSerializer()
        //{
        //    JsonConvert.DefaultSettings = () =>
        //    {
        //        JsonSerializerSettings settings = new JsonSerializerSettings();
        //        settings.Formatting = Formatting.Indented;
        //        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        //        settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        //        settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;

        //        return settings;
        //    };
        //}
    }
}
