using Amazon.Runtime;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    //TODO possibly will be removed
    [Route("api/v1/clients")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ClientController : BaseController
    {
        private readonly IUpsertClientsUseCase _upsertClientsUseCase;
        private readonly IGetClientsUseCase _getClientsUseCase;
        private readonly IGetServiceUsersUseCase _getServiceUsersUseCase;
        private readonly IDeleteClientsUseCase _deleteClientsUseCase;

        public ClientController(IUpsertClientsUseCase upsertClientsUseCase,
            IGetClientsUseCase getClientsUseCase,
            IGetServiceUsersUseCase getServiceUsersUseCase,
            IDeleteClientsUseCase deleteClientsUseCase)
        {
            _upsertClientsUseCase = upsertClientsUseCase;
            _getClientsUseCase = getClientsUseCase;
            _getServiceUsersUseCase = getServiceUsersUseCase;
            _deleteClientsUseCase = deleteClientsUseCase;
        }

        /// <summary>Creates the specified client request.</summary>
        /// <param name="serviceUserRequest">The client request.</param>
        /// <returns>The client creation response.</returns>
        [ProducesResponseType(typeof(ServiceUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult<ServiceUserResponse>> Create(ServiceUserRequest serviceUserRequest)
        {
            try
            {
                var usersDomain = serviceUserRequest.ToDomain();
                var res = await _upsertClientsUseCase.ExecuteAsync(usersDomain)
                    .ConfigureAwait(false);

                var clientsResponse = res.ToResponse();

                if (clientsResponse == null) return NotFound();
                return Ok(clientsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified client identifier.</summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>The client creation response.</returns>
        [ProducesResponseType(typeof(ServiceUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{clientId}")]
        public async Task<ActionResult<ServiceUserResponse>> Get(Guid clientId)
        {
            try
            {
                var res = await _getClientsUseCase.GetAsync(clientId).ConfigureAwait(false);
                return Ok(res?.ToResponse());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Returns a sub-page of all service users list as defined by <paramref name="parameters"/>.</summary>
        /// <remarks>Returns pagination info in X-Pagination header</remarks>
        /// <param name="parameters">Pagination parameters</param>
        /// <param name="serviceUserName">Part of the service user's name to search by.</param>
        /// <returns>A sub-page of all service users list.</returns>
        [ProducesResponseType(typeof(ServiceUserResponse), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("get-all")] // TODO: Remove get-all
        public async Task<ActionResult<PaginatedResponse<ServiceUserResponse>>> GetAll([FromQuery] RequestParameters parameters, string serviceUserName)
        {
            var result = await _getServiceUsersUseCase.GetAllAsync(parameters, serviceUserName).ConfigureAwait(false);

            Response.AddPaginationHeaders(result.PagingMetaData);

            return Ok(result);
        }

        /// <summary>Deletes the specified client identifier.</summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>the boolean value</returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpDelete]
        [Route("{clientId}")]
        [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult<bool>> Delete(Guid clientId)
        {
            try
            {
                return Ok(await _deleteClientsUseCase.DeleteAsync(clientId).ConfigureAwait(false));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
