using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/clients")]
    [Produces("application/json")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IUpsertClientsUseCase _upsertClientsUseCase;
        private readonly IGetClientsUseCase _getClientsUseCase;
        private readonly IDeleteClientsUseCase _deleteClientsUseCase;

        public ClientController(IUpsertClientsUseCase upsertClientsUseCase,
            IGetClientsUseCase getClientsUseCase,
            IDeleteClientsUseCase deleteClientsUseCase)
        {
            _upsertClientsUseCase = upsertClientsUseCase;
            _getClientsUseCase = getClientsUseCase;
            _deleteClientsUseCase = deleteClientsUseCase;
        }

        /// <summary>Creates the specified clients request.</summary>
        /// <param name="clientsRequest">The clients request.</param>
        /// <returns>The client creation response.</returns>
        [HttpPost]
        public async Task<ActionResult<ClientsResponse>> Create(ClientsRequest clientsRequest)
        {
            try
            {
                ClientsDomain usersDomain = ClientsFactory.ToDomain(clientsRequest);

                ClientsResponse clientsResponse =
                    ClientsFactory.ToResponse(await _upsertClientsUseCase.ExecuteAsync(usersDomain)
                        .ConfigureAwait(false));

                if (clientsResponse == null) return NotFound();
                return Ok(clientsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception exc)
            {
                // TODO remove
                Debugger.Break();
                return BadRequest(exc.Message);
            }
        }

        /// <summary>Gets the specified client identifier.</summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>The client creation response.</returns>
        [HttpGet]
        [Route("{clientId}")]
        public async Task<ActionResult<ClientsResponse>> Get(Guid clientId)
        {
            try
            {
                return Ok(ClientsFactory.ToResponse(await _getClientsUseCase.GetAsync(clientId).ConfigureAwait(false)));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Deletes the specified client identifier.</summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>the boolean value</returns>
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
    }
}
