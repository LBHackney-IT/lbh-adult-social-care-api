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
    [Route("api/v1/time-slot-shifts")]
    [Produces("application/json")]
    [ApiController]
    public class TimeSlotShiftsController : BaseController
    {
        private readonly IUpsertTimeSlotShiftsUseCase _upsertTimeSlotShiftsUseCase;
        private readonly IGetTimeSlotShiftsUseCase _getTimeSlotShiftsUseCase;
        private readonly IGetAllTimeSlotShiftsUseCase _getAllTimeSlotShiftsUseCase;
        private readonly IDeleteTimeSlotShiftsUseCase _deleteTimeSlotShiftsUseCase;

        public TimeSlotShiftsController(IUpsertTimeSlotShiftsUseCase upsertTimeSlotShiftsUseCase,
            IGetTimeSlotShiftsUseCase getTimeSlotShiftsUseCase,
            IGetAllTimeSlotShiftsUseCase getAllTimeSlotShiftsUseCase,
            IDeleteTimeSlotShiftsUseCase deleteTimeSlotShiftsUseCase)
        {
            _upsertTimeSlotShiftsUseCase = upsertTimeSlotShiftsUseCase;
            _getTimeSlotShiftsUseCase = getTimeSlotShiftsUseCase;
            _getAllTimeSlotShiftsUseCase = getAllTimeSlotShiftsUseCase;
            _deleteTimeSlotShiftsUseCase = deleteTimeSlotShiftsUseCase;
        }

        /// <summary>Creates the specified time slot shifts request.</summary>
        /// <param name="timeSlotShiftsRequest">The time slot shifts request.</param>
        /// <returns>The created Time Slot Shifts Response model</returns>
        [HttpPost]
        public async Task<ActionResult<TimeSlotShiftsResponse>> Create(TimeSlotShiftsRequest timeSlotShiftsRequest)
        {
            try
            {
                TimeSlotShiftsDomain timeSlotShiftsDomain = TimeSlotShiftsFactory.ToDomain(timeSlotShiftsRequest);
                TimeSlotShiftsResponse timeSlotShiftsResponse = TimeSlotShiftsFactory.ToResponse(await _upsertTimeSlotShiftsUseCase.ExecuteAsync(timeSlotShiftsDomain).ConfigureAwait(false));
                if (timeSlotShiftsResponse == null) return NotFound();
                //else if (!timeSlotShiftsResponse.Success) return BadRequest(timeSlotShiftsResponse.Message);
                return Ok(timeSlotShiftsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified time slot shifts identifier.</summary>
        /// <param name="timeSlotShiftsId">The time slot shifts identifier.</param>
        /// <returns>The Time Slot Shifts Response model</returns>
        [HttpGet]
        [Route("{timeSlotShiftsId}")]
        public async Task<ActionResult<TimeSlotShiftsResponse>> Get(Guid timeSlotShiftsId)
        {
            try
            {
                return Ok(TimeSlotShiftsFactory.ToResponse(await _getTimeSlotShiftsUseCase.GetAsync(timeSlotShiftsId).ConfigureAwait(false)));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets all.</summary>
        /// <returns>The List of Time Slot Shifts</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<TimeSlotShifts>>> GetAll()
        {
            try
            {
                IList<TimeSlotShifts> result = await _getAllTimeSlotShiftsUseCase.GetAllAsync().ConfigureAwait(false);
                if (result == null) return NotFound();
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{timeSlotShiftsId}")]
        public async Task<ActionResult<bool>> Delete(Guid timeSlotShiftsId)
        {
            try
            {
                return Ok(await _deleteTimeSlotShiftsUseCase.DeleteAsync(timeSlotShiftsId).ConfigureAwait(false));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
