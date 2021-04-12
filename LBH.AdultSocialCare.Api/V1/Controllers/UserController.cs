using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/users")]
    [Produces("application/json")]
    [ApiController]
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

        [HttpPost]
        public async Task<ActionResult<UsersResponse>> Create(UsersRequest usersRequest)
        {
            try
            {
                UsersDomain usersDomain = UserFactory.ToDomain(usersRequest);
                var usersResponse = UserFactory.ToResponse(await _upsertUsersUseCase.ExecuteAsync(usersDomain).ConfigureAwait(false));
                if (usersResponse == null) return NotFound();
                //else if (!usersResponse.Success) return BadRequest(usersResponse.Message);
                return Ok(usersResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UsersResponse>> Get(Guid userId)
        {
            return UserFactory.ToResponse(await _getUsersUseCase.GetAsync(userId).ConfigureAwait(false));
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<bool>> Delete(Guid userId)
        {
            return await _deleteUsersUseCase.DeleteAsync(userId).ConfigureAwait(false);
        }
    }
}
