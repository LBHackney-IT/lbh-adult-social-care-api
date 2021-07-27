using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [Authorize]
    public class PackageReclaimController : ControllerBase
    {
        private readonly IGetAllAmountOptionUseCase _getAllAmountOptionUseCase;
        private readonly IGetAllReclaimCategoryUseCase _getAllReclaimCategoryUseCase;
        private readonly IGetAllReclaimFromUseCase _getAllReclaimFromUseCase;

        public PackageReclaimController(IGetAllAmountOptionUseCase getAllAmountOptionUseCase, IGetAllReclaimCategoryUseCase getAllReclaimCategoryUseCase,
            IGetAllReclaimFromUseCase getAllReclaimFromUseCase)
        {
            _getAllAmountOptionUseCase = getAllAmountOptionUseCase;
            _getAllReclaimCategoryUseCase = getAllReclaimCategoryUseCase;
            _getAllReclaimFromUseCase = getAllReclaimFromUseCase;
        }

        [ProducesResponseType(typeof(IEnumerable<ReclaimAmountOptionResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("amount-options")]
        public async Task<ActionResult<IEnumerable<ReclaimAmountOptionResponse>>> GetAmountOptionsList()
        {
            var result = await _getAllAmountOptionUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ReclaimFromResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("reclaim-from")]
        public async Task<ActionResult<IEnumerable<ReclaimFromResponse>>> GetTypeOfReclaimFromOptionList()
        {
            var result = await _getAllReclaimFromUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ReclaimCategoryResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("reclaim-category")]
        public async Task<ActionResult<IEnumerable<ReclaimCategoryResponse>>> GetTypeOfReclaimCategoryOptionList()
        {
            var result = await _getAllReclaimCategoryUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
