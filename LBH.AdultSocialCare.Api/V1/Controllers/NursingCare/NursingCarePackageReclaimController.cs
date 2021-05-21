using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageReclaimBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCare
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCarePackageReclaimController : Controller
    {
        private readonly ICreateNursingCarePackageReclaimUseCase _createNursingCarePackageReclaimUseCase;
        private readonly IGetAllAmountOptionUseCase _getAllAmountOptionUseCase;
        private readonly IGetAllReclaimCategoryUseCase _getAllReclaimCategoryUseCase;
        private readonly IGetAllReclaimFromUseCase _getAllReclaimFromUseCase;

        public NursingCarePackageReclaimController(ICreateNursingCarePackageReclaimUseCase createNursingCarePackageReclaimUseCase,
            IGetAllAmountOptionUseCase getAllAmountOptionUseCase,
            IGetAllReclaimCategoryUseCase getAllReclaimCategoryUseCase,
            IGetAllReclaimFromUseCase getAllReclaimFromUseCase)
        {
            _createNursingCarePackageReclaimUseCase = createNursingCarePackageReclaimUseCase;
            _getAllAmountOptionUseCase = getAllAmountOptionUseCase;
            _getAllReclaimCategoryUseCase = getAllReclaimCategoryUseCase;
            _getAllReclaimFromUseCase = getAllReclaimFromUseCase;
        }

        [ProducesResponseType(typeof(NursingCarePackageClaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<NursingCarePackageClaimResponse>> CreateNursingCarePackageReclaim(
            NursingCarePackageClaimCreationRequest nursingCarePackageClaimCreationRequest)
        {
            if (nursingCarePackageClaimCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var nursingCarePackageClaimForCreationDomain = nursingCarePackageClaimCreationRequest.ToDomain();
            var nursingCarePackageClaimResponse =
                await _createNursingCarePackageReclaimUseCase.ExecuteAsync(nursingCarePackageClaimForCreationDomain).ConfigureAwait(false);
            return Ok(nursingCarePackageClaimResponse);
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
