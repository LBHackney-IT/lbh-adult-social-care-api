using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCareBrokerage
{
    [Route("api/v1/residential-care-packages/{residentialCarePackageId}/brokerage")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCareBrokerageController : Controller
    {
        private readonly IGetResidentialCareBrokerageUseCase _getResidentialCareBrokerageUseCase;
        private readonly ICreateResidentialCareBrokerageUseCase _createResidentialCareBrokerageUseCase;
        private readonly IChangeStatusResidentialCarePackageUseCase _changeStatusResidentialCarePackageUseCase;

        public ResidentialCareBrokerageController(IGetResidentialCareBrokerageUseCase getResidentialCareBrokerageUseCase,
            ICreateResidentialCareBrokerageUseCase createResidentialCareBrokerageUseCase,
            IChangeStatusResidentialCarePackageUseCase changeStatusResidentialCarePackageUseCase)
        {
            _getResidentialCareBrokerageUseCase = getResidentialCareBrokerageUseCase;
            _createResidentialCareBrokerageUseCase = createResidentialCareBrokerageUseCase;
            _changeStatusResidentialCarePackageUseCase = changeStatusResidentialCarePackageUseCase;
        }

        /// <summary>Gets the specified residential care package identifier.</summary>
        /// <param name="residentialCarePackageId">The residential care package identifier.</param>
        /// <returns>The residential care brokerage response.</returns>
        [HttpGet]
        public async Task<ActionResult<ResidentialCareBrokerageInfoResponse>> GetResidentialCareBrokerage(Guid residentialCarePackageId)
        {
            var residentialCareBrokerageResponse = await _getResidentialCareBrokerageUseCase.Execute(residentialCarePackageId).ConfigureAwait(false);
            return Ok(residentialCareBrokerageResponse);
        }

        /// <summary>
        /// Creates the residential care package brokerage.
        /// </summary>
        /// <param name="residentialCareBrokerageCreationRequest">The residential care package brokerage for creation.</param>
        /// <returns>A newly created residential care package brokerage</returns>
        /// <response code="200">Returns ID of the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the residential care package for this brokerage is not found</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResidentialCareBrokerageInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResidentialCareBrokerageInfoResponse>> CreateResidentialCareBrokerage([FromBody] ResidentialCareBrokerageCreationRequest residentialCareBrokerageCreationRequest)
        {
            if (residentialCareBrokerageCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var residentialCareBrokerageCreationDomain = residentialCareBrokerageCreationRequest.ToDomain();
            var result = await _createResidentialCareBrokerageUseCase.ExecuteAsync(residentialCareBrokerageCreationDomain).ConfigureAwait(false);
            //Change status of package
            await _changeStatusResidentialCarePackageUseCase
                .UpdateAsync(residentialCareBrokerageCreationRequest.ResidentialCarePackageId, 6)
                .ConfigureAwait(false);
            return Ok(result);
        }
    }
}
