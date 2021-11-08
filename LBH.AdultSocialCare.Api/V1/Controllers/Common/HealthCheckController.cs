using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Services.Queuing;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/healthcheck")]
    [ApiController]
    [Produces("application/json")]
    public class HealthCheckController : ControllerBase
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

        [HttpPost("queue")]
        public async Task<ActionResult> Log([FromQuery] string message, [FromServices] IQueueService queue)
        {
            await queue.Send(message);
            return Ok();
        }
    }
}
