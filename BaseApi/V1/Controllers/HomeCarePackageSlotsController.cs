using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Controllers
{
    [Route("api/v1/homeCarePackageSlots")]
    [Produces("application/json")]
    [ApiController]
    public class HomeCarePackageSlotsController : Controller
    {
        private readonly IUpsertHomeCarePackageSlotsUseCase _upsertHomeCarePackageSlotsUseCase;
        private readonly IDeleteHomeCarePackageSlotsUseCase _deleteHomeCarePackageSlotsUseCase;


        public HomeCarePackageSlotsController(IUpsertHomeCarePackageSlotsUseCase upsertHomeCarePackageSlotsUseCase,
            IDeleteHomeCarePackageSlotsUseCase deleteHomeCarePackageSlotsUseCase)
        {
            _upsertHomeCarePackageSlotsUseCase = upsertHomeCarePackageSlotsUseCase;
            _deleteHomeCarePackageSlotsUseCase = deleteHomeCarePackageSlotsUseCase;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<HomeCarePackageSlotsResponseList>> Create(HomeCarePackageSlotsResponseList homeCarePackageSlotsResponse)
        {
            try
            {
                HomeCarePackageSlotsDomain homeCarePackageSlotsDomain = HomeCarePackageSlotsFactory.ToDomain(homeCarePackageSlotsResponse);
                homeCarePackageSlotsResponse = HomeCarePackageSlotsFactory.ToResponse(await _upsertHomeCarePackageSlotsUseCase.ExecuteAsync(homeCarePackageSlotsDomain).ConfigureAwait(false));
                if (homeCarePackageSlotsResponse == null) return NotFound();
                return Ok(homeCarePackageSlotsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
