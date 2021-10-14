using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [Authorize]
    public class StatusController : BaseController
    {
        private readonly IGetAllStatusUseCase _getAllStatusUseCase;

        public StatusController(IGetAllStatusUseCase getAllStatusUseCase)
        {
            _getAllStatusUseCase = getAllStatusUseCase;
        }

        // TODO: VK: Use lookups controller instead?
        /// <summary>Gets all.</summary>
        /// <returns>The List of PackageStatuses model</returns>
        [ProducesResponseType(typeof(IList<PackageStatusOption>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<PackageStatusOption>>> GetAll()
        {
            try
            {
                IList<PackageStatusOption> result = await _getAllStatusUseCase.GetAllAsync().ConfigureAwait(false);

                if (result == null) return NotFound();

                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
