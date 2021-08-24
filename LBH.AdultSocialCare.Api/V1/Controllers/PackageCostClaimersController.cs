using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/cost-claimers")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class PackageCostClaimersController : BaseController
    {
        private readonly IGetFncCollectorsUseCase _getFncCollectorsUseCase;

        public PackageCostClaimersController(IGetFncCollectorsUseCase getFncCollectorsUseCase)
        {
            _getFncCollectorsUseCase = getFncCollectorsUseCase;
        }

        /// <summary>
        /// Returns list of FNC collectors
        /// </summary>
        /// <returns>List of FNC collectors</returns>
        [ProducesResponseType(typeof(IEnumerable<FncCollectorResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet("fnc-collectors")]
        public async Task<ActionResult<IEnumerable<FncCollectorResponse>>> GetFncCollectors()
        {
            var collectors = await _getFncCollectorsUseCase
                .GetFncCollectorsAsync().ConfigureAwait(false);

            if (collectors is null)
            {
                return NotFound();
            }

            return Ok(collectors.ToResponse().ToList());
        }
    }
}
