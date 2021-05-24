using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageReclaimBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCarePackageReclaimUseCase.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCare
{
    [Route("api/v1/residential-care-packages/{residentialCarePackageId}/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCarePackageReclaimController : BaseController
    {
        private readonly ICreateResidentialCarePackageReclaimUseCase _createResidentialCarePackageReclaimUseCase;
        private readonly IGetAllAmountOptionUseCase _getAllAmountOptionUseCase;
        private readonly IGetAllReclaimCategoryUseCase _getAllReclaimCategoryUseCase;
        private readonly IGetAllReclaimFromUseCase _getAllReclaimFromUseCase;

        public ResidentialCarePackageReclaimController(ICreateResidentialCarePackageReclaimUseCase createResidentialCarePackageReclaimUseCase,
            IGetAllAmountOptionUseCase getAllAmountOptionUseCase,
            IGetAllReclaimCategoryUseCase getAllReclaimCategoryUseCase,
            IGetAllReclaimFromUseCase getAllReclaimFromUseCase)
        {
            _createResidentialCarePackageReclaimUseCase = createResidentialCarePackageReclaimUseCase;
            _getAllAmountOptionUseCase = getAllAmountOptionUseCase;
            _getAllReclaimCategoryUseCase = getAllReclaimCategoryUseCase;
            _getAllReclaimFromUseCase = getAllReclaimFromUseCase;
        }

        [ProducesResponseType(typeof(ResidentialCarePackageClaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<ResidentialCarePackageClaimResponse>> CreateResidentialCarePackageReclaim(
            ResidentialCarePackageClaimCreationRequest residentialCarePackageClaimCreationRequest)
        {
            if (residentialCarePackageClaimCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var residentialCarePackageClaimForCreationDomain = residentialCarePackageClaimCreationRequest.ToDomain();
            var residentialCarePackageClaimResponse =
                await _createResidentialCarePackageReclaimUseCase.ExecuteAsync(residentialCarePackageClaimForCreationDomain).ConfigureAwait(false);
            return Ok(residentialCarePackageClaimResponse);
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