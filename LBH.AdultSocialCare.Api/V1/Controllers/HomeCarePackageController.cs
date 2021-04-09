using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HomeCarePackageController : Controller
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
        [HttpPost]
        public async Task<ActionResult<HomeCarePackageResponse>> Create(HomeCarePackageRequest homeCarePackageRequest)
        {
            try
            {
                HomeCarePackageDomain homeCarePackageDomain = HomeCarePackageFactory.ToDomain(homeCarePackageRequest);

                HomeCarePackageResponse homeCarePackageResponse =
                    HomeCarePackageFactory.ToResponse(await _upsertHomeCarePackageUseCase
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
