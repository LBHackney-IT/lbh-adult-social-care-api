using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

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
