using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/stages")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class StageController : BaseController
    {
        private readonly IGetAllHomeCareStageUseCase _getAllHomeCareStageUseCase;

        public StageController(IGetAllHomeCareStageUseCase getAllHomeCareStageUseCase)
        {
            _getAllHomeCareStageUseCase = getAllHomeCareStageUseCase;
        }

        [ProducesResponseType(typeof(IEnumerable<StageResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StageResponse>>> GetStageList()
        {
            var result = await _getAllHomeCareStageUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
