using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageReclaimBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/day-care-packages/{dayCarePackageId}/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DayCarePackageReclaimController : BaseController
    {
        private readonly ICreateDayCarePackageReclaimUseCase _createDayCarePackageReclaimUseCase;
        private readonly IGetAllAmountOptionUseCase _getAllAmountOptionUseCase;
        private readonly IGetAllReclaimCategoryUseCase _getAllReclaimCategoryUseCase;
        private readonly IGetAllReclaimFromUseCase _getAllReclaimFromUseCase;

        public DayCarePackageReclaimController(ICreateDayCarePackageReclaimUseCase createDayCarePackageReclaimUseCase,
            IGetAllAmountOptionUseCase getAllAmountOptionUseCase,
            IGetAllReclaimCategoryUseCase getAllReclaimCategoryUseCase,
            IGetAllReclaimFromUseCase getAllReclaimFromUseCase)
        {
            _createDayCarePackageReclaimUseCase = createDayCarePackageReclaimUseCase;
            _getAllAmountOptionUseCase = getAllAmountOptionUseCase;
            _getAllReclaimCategoryUseCase = getAllReclaimCategoryUseCase;
            _getAllReclaimFromUseCase = getAllReclaimFromUseCase;
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

        [ProducesResponseType(typeof(IEnumerable<ReclaimAmountOptionResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("amount-option")]
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
