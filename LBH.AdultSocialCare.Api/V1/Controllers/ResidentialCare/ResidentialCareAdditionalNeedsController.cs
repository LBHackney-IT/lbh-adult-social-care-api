using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCare
{
    [Route("api/v1/residential-care-package/{residentialCarePackageId}/additional-needs")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCareAdditionalNeedsController : BaseController
    {
        private readonly IUpsertResidentialCareAdditionalNeedsUseCase _upsertResidentialCareAdditionalNeedsUseCase;
        private readonly IGetResidentialCareAdditionalNeedsUseCase _getResidentialCareAdditionalNeedsUseCase;

        public ResidentialCareAdditionalNeedsController(IUpsertResidentialCareAdditionalNeedsUseCase upsertResidentialCareAdditionalNeedsUseCase,
            IGetResidentialCareAdditionalNeedsUseCase getResidentialCareAdditionalNeedsUseCase)
        {
            _upsertResidentialCareAdditionalNeedsUseCase = upsertResidentialCareAdditionalNeedsUseCase;
            _getResidentialCareAdditionalNeedsUseCase = getResidentialCareAdditionalNeedsUseCase;
        }

        /// <summary>Creates the specified residential care additional needs request.</summary>
        /// <param name="residentialCareAdditionalNeedsRequest">The residential care additional needs request.</param>
        /// <returns>The residential care additional needs  Response</returns>
        [ProducesResponseType(typeof(ResidentialCareAdditionalNeedsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<ResidentialCareAdditionalNeedsResponse>> Create(ResidentialCareAdditionalNeedsRequest residentialCareAdditionalNeedsRequest)
        {
            try
            {
                ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeedsDomain = ResidentialCareAdditionalNeedsFactory.ToDomain(residentialCareAdditionalNeedsRequest);
                var residentialCareAdditionalNeedsResponse = ResidentialCareAdditionalNeedsFactory.ToResponse(await _upsertResidentialCareAdditionalNeedsUseCase.ExecuteAsync(residentialCareAdditionalNeedsDomain).ConfigureAwait(false));
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
        /// <returns>
        ///   A residential care additional needs response model
        /// </returns>
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
                var residentialCareAdditionalNeedsResponse = ResidentialCareAdditionalNeedsFactory.ToResponse(await _getResidentialCareAdditionalNeedsUseCase.GetAsync(residentialCareAdditionalNeedsId).ConfigureAwait(false));
                if (residentialCareAdditionalNeedsResponse == null) return NotFound();
                return Ok(residentialCareAdditionalNeedsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
