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

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/home-care-packages-cost")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCarePackageCostController : BaseController
    {
        private readonly IUpsertHomeCarePackageCostUseCase _upsertHomeCarePackageCostUseCase;

        public HomeCarePackageCostController(IUpsertHomeCarePackageCostUseCase upsertHomeCarePackageCostUseCase)
        {
            _upsertHomeCarePackageCostUseCase = upsertHomeCarePackageCostUseCase;
        }

        /// <summary>
        /// Creates the specified home care package cost request.
        /// </summary>
        /// <returns>The home care package cost creation response.</returns>
        [ProducesResponseType(typeof(HomeCarePackageCostResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<HomeCarePackageCostResponse>> Create([FromBody] HomeCarePackageCostRequest homeCarePackageCostRequest)
        {
            try
            {
                HomeCarePackageCostDomain homeCarePackageDomain = HomeCarePackageCostFactory.ToDomain(homeCarePackageCostRequest);
                HomeCarePackageCostResponse homeCarePackageResponse = HomeCarePackageCostFactory.ToResponse(await _upsertHomeCarePackageCostUseCase
                        .ExecuteAsync(homeCarePackageDomain)
                        .ConfigureAwait(false));
                if (homeCarePackageResponse == null) return NotFound();
                return Ok(homeCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
