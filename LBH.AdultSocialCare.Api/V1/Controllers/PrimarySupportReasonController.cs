using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.PrimarySupportReasonBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.PrimarySupportReasonUseCase.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/primary-support-reasons")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class PrimarySupportReasonController : BaseController
    {
        private readonly IGetAllPrimarySupportReasonsUseCase _getAllPrimarySupportReasonsUseCase;

        public PrimarySupportReasonController(IGetAllPrimarySupportReasonsUseCase getAllPrimarySupportReasonsUseCase)
        {
            _getAllPrimarySupportReasonsUseCase = getAllPrimarySupportReasonsUseCase;
        }

        [ProducesResponseType(typeof(IEnumerable<PrimarySupportReasonResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrimarySupportReasonResponse>>> GetPrimarySupportReasonList()
        {
            var result = await _getAllPrimarySupportReasonsUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
