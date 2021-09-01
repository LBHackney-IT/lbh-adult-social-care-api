using System;
using System.Threading.Tasks;
using Amazon.Runtime;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/clients")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ClientController : BaseController
    {
        private readonly IUpsertClientsUseCase _upsertClientsUseCase;
        private readonly IGetClientsUseCase _getClientsUseCase;
        private readonly IGetAllClientsUseCase _getAllClientsUseCase;
        private readonly IDeleteClientsUseCase _deleteClientsUseCase;
        private readonly IGetClientPackagesCountUseCase _getClientPackagesCountUseCase;

        public ClientController(IUpsertClientsUseCase upsertClientsUseCase,
            IGetClientsUseCase getClientsUseCase,
            IGetClientPackagesCountUseCase getClientPackagesCountUseCase,
            IGetAllClientsUseCase getAllClientsUseCase,
            IDeleteClientsUseCase deleteClientsUseCase)
        {
            _upsertClientsUseCase = upsertClientsUseCase;
            _getClientsUseCase = getClientsUseCase;
            _getClientPackagesCountUseCase = getClientPackagesCountUseCase;
            _getAllClientsUseCase = getAllClientsUseCase;
            _deleteClientsUseCase = deleteClientsUseCase;
        }

        /// <summary>Creates the specified client request.</summary>
        /// <param name="clientsRequest">The client request.</param>
        /// <returns>The client creation response.</returns>
        [ProducesResponseType(typeof(ClientsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<ClientsResponse>> Create(ClientsRequest clientsRequest)
        {
            try
            {
                var usersDomain = clientsRequest.ToDomain();
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
        [ProducesResponseType(typeof(ClientsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{clientId}")]
        public async Task<ActionResult<ClientsResponse>> Get(Guid clientId)
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

        /// <summary>Returns a sub-page of all clients list as defined by <paramref name="parameters"/>.</summary>
        /// <remarks>Returns pagination info in X-Pagination header</remarks>
        /// <param name="parameters">Pagination parameters</param>
        /// <param name="clientName">Part of the client's name to search by.</param>
        /// <returns>A sub-page of all clients list.</returns>
        [ProducesResponseType(typeof(ClientsResponse), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<PaginatedResponse<ClientsResponse>>> GetAll([FromQuery] RequestParameters parameters, string clientName)
        {
            var result = await _getAllClientsUseCase.GetAllAsync(parameters, clientName).ConfigureAwait(false);

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

        /// <summary>
        /// Returns 204 if client has at least one package of the give <paramref name="packageTypeId"/>, otherwise, 404.
        /// </summary>
        /// <remarks>Returns total count of client's packages of a given type in X-Total-Count response header.</remarks>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="packageTypeId">Identifier of the package type. Can be omitted to get information about packages of any type.</param>
        /// <response code="204">Client has at least one package of the given <paramref name="packageTypeId"/></response>
        /// <response code="404">Client doesn't have any packages of the given <paramref name="packageTypeId"/></response>
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [HttpHead]
        [Route("{clientId}/packages")]
        public async Task<StatusCodeResult> GetPackagesMetadata(Guid clientId, int? packageTypeId)
        {
            var packagesCount = await _getClientPackagesCountUseCase.GetCountAsync(clientId, packageTypeId).ConfigureAwait(false);

            Response.Headers.Add("X-Total-Count", new StringValues(packagesCount.ToString()));

            return packagesCount > 0 ? (StatusCodeResult) NoContent() : NotFound();
        }
    }
}
