using Amazon.DynamoDBv2.Model;
using BaseApi.V1.Boundary.DayCarePackageBoundary.Request;
using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;
using BaseApi.V1.Factories;
using BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.Controllers
{
    [Route("api/v1/day-care-packages")]
    [Produces("application/json")]
    [ApiController]
    public class DayCarePackageController : ControllerBase
    {
        private readonly ICreateDayCarePackageUseCase _createdDayCarePackageUseCase;
        private readonly IGetDayCarePackageUseCase _getDayCarePackageUseCase;
        private readonly IGetDayCarePackageListUseCase _getDayCarePackageListUseCase;

        public DayCarePackageController(
            ICreateDayCarePackageUseCase createdDayCarePackageUseCase,
            IGetDayCarePackageUseCase getDayCarePackageUseCase,
            IGetDayCarePackageListUseCase getDayCarePackageListUseCase)
        {
            _createdDayCarePackageUseCase = createdDayCarePackageUseCase;
            _getDayCarePackageUseCase = getDayCarePackageUseCase;
            _getDayCarePackageListUseCase = getDayCarePackageListUseCase;
        }

        /// <summary>Creates the day care package.</summary>
        /// <param name="dayCarePackageForCreation">The day care package for creation.</param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> CreateDayCarePackage([FromBody] DayCarePackageForCreationRequest dayCarePackageForCreation)
        {
            try
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
                var result = await _createdDayCarePackageUseCase.Execute(dayCarePackageDomain).ConfigureAwait(false);
                return Ok(result);
            }
            catch (NotSupportedException e)
            {
                return BadRequest(e.Message);
            }
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
            try
            {
                var dayCarePackage = await _getDayCarePackageUseCase.Execute(dayCarePackageId).ConfigureAwait(false);
                return Ok(dayCarePackage);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
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
    }
}
