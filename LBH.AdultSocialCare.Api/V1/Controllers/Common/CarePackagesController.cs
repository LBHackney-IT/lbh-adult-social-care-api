using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/care-packages")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CarePackagesController : ControllerBase
    {
        private readonly ICreateCarePackageUseCase _createCarePackageUseCase;

        public CarePackagesController(ICreateCarePackageUseCase createCarePackageUseCase)
        {
            _createCarePackageUseCase = createCarePackageUseCase;
        }

        /// <summary>Creates a new care package.</summary>
        /// <param name="carePackageForCreationRequest">The care package request.</param>
        /// <returns>The care package created.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<CarePackagePlainResponse>> CreateCarePackage([FromBody] CarePackageForCreationRequest carePackageForCreationRequest)
        {
            var residentialCarePackageResponse = await _createCarePackageUseCase.CreateAsync(carePackageForCreationRequest.ToDomain()).ConfigureAwait(false);
            return Ok(residentialCarePackageResponse);
        }
    }
}