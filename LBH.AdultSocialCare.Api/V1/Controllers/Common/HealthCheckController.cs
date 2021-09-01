using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Microsoft.AspNetCore.Mvc;

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

    }
}
