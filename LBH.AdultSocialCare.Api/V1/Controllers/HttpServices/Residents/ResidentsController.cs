using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.Models;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Boundary.Resident.Response;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HttpServices.Residents
{
    [Route("api/v1/residents")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentsController : ControllerBase
    {
        private readonly IResidentsService _residentsService;

        public ResidentsController(IResidentsService residentsService)
        {
            _residentsService = residentsService;
        }

        /// <summary>Return service user information.</summary>
        /// <returns>The Service User Information response.</returns>
        [ProducesResponseType(typeof(ServiceUserInformationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("{residentsId}")]
        public async Task<ActionResult<ServiceUserInformationResponse>> GetServiceUserInformation(int residentsId)
        {
            var result = await _residentsService.GetAsync(residentsId);
            return Ok(result);
        }
    }
}
