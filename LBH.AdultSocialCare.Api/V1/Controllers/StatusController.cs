using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [Authorize]
    public class StatusController : BaseController
    {
        private readonly IUpsertStatusUseCase _upsertStatusUseCase;
        private readonly IGetStatusUseCase _getStatusUseCase;
        private readonly IGetAllStatusUseCase _getAllStatusUseCase;
        private readonly IDeleteStatusUseCase _deleteStatusUseCase;

        public StatusController(IUpsertStatusUseCase upsertStatusUseCase, IGetStatusUseCase getStatusUseCase,
            IGetAllStatusUseCase getAllStatusUseCase, IDeleteStatusUseCase deleteStatusUseCase)
        {
            _upsertStatusUseCase = upsertStatusUseCase;
            _getStatusUseCase = getStatusUseCase;
            _getAllStatusUseCase = getAllStatusUseCase;
            _deleteStatusUseCase = deleteStatusUseCase;
        }

        /// <summary>Creates the specified status request.</summary>
        /// <param name="statusRequest">The status request.</param>
        /// <returns>The created status response.</returns>
        [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<StatusResponse>> Create([FromBody] StatusRequest statusRequest)
        {
            try
            {
                var statusDomain = statusRequest.ToDomain();
                var res = await _upsertStatusUseCase.ExecuteAsync(statusDomain).ConfigureAwait(false);
                var statusResponse = res?.ToResponse();

                if (statusResponse == null) return NotFound();
                return Ok(statusResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified status identifier.</summary>
        /// <param name="statusId">The status identifier.</param>
        /// <returns>The created status response.</returns>
        [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{statusId}")]
        public async Task<ActionResult<StatusResponse>> Get(int statusId)
        {
            try
            {
                var res = await _getStatusUseCase.GetAsync(statusId).ConfigureAwait(false);
                return Ok(res?.ToResponse());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets all.</summary>
        /// <returns>The List of PackageStatuses model</returns>
        [ProducesResponseType(typeof(IList<PackageStatus>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<PackageStatus>>> GetAll()
        {
            try
            {
                IList<PackageStatus> result = await _getAllStatusUseCase.GetAllAsync().ConfigureAwait(false);

                if (result == null) return NotFound();

                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpDelete]
        [Route("{statusId}")]
        public async Task<ActionResult<bool>> Delete(int statusId)
        {
            try
            {
                return Ok(await _deleteStatusUseCase.DeleteAsync(statusId).ConfigureAwait(false));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
