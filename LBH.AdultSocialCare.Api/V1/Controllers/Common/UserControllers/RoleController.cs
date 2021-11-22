using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common.UserControllers
{
    [Route("api/v1/role")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class RoleController : BaseController
    {
        private readonly IGetAllRoleUseCase _getAllRoleUseCase;

        public RoleController(IGetAllRoleUseCase getAllPackageUseCase)
        {
            _getAllRoleUseCase = getAllPackageUseCase;
        }

        /// <summary>Gets all.</summary>
        /// <returns>The list of Role response</returns>
        [ProducesResponseType(typeof(IList<RoleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<RoleResponse>>> GetAll()
        {
            var res = await _getAllRoleUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(res);
        }
    }
}
