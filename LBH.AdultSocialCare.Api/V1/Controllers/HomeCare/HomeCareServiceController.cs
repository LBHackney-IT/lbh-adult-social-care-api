using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [Authorize]
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
        /// <param name="homeCareServiceRequest">The service request.</param>
        /// <returns>The home care service creation response.</returns>
        [HttpPost]
        public async Task<ActionResult<HomeCareServiceResponse>> Create(HomeCareServiceRequest homeCareServiceRequest)
        {
            try
            {
                var homeCareServiceDomain = homeCareServiceRequest.ToDomain();
                var res = await _upsertServiceUseCase.ExecuteAsync(homeCareServiceDomain)
                    .ConfigureAwait(false);
                var homeCareServiceResponse = res?.ToResponse();

                if (homeCareServiceResponse == null)
                {
                    return NotFound();
                }

                //else if (!homeCareServiceResponse.Success) return BadRequest(homeCareServiceResponse.Message);
                return Ok(homeCareServiceResponse);
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
        public async Task<ActionResult<HomeCareServiceResponse>> Get(int serviceId)
        {
            try
            {
                var res = await _getServiceUseCase.GetAsync(serviceId).ConfigureAwait(false);
                return Ok(res?.ToResponse());
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
