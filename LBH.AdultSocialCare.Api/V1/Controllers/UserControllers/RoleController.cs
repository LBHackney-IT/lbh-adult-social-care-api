using LBH.AdultSocialCare.Api.V1.Boundary.RoleBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.UserControllers
{
    [Route("api/v1/role")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class RoleController : BaseController
    {
        private readonly IGetRoleUseCase _getRoleUseCase;
        private readonly IGetAllRoleUseCase _getAllRoleUseCase;
        private readonly IDeleteRoleUseCase _deleteRoleUseCase;

        public RoleController(IGetRoleUseCase getRoleUseCase,
            IGetAllRoleUseCase getAllPackageUseCase, IDeleteRoleUseCase deleteRoleUseCase)
        {
            _getRoleUseCase = getRoleUseCase;
            _getAllRoleUseCase = getAllPackageUseCase;
            _deleteRoleUseCase = deleteRoleUseCase;
        }

        /// <summary>Gets the specified role identifier.</summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>The role response.</returns>
        [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{roleId}")]
        public async Task<ActionResult<RoleResponse>> Get(Guid roleId)
        {
            var res = await _getRoleUseCase.GetAsync(roleId).ConfigureAwait(false);
            return Ok(res);
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

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        [Route("{roleId}")]
        public async Task<ActionResult<bool>> Delete(Guid roleId)
        {
            return Ok(await _deleteRoleUseCase.DeleteAsync(roleId).ConfigureAwait(false));
        }
    }
}
