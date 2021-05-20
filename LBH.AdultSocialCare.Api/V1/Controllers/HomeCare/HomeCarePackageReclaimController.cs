using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{
    [Route("api/v1/home-care-packages/{homeCarePackageId}/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCarePackageReclaimController : BaseController
    {
        private readonly ICreateHomeCarePackageReclaimUseCase _createHomeCarePackageReclaimUseCase;
        private readonly IGetAllHomeCareAmountOptionUseCase _getAllHomeCareAmountOptionUseCase;
        private readonly IGetAllHomeCareReclaimCategoryUseCase _getAllHomeCareReclaimCategoryUseCase;
        private readonly IGetAllHomeCareReclaimFromUseCase _getAllHomeCareReclaimFromUseCase;

        public HomeCarePackageReclaimController(ICreateHomeCarePackageReclaimUseCase createHomeCarePackageReclaimUseCase,
            IGetAllHomeCareAmountOptionUseCase getAllHomeCareAmountOptionUseCase,
            IGetAllHomeCareReclaimCategoryUseCase getAllHomeCareReclaimCategoryUseCase,
            IGetAllHomeCareReclaimFromUseCase getAllHomeCareReclaimFromUseCase)
        {
            _createHomeCarePackageReclaimUseCase = createHomeCarePackageReclaimUseCase;
            _getAllHomeCareAmountOptionUseCase = getAllHomeCareAmountOptionUseCase;
            _getAllHomeCareReclaimCategoryUseCase = getAllHomeCareReclaimCategoryUseCase;
            _getAllHomeCareReclaimFromUseCase = getAllHomeCareReclaimFromUseCase;
        }

        [ProducesResponseType(typeof(HomeCarePackageClaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<HomeCarePackageClaimResponse>> CreateHomeCarePackageClaim(
            HomeCarePackageClaimCreationRequest homeCarePackageClaimCreationRequest)
        {
            if (homeCarePackageClaimCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var homeCarePackageClaimForCreationDomain = homeCarePackageClaimCreationRequest.ToDomain();
            var homeCarePackageClaimResponse =
                await _createHomeCarePackageReclaimUseCase.ExecuteAsync(homeCarePackageClaimForCreationDomain).ConfigureAwait(false);
            return Ok(homeCarePackageClaimResponse);
        }

        [ProducesResponseType(typeof(IEnumerable<HomeCarePackageReclaimAmountOptionResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("amount-option")]
        public async Task<ActionResult<IEnumerable<HomeCarePackageReclaimAmountOptionResponse>>> GetAmountOptionsList()
        {
            var result = await _getAllHomeCareAmountOptionUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<HomeCarePackageReclaimFromResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("reclaim-from")]
        public async Task<ActionResult<IEnumerable<HomeCarePackageReclaimFromResponse>>> GetTypeOfReclaimFromOptionList()
        {
            var result = await _getAllHomeCareReclaimFromUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<HomeCarePackageReclaimCategoryResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("reclaim-category")]
        public async Task<ActionResult<IEnumerable<HomeCarePackageReclaimCategoryResponse>>> GetTypeOfReclaimCategoryOptionList()
        {
            var result = await _getAllHomeCareReclaimCategoryUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
