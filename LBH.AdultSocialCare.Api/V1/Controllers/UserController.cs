using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/users")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        private readonly IUpsertUsersUseCase _upsertUsersUseCase;
        private readonly IGetUsersUseCase _getUsersUseCase;
        private readonly IDeleteUsersUseCase _deleteUsersUseCase;

        public UserController(IUpsertUsersUseCase upsertUsersUseCase,
            IGetUsersUseCase getUsersUseCase,
            IDeleteUsersUseCase deleteUsersUseCase)
        {
            _upsertUsersUseCase = upsertUsersUseCase;
            _getUsersUseCase = getUsersUseCase;
            _deleteUsersUseCase = deleteUsersUseCase;
        }

        /// <summary>Creates the specified users request.</summary>
        /// <param name="usersRequest">The users request.</param>
        /// <returns>The created User Response model</returns>
        [ProducesResponseType(typeof(UsersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<UsersResponse>> Create(UsersRequest usersRequest)
        {
            try
            {
                UsersDomain usersDomain = UserFactory.ToDomain(usersRequest);
                UsersResponse usersResponse = UserFactory.ToResponse(await _upsertUsersUseCase.ExecuteAsync(usersDomain).ConfigureAwait(false));
                if (usersResponse == null) return NotFound();
                return Ok(usersResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified user identifier.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The User Response model</returns>
        [ProducesResponseType(typeof(UsersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UsersResponse>> Get(Guid userId)
        {
            return UserFactory.ToResponse(await _getUsersUseCase.GetAsync(userId).ConfigureAwait(false));
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<bool>> Delete(Guid userId)
        {
            return await _deleteUsersUseCase.DeleteAsync(userId).ConfigureAwait(false);
        }
    }
}
