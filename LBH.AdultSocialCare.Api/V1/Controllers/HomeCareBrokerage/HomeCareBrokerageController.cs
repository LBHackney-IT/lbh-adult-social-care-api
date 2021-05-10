using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCareBrokerage
{
    [Route("api/v1/home-care-packages/{homeCarePackageId}/brokerage")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCareBrokerageController : BaseController
    {
        private readonly IGetHomeCareBrokerageUseCase _getHomeCareBrokerageUseCase;
        private readonly ICreateHomeCareBrokerageUseCase _createHomeCareBrokerageUseCase;
        private readonly ICreateHomeCareRequestMoreInformationUseCase _createHomeCareRequestMoreInformationUseCase;

        public HomeCareBrokerageController(IGetHomeCareBrokerageUseCase getHomeCareBrokerageUseCase,
            ICreateHomeCareBrokerageUseCase createHomeCareBrokerageUseCase,
            ICreateHomeCareRequestMoreInformationUseCase createHomeCareRequestMoreInformationUseCase)
        {
            _getHomeCareBrokerageUseCase = getHomeCareBrokerageUseCase;
            _createHomeCareBrokerageUseCase = createHomeCareBrokerageUseCase;
            _createHomeCareRequestMoreInformationUseCase = createHomeCareRequestMoreInformationUseCase;
        }

        /// <summary>Gets the specified home care package identifier.</summary>
        /// <param name="homeCarePackageId">The home care package identifier.</param>
        /// <returns>The home care brokerage response.</returns>
        [HttpGet]
        public async Task<ActionResult<HomeCareBrokerageResponse>> GetHomeCareBrokerage(Guid homeCarePackageId)
        {
            var homeCareBrokerageResponse = await _getHomeCareBrokerageUseCase.Execute(homeCarePackageId).ConfigureAwait(false);
            return Ok(homeCareBrokerageResponse);
        }

        /// <summary>
        /// Creates the home care package brokerage.
        /// </summary>
        /// <param name="homeCarePackageId">The home care package identifier.</param>
        /// <param name="homeCareBrokerageCreationRequest">The home care package brokerage for creation.</param>
        /// <returns>A newly created home care package brokerage</returns>
        /// <response code="200">Returns ID of the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the home care package for this brokerage is not found</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(HomeCareBrokerageCreationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<HomeCareBrokerageCreationResponse>> CreateHomeCarePackage(Guid homeCarePackageId, [FromBody] HomeCareBrokerageCreationRequest homeCareBrokerageCreationRequest)
        {
            if (homeCareBrokerageCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var homeCareBrokerageCreationDomain = homeCareBrokerageCreationRequest.ToDomain();
            var result = await _createHomeCareBrokerageUseCase.ExecuteAsync(homeCarePackageId, homeCareBrokerageCreationDomain).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Creates the home care request more information.
        /// </summary>
        /// <param name="homeCareRequestMoreInformationForCreationRequest">The home care package brokerage for creation.</param>
        /// <returns>A boolean value if home care request more information succeed</returns>
        /// <response code="200">Returns boolean value</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> CreateHomeCareRequestMoreInformation([FromBody] HomeCareRequestMoreInformationForCreationRequest homeCareRequestMoreInformationForCreationRequest)
        {
            if (homeCareRequestMoreInformationForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var homeCareBrokerageCreationDomain = homeCareRequestMoreInformationForCreationRequest.ToDomain();
            var result = await _createHomeCareRequestMoreInformationUseCase.Execute(homeCareBrokerageCreationDomain).ConfigureAwait(false);
            return Ok(result);
        }

    }
}
