using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageReclaimBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCarePackageReclaimUseCase.Interfaces;
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
        private readonly IGetAllHomeCareAmountOptionUseCase _getAllHomeCareAmountOptionUseCase;
        private readonly IGetAllHomeCareReclaimCategoryUseCase _getAllHomeCareReclaimCategoryUseCase;
        private readonly IGetAllHomeCareReclaimFromUseCase _getAllHomeCareReclaimFromUseCase;

        public NursingCarePackageReclaimController(ICreateNursingCarePackageReclaimUseCase createNursingCarePackageReclaimUseCase,
            IGetAllHomeCareAmountOptionUseCase getAllHomeCareAmountOptionUseCase,
            IGetAllHomeCareReclaimCategoryUseCase getAllHomeCareReclaimCategoryUseCase,
            IGetAllHomeCareReclaimFromUseCase getAllHomeCareReclaimFromUseCase)
        {
            _createNursingCarePackageReclaimUseCase = createNursingCarePackageReclaimUseCase;
            _getAllHomeCareAmountOptionUseCase = getAllHomeCareAmountOptionUseCase;
            _getAllHomeCareReclaimCategoryUseCase = getAllHomeCareReclaimCategoryUseCase;
            _getAllHomeCareReclaimFromUseCase = getAllHomeCareReclaimFromUseCase;
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
