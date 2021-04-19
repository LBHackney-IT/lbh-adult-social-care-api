using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.HomeCare;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
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
        private readonly IGetAllHomeCarePackageUseCase _getAllHomeCarePackageUseCase;

        public HomeCarePackageController(IUpsertHomeCarePackageUseCase upsertHomeCarePackageUseCase,
            IChangeStatusHomeCarePackageUseCase updateHomeCarePackageUseCase,
            IGetAllHomeCarePackageUseCase getAllHomeCarePackageUseCase)
        {
            _upsertHomeCarePackageUseCase = upsertHomeCarePackageUseCase;
            _updateHomeCarePackageUseCase = updateHomeCarePackageUseCase;
            _getAllHomeCarePackageUseCase = getAllHomeCarePackageUseCase;
        }

        /// <summary>Change the home care package status.</summary>
        /// <param name="homeCarePackageId"></param>
        /// <param name="statusId"></param>
        /// <returns>The home care package response model.</returns>
        [ProducesResponseType(typeof(HomeCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPut]
        [Route("{homeCarePackageId}/changeStatus/{statusId}")]
        public async Task<ActionResult<HomeCarePackageResponse>> ChangeStatus(
            Guid homeCarePackageId, int statusId)
        {
            try
            {
                HomeCarePackageResponse homeCarePackageResponse =
                    HomeCarePackageFactory.ToResponse(await _updateHomeCarePackageUseCase
                        .UpdateAsync(homeCarePackageId, statusId)
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

        /// <summary>Get all Home Care Packages</summary>
        /// <returns>The list of Home Care Package Response model</returns>
        [ProducesResponseType(typeof(IList<HomeCarePackageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<HomeCarePackage>>> GetAll()
        {
            try
            {
                IList<HomeCarePackage> result = await _getAllHomeCarePackageUseCase.GetAllAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
