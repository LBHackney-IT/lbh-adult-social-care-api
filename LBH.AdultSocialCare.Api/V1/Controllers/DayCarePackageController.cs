using Amazon.DynamoDBv2.Model;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/day-care-packages")]
    [Produces("application/json")]
    [ApiController]
    public class DayCarePackageController : ControllerBase
    {
        private readonly ICreateDayCarePackageUseCase _createDayCarePackageUseCase;
        private readonly IGetDayCarePackageUseCase _getDayCarePackageUseCase;
        private readonly IGetDayCarePackageListUseCase _getDayCarePackageListUseCase;
        private readonly IUpdateDayCarePackageUseCase _updateDayCarePackageUseCase;

        public DayCarePackageController(
            ICreateDayCarePackageUseCase createdDayCarePackageUseCase,
            IGetDayCarePackageUseCase getDayCarePackageUseCase,
            IGetDayCarePackageListUseCase getDayCarePackageListUseCase,
            IUpdateDayCarePackageUseCase updateDayCarePackageUseCase)
        {
            _createDayCarePackageUseCase = createdDayCarePackageUseCase;
            _getDayCarePackageUseCase = getDayCarePackageUseCase;
            _getDayCarePackageListUseCase = getDayCarePackageListUseCase;
            _updateDayCarePackageUseCase = updateDayCarePackageUseCase;
        }

        /// <summary>Creates the day care package.</summary>
        /// <param name="dayCarePackageForCreation">The day care package for creation.</param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> CreateDayCarePackage([FromBody] DayCarePackageForCreationRequest dayCarePackageForCreation)
        {
            if (dayCarePackageForCreation == null)
            {
                return UnprocessableEntity("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageDomain = dayCarePackageForCreation.ToDomain();
            var result = await _createDayCarePackageUseCase.Execute(dayCarePackageDomain).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get a day care package by Id
        /// </summary>
        /// <param name="dayCarePackageId"></param>
        /// <returns></returns>
        [HttpGet("{dayCarePackageId}")]
        [ProducesResponseType(typeof(DayCarePackageResponse), 200)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetSingleDayCarePackage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _getDayCarePackageUseCase.Execute(dayCarePackageId).ConfigureAwait(false);
            return Ok(dayCarePackage);
        }

        /// <summary>
        /// Gets the day care package list.
        /// </summary>
        /// <returns>List of day care packages</returns>
        [ProducesResponseType(typeof(IEnumerable<DayCarePackageResponse>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayCarePackageResponse>>> GetDayCarePackageList()
        {
            return Ok(await _getDayCarePackageListUseCase.Execute().ConfigureAwait(false));
        }

        /// <summary>
        /// Updates the day care package.
        /// </summary>
        /// <param name="dayCarePackageId">The day care package identifier.</param>
        /// <param name="dayCarePackageForUpdate">The day care package for update.</param>
        /// <returns>Updated day care package</returns>
        /// <returns>Day care not found</returns>
        [HttpPut("{dayCarePackageId}")]
        [ProducesResponseType(typeof(DayCarePackageResponse), 200)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DayCarePackageResponse>> UpdateDayCarePackage(
            Guid dayCarePackageId,
            DayCarePackageForUpdateRequest dayCarePackageForUpdate)
        {
            if (dayCarePackageForUpdate == null)
            {
                return UnprocessableEntity("Object for update cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageForUpdateDomain = dayCarePackageForUpdate.ToDomain();
            var result = await _updateDayCarePackageUseCase.Execute(dayCarePackageId, dayCarePackageForUpdateDomain).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
