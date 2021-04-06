using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Controllers
{
    [Route("api/v1/role")]
    [Produces("application/json")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IUpsertRoleUseCase _upsertRoleUseCase;
        private readonly IGetRoleUseCase _getRoleUseCase;
        private readonly IGetAllRoleUseCase _getAllRoleUseCase;
        private readonly IDeleteRoleUseCase _deleteRoleUseCase;

        public RoleController(IUpsertRoleUseCase upsertRoleUseCase,
            IGetRoleUseCase getRoleUseCase,
            IGetAllRoleUseCase getAllPackageUseCase,
            IDeleteRoleUseCase deleteRoleUseCase)
        {
            _upsertRoleUseCase = upsertRoleUseCase;
            _getRoleUseCase = getRoleUseCase;
            _getAllRoleUseCase = getAllPackageUseCase;
            _deleteRoleUseCase = deleteRoleUseCase;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<RolesResponse>> Create(RolesResponse roleResponse)
        {
            try
            {
                RolesDomain roleDomain = RolesFactory.ToDomain(roleResponse);
                roleResponse = RolesFactory.ToResponse(await _upsertRoleUseCase.ExecuteAsync(roleDomain).ConfigureAwait(false));
                if (roleResponse == null) return NotFound();
                else if (!roleResponse.Success) return BadRequest(roleResponse.Message);
                return Ok(roleResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{roleId}")]
        public async Task<ActionResult<RolesResponse>> Get(Guid roleId)
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

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<Roles>>> GetAll()
        {
            try
            {
                var result = await _getAllRoleUseCase.GetAllAsync().ConfigureAwait(false);
                if (result == null) return NotFound();
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{roleId}")]
        public async Task<ActionResult<bool>> Delete(Guid roleId)
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
