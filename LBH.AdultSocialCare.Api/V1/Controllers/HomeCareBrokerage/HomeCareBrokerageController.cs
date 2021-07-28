using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        private readonly IChangeStatusHomeCarePackageUseCase _changeStatusHomeCarePackageUseCase;

        public HomeCareBrokerageController(IGetHomeCareBrokerageUseCase getHomeCareBrokerageUseCase,
            ICreateHomeCareBrokerageUseCase createHomeCareBrokerageUseCase,
            ICreateHomeCareRequestMoreInformationUseCase createHomeCareRequestMoreInformationUseCase,
            IChangeStatusHomeCarePackageUseCase changeStatusHomeCarePackageUseCase)
        {
            _getHomeCareBrokerageUseCase = getHomeCareBrokerageUseCase;
            _createHomeCareBrokerageUseCase = createHomeCareBrokerageUseCase;
            _createHomeCareRequestMoreInformationUseCase = createHomeCareRequestMoreInformationUseCase;
            _changeStatusHomeCarePackageUseCase = changeStatusHomeCarePackageUseCase;
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
        public async Task<ActionResult<HomeCareBrokerageCreationResponse>> CreateHomeCareBrokerage(Guid homeCarePackageId, [FromBody] HomeCareBrokerageCreationRequest homeCareBrokerageCreationRequest)
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
            var result = await _createHomeCareBrokerageUseCase.ExecuteAsync(homeCarePackageId, homeCareBrokerageCreationDomain)
                .ConfigureAwait(false);
            //Change status of package
            await _changeStatusHomeCarePackageUseCase
                .UpdateAsync(homeCarePackageId, ApprovalHistoryConstants.ApprovedForBrokerageId)
                .ConfigureAwait(false);
            return Ok(result);
        }
    }
}
