using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/care-packages/{packageId}/details")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class CarePackageBrokerageController : ControllerBase
    {
        private readonly ICarePackageBrokerageUseCase _carePackageBrokerageUseCase;

        public CarePackageBrokerageController(ICarePackageBrokerageUseCase carePackageBrokerageUseCase)
        {
            _carePackageBrokerageUseCase = carePackageBrokerageUseCase;
        }

        /// <summary>
        /// Creates a list of details (core cost, additional needs etc.) for a package with the given packageId
        /// </summary>
        /// <param name="packageId">Unique identifier of the package to be brokered</param>
        /// <param name="brokerageRequest">Request with information about services and costs.</param>
        /// <returns>OK if operation is successful</returns>
        /// <response code="200">If operation have completed successfully</response>
        /// <response code="409">If core cost is already set for the given package</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> BrokerCarePackage(Guid packageId, CarePackageBrokerageRequest brokerageRequest)
        {
            await _carePackageBrokerageUseCase.CreateCarePackageBrokerageAsync(packageId, brokerageRequest.ToDomain());
            return Ok();
        }
    }
}
