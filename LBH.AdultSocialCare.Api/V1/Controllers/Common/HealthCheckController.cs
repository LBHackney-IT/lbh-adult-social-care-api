using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/healthcheck")]
    [ApiController]
    [Produces("application/json")]
    public class HealthCheckController : BaseController
    {
        [HttpGet]
        [Route("ping")]
        [ProducesResponseType(typeof(Dictionary<string, bool>), 200)]
        public IActionResult HealthCheck()
        {
            Dictionary<string, bool> result = new Dictionary<string, bool> { { "success", true } };

            return Ok(result);
        }

        [HttpGet]
        [Route("error")]
        public void ThrowError()
        {
            ThrowOpsErrorUsecase.Execute();
        }

        [HttpGet]
        [Route("log")]
        public void Log([FromServices] ILogger<HealthCheckController> logger)
        {
            // TODO: VK: Remove
            logger.LogTrace("Trace");
            logger.LogInformation("Information");
            logger.LogWarning("Warning");
            logger.LogCritical("Critical");

            throw new InvalidOperationException("Test exception");
        }
    }
}
