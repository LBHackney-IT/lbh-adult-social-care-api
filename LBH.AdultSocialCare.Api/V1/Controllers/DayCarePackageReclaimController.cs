using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageReclaimBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/day-care-packages/{dayCarePackageId}/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DayCarePackageReclaimController : Controller
    {
        private readonly ICreateDayCarePackageReclaimUseCase _createDayCarePackageReclaimUseCase;
        private readonly IGetAllHomeCareAmountOptionUseCase _getAllHomeCareAmountOptionUseCase;
        private readonly IGetAllHomeCareReclaimCategoryUseCase _getAllHomeCareReclaimCategoryUseCase;
        private readonly IGetAllHomeCareReclaimFromUseCase _getAllHomeCareReclaimFromUseCase;

        public DayCarePackageReclaimController(ICreateDayCarePackageReclaimUseCase createDayCarePackageReclaimUseCase,
            IGetAllHomeCareAmountOptionUseCase getAllHomeCareAmountOptionUseCase,
            IGetAllHomeCareReclaimCategoryUseCase getAllHomeCareReclaimCategoryUseCase,
            IGetAllHomeCareReclaimFromUseCase getAllHomeCareReclaimFromUseCase)
        {
            _createDayCarePackageReclaimUseCase = createDayCarePackageReclaimUseCase;
            _getAllHomeCareAmountOptionUseCase = getAllHomeCareAmountOptionUseCase;
            _getAllHomeCareReclaimCategoryUseCase = getAllHomeCareReclaimCategoryUseCase;
            _getAllHomeCareReclaimFromUseCase = getAllHomeCareReclaimFromUseCase;
        }

        [ProducesResponseType(typeof(DayCarePackageClaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<DayCarePackageClaimResponse>> CreateDayCarePackageReclaim(
            DayCarePackageClaimCreationRequest dayCarePackageClaimCreationRequest)
        {
            if (dayCarePackageClaimCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageClaimForCreationDomain = dayCarePackageClaimCreationRequest.ToDomain();
            var dayCarePackageClaimResponse =
                await _createDayCarePackageReclaimUseCase.ExecuteAsync(dayCarePackageClaimForCreationDomain).ConfigureAwait(false);
            return Ok(dayCarePackageClaimResponse);
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
