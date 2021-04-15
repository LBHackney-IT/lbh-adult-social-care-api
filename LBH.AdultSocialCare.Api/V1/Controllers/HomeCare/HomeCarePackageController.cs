using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.HomeCare;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCarePackageController : BaseController
    {

        private readonly IUpsertHomeCarePackageUseCase _upsertHomeCarePackageUseCase;
        private readonly IChangeStatusHomeCarePackageUseCase _updateHomeCarePackageUseCase;

        public HomeCarePackageController(IUpsertHomeCarePackageUseCase upsertHomeCarePackageUseCase,
            IChangeStatusHomeCarePackageUseCase updateHomeCarePackageUseCase)
        {
            _upsertHomeCarePackageUseCase = upsertHomeCarePackageUseCase;
            _updateHomeCarePackageUseCase = updateHomeCarePackageUseCase;
        }

        /// <summary>
        /// Changes the home care package status.
        /// </summary>
        /// <param name="homeCarePackageRequest">The home care package request.</param>
        /// <returns>The home care package response model.</returns>
        [ProducesResponseType(typeof(HomeCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPut("changeStatus")]
        public async Task<ActionResult<HomeCarePackageResponse>> ChangeStatus(
            HomeCarePackageRequest homeCarePackageRequest)
        {
            try
            {
                HomeCarePackageDomain homeCarePackageDomain = HomeCarePackageFactory.ToDomain(homeCarePackageRequest);

                HomeCarePackageResponse homeCarePackageResponse =
                    HomeCarePackageFactory.ToResponse(await _updateHomeCarePackageUseCase
                        .UpdateAsync(homeCarePackageDomain)
                        .ConfigureAwait(false));

                if (homeCarePackageResponse == null) return NotFound();

                return Ok(homeCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates the specified home care package request.
        /// </summary>
        /// <param name="homeCarePackageRequest">The home care package request.</param>
        /// <returns>The home care package creation response.</returns>
        [ProducesResponseType(typeof(HomeCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<HomeCarePackageResponse>> Create(
            [FromBody] HomeCarePackageRequest homeCarePackageRequest)
        {
            try
            {
                HomeCarePackageDomain homeCarePackageDomain = HomeCarePackageFactory.ToDomain(homeCarePackageRequest);

                HomeCarePackageResponse homeCarePackageResponse =
                    HomeCarePackageFactory.ToResponse(await _upsertHomeCarePackageUseCase
                        .ExecuteAsync(homeCarePackageDomain)
                        .ConfigureAwait(false));

                if (homeCarePackageResponse == null)
                {
                    return NotFound();
                }

                return Ok(homeCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception exc)
            {
                // TODO remove
                Debugger.Break();
                return BadRequest(exc.Message);
            }
        }

    }

}
