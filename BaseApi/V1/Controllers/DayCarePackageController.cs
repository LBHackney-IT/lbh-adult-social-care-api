using BaseApi.V1.Boundary.DayCarePackageBoundary.Request;
using BaseApi.V1.Factories;
using BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;

namespace BaseApi.V1.Controllers
{
    [Route("api/v1/day-care-packages")]
    [Produces("application/json")]
    [ApiController]
    public class DayCarePackageController : ControllerBase
    {
        private readonly ICreateDayCarePackageUseCase _createdDayCarePackageUseCase;
        private readonly IGetDayCarePackageUseCase _getDayCarePackageUseCase;

        public DayCarePackageController(ICreateDayCarePackageUseCase createdDayCarePackageUseCase, IGetDayCarePackageUseCase getDayCarePackageUseCase)
        {
            _createdDayCarePackageUseCase = createdDayCarePackageUseCase;
            _getDayCarePackageUseCase = getDayCarePackageUseCase;
        }
        /// <summary>
        /// Create day care package
        /// </summary>
        /// <param name="dayCarePackageForCreation"></param>
        /// <returns></returns>
        [HttpPost]
        // [Route("new")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateDayCarePackage([FromBody] DayCarePackageForCreationRequest dayCarePackageForCreation)
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

                var result = await _createdDayCarePackageUseCase.Execute(dayCarePackageForCreation.ToDb()).ConfigureAwait(false);
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
    }
}
