using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{

    [Route("api/v1/homeCarePackageSlots")]
    [Produces("application/json")]
    [ApiController]
    public class HomeCarePackageSlotsController : BaseController
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
        public async Task<ActionResult<HomeCarePackageSlotsResponseList>> Create(
            HomeCarePackageSlotsRequestList homeCarePackageSlotsRequestList)
        {
            try
            {
                HomeCarePackageSlotListDomain homeCarePackageSlotListDomain =
                    HomeCarePackageSlotsFactory.ToDomain(homeCarePackageSlotsRequestList);

                HomeCarePackageSlotsResponseList homeCarePackageSlotsResponse =
                    HomeCarePackageSlotsFactory.ToResponse(await _upsertHomeCarePackageSlotsUseCase
                        .ExecuteAsync(homeCarePackageSlotListDomain)
                        .ConfigureAwait(false));

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
