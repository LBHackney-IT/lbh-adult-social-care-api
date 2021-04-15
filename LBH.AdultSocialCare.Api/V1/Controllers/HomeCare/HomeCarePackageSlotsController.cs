using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.HomeCare;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HomeCarePackageSlotsController : BaseController
    {

        private readonly IUpsertHomeCarePackageSlotsUseCase _upsertHomeCarePackageSlotsUseCase;

        public HomeCarePackageSlotsController(IUpsertHomeCarePackageSlotsUseCase upsertHomeCarePackageSlotsUseCase)
        {
            _upsertHomeCarePackageSlotsUseCase = upsertHomeCarePackageSlotsUseCase;
        }

        /// <summary>
        /// Creates the specified home care package slots.
        /// </summary>
        /// <param name="homeCarePackageSlotsRequestList">The home care package slots request list.</param>
        /// <returns>A home care package slots response list.</returns>
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

                if (homeCarePackageSlotsResponse == null)
                {
                    return NotFound();
                }

                return Ok(homeCarePackageSlotsResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
