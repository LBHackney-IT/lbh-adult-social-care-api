using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCare
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/brokerage")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareBrokerageController : Controller
    {
        private readonly IGetNursingCareBrokerageUseCase _getNursingCareBrokerageUseCase;
        private readonly ICreateNursingCareBrokerageUseCase _createNursingCareBrokerageUseCase;
        private readonly IChangeStatusNursingCarePackageUseCase _changeStatusNursingCarePackageUseCase;
        private readonly ISetStageToNursingCarePackageUseCase _setStageToNursingCarePackageUseCase;

        public NursingCareBrokerageController(IGetNursingCareBrokerageUseCase getNursingCareBrokerageUseCase,
            ICreateNursingCareBrokerageUseCase createNursingCareBrokerageUseCase,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase,
            ISetStageToNursingCarePackageUseCase setStageToNursingCarePackageUseCase)
        {
            _getNursingCareBrokerageUseCase = getNursingCareBrokerageUseCase;
            _createNursingCareBrokerageUseCase = createNursingCareBrokerageUseCase;
            _changeStatusNursingCarePackageUseCase = changeStatusNursingCarePackageUseCase;
            _setStageToNursingCarePackageUseCase = setStageToNursingCarePackageUseCase;
        }

        /// <summary>Gets the specified nursing care package identifier.</summary>
        /// <param name="nursingCarePackageId">The nursing care package identifier.</param>
        /// <returns>The nursing care brokerage response.</returns>
        [HttpGet]
        public async Task<ActionResult<NursingCareBrokerageInfoResponse>> GetNursingCareBrokerage(Guid nursingCarePackageId)
        {
            var nursingCareBrokerageResponse = await _getNursingCareBrokerageUseCase.Execute(nursingCarePackageId).ConfigureAwait(false);
            return Ok(nursingCareBrokerageResponse);
        }

        /// <summary>
        /// Creates the nursing care package brokerage.
        /// </summary>
        /// <param name="brokerageCreationRequest">The nursing care package brokerage for creation.</param>
        /// <returns>A newly created nursing care package brokerage</returns>
        /// <response code="200">Returns ID of the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the nursing care package for this brokerage is not found</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(NursingCareBrokerageInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<NursingCareBrokerageInfoResponse>> CreateNursingCareBrokerage([FromBody] NursingCareBrokerageCreationRequest brokerageCreationRequest)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var result = await _createNursingCareBrokerageUseCase
                .ExecuteAsync(brokerageCreationRequest.ToDomain())
                .ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut("stage/{stageId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> SetStageToPackage(Guid nursingCarePackageId, int stageId)
        {
            var result = await _setStageToNursingCarePackageUseCase.UpdatePackage(nursingCarePackageId, stageId).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost("clarifying-commercials")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ApprovePackage([FromBody] Guid nursingCarePackageId, string requestMoreInformationText)
        {
            var result = await _changeStatusNursingCarePackageUseCase.UpdateAsync(nursingCarePackageId, ApprovalHistoryConstants.ClarifyingCommercialsId, requestMoreInformationText).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
