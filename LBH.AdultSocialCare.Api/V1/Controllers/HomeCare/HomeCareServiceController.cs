using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCareServiceController : BaseController
    {

        private readonly IUpsertServiceUseCase _upsertServiceUseCase;
        private readonly IGetServiceUseCase _getServiceUseCase;
        private readonly IGetAllHomeCareServiceTypesUseCase _getAllHomeCareServiceTypesUseCase;
        private readonly IDeleteServiceUseCase _deleteServiceUseCase;

        public HomeCareServiceController(IUpsertServiceUseCase upsertServiceUseCase, IGetServiceUseCase getServiceUseCase,
            IGetAllHomeCareServiceTypesUseCase getAllHomeCareServiceTypesUseCase,
            IDeleteServiceUseCase deleteServiceUseCase)
        {
            _upsertServiceUseCase = upsertServiceUseCase;
            _getServiceUseCase = getServiceUseCase;
            _getAllHomeCareServiceTypesUseCase = getAllHomeCareServiceTypesUseCase;
            _deleteServiceUseCase = deleteServiceUseCase;
        }

        /// <summary>Creates the specified service request.</summary>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns>The home care service creation response.</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> Create(ServiceRequest serviceRequest)
        {
            try
            {
                ServiceDomain serviceDomain = ServiceFactory.ToDomain(serviceRequest);

                ServiceResponse serviceResponse =
                    ServiceFactory.ToResponse(await _upsertServiceUseCase.ExecuteAsync(serviceDomain)
                        .ConfigureAwait(false));

                if (serviceResponse == null)
                {
                    return NotFound();
                }

                //else if (!serviceResponse.Success) return BadRequest(serviceResponse.Message);
                return Ok(serviceResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified service identifier.</summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>The home care service creation response.</returns>
        [HttpGet("{serviceId}")]
        public async Task<ActionResult<ServiceResponse>> Get(int serviceId)
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

        /// <summary>Gets all.</summary>
        /// <returns>List of home care service response</returns>
        [HttpGet("getAll")]
        public async Task<ActionResult<IList<HomeCareServiceType>>> GetAll()
        {
            try
            {
                var result = await _getAllHomeCareServiceTypesUseCase.GetAllAsync().ConfigureAwait(false);

                if (result == null) return NotFound();

                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{serviceId}")]
        public async Task<ActionResult<bool>> Delete(int serviceId)
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
