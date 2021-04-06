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
    [Route("api/v1/timeSlotShifts")]
    [Produces("application/json")]
    [ApiController]
    public class TimeSlotShiftsController : Controller
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

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<TimeSlotShiftsResponse>> Create(TimeSlotShiftsResponse timeSlotShiftsResponse)
        {
            try
            {
                TimeSlotShiftsDomain timeSlotShiftsDomain = TimeSlotShiftsFactory.ToDomain(timeSlotShiftsResponse);
                timeSlotShiftsResponse = TimeSlotShiftsFactory.ToResponse(await _upsertTimeSlotShiftsUseCase.ExecuteAsync(timeSlotShiftsDomain).ConfigureAwait(false));
                if (timeSlotShiftsResponse == null) return NotFound();
                else if (!timeSlotShiftsResponse.Success) return BadRequest(timeSlotShiftsResponse.Message);
                return Ok(timeSlotShiftsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{timeSlotShiftsId}")]
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

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<TimeSlotShifts>>> GetAll()
        {
            try
            {
                var result = await _getAllTimeSlotShiftsUseCase.GetAllAsync().ConfigureAwait(false);
                if (result == null) return NotFound();
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{timeSlotTypesId}")]
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
