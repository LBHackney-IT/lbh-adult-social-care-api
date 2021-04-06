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
    [Route("api/v1/service")]
    [Produces("application/json")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IUpsertServiceUseCase _upsertServiceUseCase;
        private readonly IGetServiceUseCase _getServiceUseCase;
        private readonly IGetAllServiceUseCase _getAllServiceUseCase;
        private readonly IDeleteServiceUseCase _deleteServiceUseCase;

        public ServiceController
            (IUpsertServiceUseCase upsertServiceUseCase,
            IGetServiceUseCase getServiceUseCase,
            IGetAllServiceUseCase getAllServiceUseCase,
            IDeleteServiceUseCase deleteServiceUseCase)
        {
            _upsertServiceUseCase = upsertServiceUseCase;
            _getServiceUseCase = getServiceUseCase;
            _getAllServiceUseCase = getAllServiceUseCase;
            _deleteServiceUseCase = deleteServiceUseCase;
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ServiceResponse>> Create(ServiceResponse serviceResponse)
        {
            try
            {
                ServiceDomain serviceDomain = ServiceFactory.ToDomain(serviceResponse);
                serviceResponse = ServiceFactory.ToResponse(await _upsertServiceUseCase.ExecuteAsync(serviceDomain).ConfigureAwait(false));
                if (serviceResponse == null) return NotFound();
                else if (!serviceResponse.Success) return BadRequest(serviceResponse.Message);
                return Ok(serviceResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{serviceId}")]
        public async Task<ActionResult<ServiceResponse>> Get(Guid serviceId)
        {
            try
            {
                return Ok(ServiceFactory.ToResponse(await _getServiceUseCase.GetAsync(serviceId).ConfigureAwait(false)));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<PackageServices>>> GetAll()
        {
            try
            {
                var result = await _getAllServiceUseCase.GetAllAsync().ConfigureAwait(false);
                if (result == null) return NotFound();
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{serviceId}")]
        public async Task<ActionResult<bool>> Delete(Guid serviceId)
        {
            try
            {
                return Ok(await _deleteServiceUseCase.DeleteAsync(serviceId).ConfigureAwait(false));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
