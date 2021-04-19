using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{

    [Route("api/v1/role")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class RoleController : BaseController
    {

        private readonly IUpsertRoleUseCase _upsertRoleUseCase;
        private readonly IGetRoleUseCase _getRoleUseCase;
        private readonly IGetAllRoleUseCase _getAllRoleUseCase;
        private readonly IDeleteRoleUseCase _deleteRoleUseCase;

        public RoleController(IUpsertRoleUseCase upsertRoleUseCase, IGetRoleUseCase getRoleUseCase,
            IGetAllRoleUseCase getAllPackageUseCase, IDeleteRoleUseCase deleteRoleUseCase)
        {
            _upsertRoleUseCase = upsertRoleUseCase;
            _getRoleUseCase = getRoleUseCase;
            _getAllRoleUseCase = getAllPackageUseCase;
            _deleteRoleUseCase = deleteRoleUseCase;
        }

        /// <summary>Creates the specified roles request.</summary>
        /// <param name="rolesRequest">The roles request.</param>
        /// <returns>The created role response.</returns>
        [ProducesResponseType(typeof(RolesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<RolesResponse>> Create(RolesRequest rolesRequest)
        {
            try
            {
                RolesDomain roleDomain = RolesFactory.ToDomain(rolesRequest);

                RolesResponse roleResponse =
                    RolesFactory.ToResponse(await _upsertRoleUseCase.ExecuteAsync(roleDomain).ConfigureAwait(false));

                if (roleResponse == null) return NotFound();

                return Ok(roleResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified role identifier.</summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>The role response.</returns>
        [ProducesResponseType(typeof(RolesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{roleId}")]
        public async Task<ActionResult<RolesResponse>> Get(int roleId)
        {
            try
            {
                return Ok(RolesFactory.ToResponse(await _getRoleUseCase.GetAsync(roleId).ConfigureAwait(false)));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets all.</summary>
        /// <returns>The list of Roles response</returns>
        [ProducesResponseType(typeof(IList<Roles>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<Roles>>> GetAll()
        {
            try
            {
                IList<Roles> result = await _getAllRoleUseCase.GetAllAsync().ConfigureAwait(false);
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        [Route("{roleId}")]
        public async Task<ActionResult<bool>> Delete(int roleId)
        {
            try
            {
                return Ok(await _deleteRoleUseCase.DeleteAsync(roleId).ConfigureAwait(false));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
