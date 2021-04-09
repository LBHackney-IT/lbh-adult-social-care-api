using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/status")]
    [Produces("application/json")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IUpsertStatusUseCase _upsertStatusUseCase;
        private readonly IGetStatusUseCase _getStatusUseCase;
        private readonly IGetAllStatusUseCase _getAllStatusUseCase;
        private readonly IDeleteStatusUseCase _deleteStatusUseCase;

        public StatusController(IUpsertStatusUseCase upsertStatusUseCase,
            IGetStatusUseCase getStatusUseCase,
            IGetAllStatusUseCase getAllStatusUseCase,
            IDeleteStatusUseCase deleteStatusUseCase)
        {
            _upsertStatusUseCase = upsertStatusUseCase;
            _getStatusUseCase = getStatusUseCase;
            _getAllStatusUseCase = getAllStatusUseCase;
            _deleteStatusUseCase = deleteStatusUseCase;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<StatusResponse>> Create(StatusRequest statusRequest)
        {
            try
            {
                StatusDomain statusDomain = StatusFactory.ToDomain(statusRequest);
                var statusResponse = StatusFactory.ToResponse(await _upsertStatusUseCase.ExecuteAsync(statusDomain).ConfigureAwait(false));
                if (statusResponse == null) return NotFound();
                //else if (!statusResponse.Success) return BadRequest(statusResponse.Message);
                return Ok(statusResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{statusId}")]
        public async Task<ActionResult<StatusResponse>> Get(Guid statusId)
        {
            try
            {
                return Ok(StatusFactory.ToResponse(await _getStatusUseCase.GetAsync(statusId).ConfigureAwait(false)));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<Status>>> GetAll()
        {
            try
            {
                var result = await _getAllStatusUseCase.GetAllAsync().ConfigureAwait(false);
                if (result == null) return NotFound();
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{statusId}")]
        public async Task<ActionResult<bool>> Delete(Guid statusId)
        {
            try
            {
                return Ok(await _deleteStatusUseCase.DeleteAsync(statusId).ConfigureAwait(false));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
