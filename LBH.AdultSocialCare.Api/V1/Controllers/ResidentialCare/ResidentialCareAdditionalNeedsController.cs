using LBH.AdultSocialCare.Api.V1.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Controllers.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCare
{
    [Route("api/v1/residential-care-packages/{residentialCarePackageId}/additional-needs")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCareAdditionalNeedsController : BaseController
    {
        private readonly IUpsertResidentialCareAdditionalNeedsUseCase _upsertResidentialCareAdditionalNeedsUseCase;
        private readonly IGetResidentialCareAdditionalNeedsUseCase _getResidentialCareAdditionalNeedsUseCase;
        private readonly IDeleteResidentialCareAdditionalNeedsUseCase _deleteResidentialCareAdditionalNeedsUseCase;

        public ResidentialCareAdditionalNeedsController(IUpsertResidentialCareAdditionalNeedsUseCase upsertResidentialCareAdditionalNeedsUseCase,
            IGetResidentialCareAdditionalNeedsUseCase getResidentialCareAdditionalNeedsUseCase,
            IDeleteResidentialCareAdditionalNeedsUseCase deleteResidentialCareAdditionalNeedsUseCase)
        {
            _upsertResidentialCareAdditionalNeedsUseCase = upsertResidentialCareAdditionalNeedsUseCase;
            _getResidentialCareAdditionalNeedsUseCase = getResidentialCareAdditionalNeedsUseCase;
            _deleteResidentialCareAdditionalNeedsUseCase = deleteResidentialCareAdditionalNeedsUseCase;
        }

        /// <summary>Creates the specified residential care additional needs request.</summary>
        /// <param name="residentialCareAdditionalNeedsRequest">The residential care additional needs request.</param>
        /// <returns>The Residential Care Additional Needs Response</returns>
        [ProducesResponseType(typeof(ResidentialCareAdditionalNeedsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<ResidentialCareAdditionalNeedsResponse>> Create(ResidentialCareAdditionalNeedsRequest residentialCareAdditionalNeedsRequest)
        {
            try
            {
                var residentialCareAdditionalNeedsDomain = residentialCareAdditionalNeedsRequest.ToDomain();
                var res = await _upsertResidentialCareAdditionalNeedsUseCase
                    .ExecuteAsync(residentialCareAdditionalNeedsDomain).ConfigureAwait(false);
                var residentialCareAdditionalNeedsResponse = res?.ToResponse();
                if (residentialCareAdditionalNeedsResponse == null) return NotFound();
                return Ok(residentialCareAdditionalNeedsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified residential care additional needs identifier.</summary>
        /// <param name="residentialCareAdditionalNeedsId">The residential care additional needs identifier.</param>
        /// <returns>A Residential Care Additional Needs Response model</returns>
        [ProducesResponseType(typeof(ResidentialCareAdditionalNeedsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{residentialCareAdditionalNeedsId}")]
        public async Task<ActionResult<ResidentialCareAdditionalNeedsResponse>> Get(Guid residentialCareAdditionalNeedsId)
        {
            try
            {
                var residentialCareAdditionalNeed = await _getResidentialCareAdditionalNeedsUseCase.GetAsync(residentialCareAdditionalNeedsId).ConfigureAwait(false);
                if (residentialCareAdditionalNeed == null) return NotFound();
                return Ok(residentialCareAdditionalNeed.ToResponse());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Deletes the specified residential care additional needs identifier.</summary>
        /// <param name="residentialCareAdditionalNeedsId">The residential care additional needs identifier.</param>
        /// <returns>
        ///  bool
        /// </returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        [Route("{residentialCareAdditionalNeedsId}")]
        public async Task<ActionResult<bool>> Delete(Guid residentialCareAdditionalNeedsId)
        {
            try
            {
                bool result = await _deleteResidentialCareAdditionalNeedsUseCase.DeleteAsync(residentialCareAdditionalNeedsId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
