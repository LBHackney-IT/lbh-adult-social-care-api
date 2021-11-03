using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Payments
{
    [Route("api/v1/payruns")]
    [ApiController]
    public class PayRunsController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<PayRunDetailsViewResponse>> GetPayRunDetails([FromServices] IGetPayRunDetailsUseCase useCase, Guid id)
        {
            var res = await useCase.ExecuteAsync(id);
            return Ok(res);
        }
    }
}
