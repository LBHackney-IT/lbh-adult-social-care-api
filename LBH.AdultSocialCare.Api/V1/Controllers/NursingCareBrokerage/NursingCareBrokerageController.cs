using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCareBrokerage
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/brokerage")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareBrokerageController : Controller
    {
        //private readonly IGetNursingCareBrokerageUseCase _getNursingCareBrokerageUseCase;
        //private readonly ICreateNursingCareBrokerageUseCase _createNursingCareBrokerageUseCase;

        //public NursingCareBrokerageController(IGetNursingCareBrokerageUseCase getNursingCareBrokerageUseCase,
        //    ICreateNursingCareBrokerageUseCase createNursingCareBrokerageUseCase)
        //{
        //    _getNursingCareBrokerageUseCase = getNursingCareBrokerageUseCase;
        //    _createNursingCareBrokerageUseCase = createNursingCareBrokerageUseCase;
        //}

        ///// <summary>Gets the specified nursing care package identifier.</summary>
        ///// <param name="nursingCarePackageId">The nursing care package identifier.</param>
        ///// <returns>The nursing care brokerage response.</returns>
        //[HttpGet]
        //public async Task<ActionResult<NursingCareBrokerageResponse>> GetNursingCareBrokerage(Guid nursingCarePackageId)
        //{
        //    var nursingCareBrokerageResponse = await _getNursingCareBrokerageUseCase.Execute(nursingCarePackageId).ConfigureAwait(false);
        //    return Ok(nursingCareBrokerageResponse);
        //}

        ///// <summary>
        ///// Creates the nursing care package brokerage.
        ///// </summary>
        ///// <param name="nursingCarePackageId">The nursing care package identifier.</param>
        ///// <param name="nursingCareBrokerageCreationRequest">The nursing care package brokerage for creation.</param>
        ///// <returns>A newly created nursing care package brokerage</returns>
        ///// <response code="200">Returns ID of the newly created item</response>
        ///// <response code="400">If the item is null</response>
        ///// <response code="404">If the nursing care package for this brokerage is not found</response>
        ///// <response code="422">If the model is invalid</response>
        //[HttpPost]
        //[ProducesResponseType(typeof(NursingCareBrokerageCreationResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult<NursingCareBrokerageCreationResponse>> CreateNursingCarePackage(Guid nursingCarePackageId, [FromBody] NursingCareBrokerageCreationRequest nursingCareBrokerageCreationRequest)
        //{
        //    if (nursingCareBrokerageCreationRequest == null)
        //    {
        //        return BadRequest("Object for creation cannot be null.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return UnprocessableEntity(ModelState);
        //    }

        //    var nursingCareBrokerageCreationDomain = nursingCareBrokerageCreationRequest.ToDomain();
        //    var result = await _createNursingCareBrokerageUseCase.ExecuteAsync(nursingCarePackageId, nursingCareBrokerageCreationDomain).ConfigureAwait(false);
        //    return Ok(result);
        //}
    }
}
