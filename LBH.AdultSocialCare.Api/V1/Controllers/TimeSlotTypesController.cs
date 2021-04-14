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
    [Route("api/v1/time-slot-types")]
    [Produces("application/json")]
    [ApiController]
    public class TimeSlotTypesController : BaseController
    {
        private readonly IUpsertTimeSlotTypesUseCase _upsertTimeSlotTypesUseCase;
        private readonly IGetTimeSlotTypesUseCase _getTimeSlotTypesUseCase;
        private readonly IGetAllTimeSlotTypesUseCase _getAllTimeSlotTypesUseCase;
        private readonly IDeleteTimeSlotTypesUseCase _deleteTimeSlotTypesUseCase;

        public TimeSlotTypesController(IUpsertTimeSlotTypesUseCase upsertTimeSlotTypesUseCase,
            IGetTimeSlotTypesUseCase getTimeSlotTypesUseCase,
            IGetAllTimeSlotTypesUseCase getAllTimeSlotTypesUseCase,
            IDeleteTimeSlotTypesUseCase deleteTimeSlotTypesUseCase)
        {
            _upsertTimeSlotTypesUseCase = upsertTimeSlotTypesUseCase;
            _getTimeSlotTypesUseCase = getTimeSlotTypesUseCase;
            _getAllTimeSlotTypesUseCase = getAllTimeSlotTypesUseCase;
            _deleteTimeSlotTypesUseCase = deleteTimeSlotTypesUseCase;
        }

        /// <summary>Creates the specified time slot type request.</summary>
        /// <param name="timeSlotTypeRequest">The time slot type request.</param>
        /// <returns>The created Time Slot Type Response model</returns>
        [HttpPost]
        public async Task<ActionResult<TimeSlotTypesResponse>> Create(TimeSlotTypeRequest timeSlotTypeRequest)
        {
            try
            {
                TimeSlotTypesDomain timeSlotTypesDomain = TimeSlotTypesFactory.ToDomain(timeSlotTypeRequest);
                TimeSlotTypesResponse timeSlotTypesResponse = TimeSlotTypesFactory.ToResponse(await _upsertTimeSlotTypesUseCase.ExecuteAsync(timeSlotTypesDomain).ConfigureAwait(false));
                if (timeSlotTypesResponse == null) return NotFound();
                //else if (!timeSlotTypesResponse.Success) return BadRequest(timeSlotTypesResponse.Message);
                return Ok(timeSlotTypesResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified time slot types identifier.</summary>
        /// <param name="timeSlotTypesId">The time slot types identifier.</param>
        /// <returns>The Time Slot Type Response model</returns>
        [HttpGet]
        [Route("{timeSlotTypesId}")]
        public async Task<ActionResult<TimeSlotTypesResponse>> Get(Guid timeSlotTypesId)
        {
            try
            {
                return TimeSlotTypesFactory.ToResponse(await _getTimeSlotTypesUseCase.GetAsync(timeSlotTypesId).ConfigureAwait(false));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets all.</summary>
        /// <returns>The List of Time Slot Type Response model</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<TimeSlotType>>> GetAll()
        {
            try
            {
                IList<TimeSlotType> result = await _getAllTimeSlotTypesUseCase.GetAllAsync().ConfigureAwait(false);
                if (result == null) return NotFound();
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{timeSlotTypesId}")]
        public async Task<ActionResult<bool>> Delete(Guid timeSlotTypesId)
        {
            try
            {
                return Ok(await _deleteTimeSlotTypesUseCase.DeleteAsync(timeSlotTypesId).ConfigureAwait(false));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
