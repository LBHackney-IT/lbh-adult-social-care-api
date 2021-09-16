using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Factories;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common.CareChargesControllers
{
    [Route("api/v1/package-care-charges")]
    [ApiController]
    public class PackageCareChargesController : ControllerBase
    {
        private readonly ICancelOrEndCareChargeElementUseCase _cancelOrEndCareChargeElementUseCase;
        private readonly IEditCareChargeElementUseCase _editCareChargeElementUseCase;

        public PackageCareChargesController(ICancelOrEndCareChargeElementUseCase cancelOrEndCareChargeElementUseCase, IEditCareChargeElementUseCase editCareChargeElementUseCase)
        {
            _cancelOrEndCareChargeElementUseCase = cancelOrEndCareChargeElementUseCase;
            _editCareChargeElementUseCase = editCareChargeElementUseCase;
        }

        [HttpPut("{packageCareChargeId}/care-charges/{careElementId}/cancel")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> CancelCareChargeElement(Guid packageCareChargeId, Guid careElementId)
        {
            var cancelResult = await _cancelOrEndCareChargeElementUseCase.ExecuteCancelAsync(packageCareChargeId, careElementId).ConfigureAwait(false);
            return Ok(cancelResult);
        }

        [HttpPut("{packageCareChargeId}/care-charges/{careElementId}/end")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> EndCareChargeElement(Guid packageCareChargeId, Guid careElementId, [FromBody] EndCareChargeElementRequest endCareChargeElementRequest)
        {
            var endCareChargeElementDomain = endCareChargeElementRequest.ToDomain();
            var cancelResult = await _cancelOrEndCareChargeElementUseCase.ExecuteEndAsync(packageCareChargeId, careElementId, endCareChargeElementDomain.NewEndDate).ConfigureAwait(false);
            return Ok(cancelResult);
        }

        [HttpPut("{packageCareChargeId}/care-charges/care-charge-elements")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> UpdateCareChargeElements(Guid packageCareChargeId, [FromBody] IEnumerable<CareChargeElementForUpdateRequest> careChargeElementsForUpdate)
        {
            var editResult = await _editCareChargeElementUseCase.ExecuteAsync(packageCareChargeId, careChargeElementsForUpdate.ToDomain()).ConfigureAwait(false);
            return Ok(editResult);
        }
    }
}
