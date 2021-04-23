using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCare
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/additional-needs")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareAdditionalNeedsController : BaseController
    {
        private readonly IUpsertNursingCareAdditionalNeedsUseCase _upsertNursingCareAdditionalNeedsUseCase;
        private readonly IGetNursingCareAdditionalNeedsUseCase _getNursingCareAdditionalNeedsUseCase;
        private readonly IDeleteNursingCareAdditionalNeedsUseCase _deleteNursingCareAdditionalNeedsUseCase;

        public NursingCareAdditionalNeedsController(IUpsertNursingCareAdditionalNeedsUseCase upsertNursingCareAdditionalNeedsUseCase,
            IGetNursingCareAdditionalNeedsUseCase getNursingCareAdditionalNeedsUseCase,
            IDeleteNursingCareAdditionalNeedsUseCase deleteNursingCareAdditionalNeedsUseCase)
        {
            _upsertNursingCareAdditionalNeedsUseCase = upsertNursingCareAdditionalNeedsUseCase;
            _getNursingCareAdditionalNeedsUseCase = getNursingCareAdditionalNeedsUseCase;
            _deleteNursingCareAdditionalNeedsUseCase = deleteNursingCareAdditionalNeedsUseCase;
        }

        /// <summary>Creates the specified nursing care additional needs request.</summary>
        /// <param name="nursingCareAdditionalNeedsRequest">The nursing care additional needs request.</param>
        /// <returns>The Nursing Care Additional Needs Response</returns>
        [ProducesResponseType(typeof(NursingCareAdditionalNeedsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<NursingCareAdditionalNeedsResponse>> Create(NursingCareAdditionalNeedsRequest nursingCareAdditionalNeedsRequest)
        {
            try
            {
                NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain = NursingCareAdditionalNeedsFactory.ToDomain(nursingCareAdditionalNeedsRequest);
                var nursingCareAdditionalNeedsResponse = NursingCareAdditionalNeedsFactory.ToResponse(await _upsertNursingCareAdditionalNeedsUseCase.ExecuteAsync(nursingCareAdditionalNeedsDomain).ConfigureAwait(false));
                if (nursingCareAdditionalNeedsResponse == null) return NotFound();
                return Ok(nursingCareAdditionalNeedsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified nursing care additional needs identifier.</summary>
        /// <param name="nursingCareAdditionalNeedsId">The nursing care additional needs identifier.</param>
        /// <returns>A Nursing Care Additional Needs Response model</returns>
        [ProducesResponseType(typeof(NursingCareAdditionalNeedsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{nursingCareAdditionalNeedsId}")]
        public async Task<ActionResult<NursingCareAdditionalNeedsResponse>> Get(Guid nursingCareAdditionalNeedsId)
        {
            try
            {
                var nursingCareAdditionalNeedsResponse = NursingCareAdditionalNeedsFactory.ToResponse(await _getNursingCareAdditionalNeedsUseCase.GetAsync(nursingCareAdditionalNeedsId).ConfigureAwait(false));
                if (nursingCareAdditionalNeedsResponse == null) return NotFound();
                return Ok(nursingCareAdditionalNeedsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Deletes the specified nursing care additional needs identifier.</summary>
        /// <param name="nursingCareAdditionalNeedsId">The nursing care additional needs identifier.</param>
        /// <returns>
        ///  bool
        /// </returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        [Route("{nursingCareAdditionalNeedsId}")]
        public async Task<ActionResult<bool>> Delete(Guid nursingCareAdditionalNeedsId)
        {
            try
            {
                bool result = await _deleteNursingCareAdditionalNeedsUseCase.DeleteAsync(nursingCareAdditionalNeedsId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
