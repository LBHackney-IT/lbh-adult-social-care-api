using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Controllers.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HomeCarePackageSlotsController : BaseController
    {
        private readonly IUpsertHomeCarePackageSlotsUseCase _upsertHomeCarePackageSlotsUseCase;

        // TODO remove
        private readonly DatabaseContext _context;

        public HomeCarePackageSlotsController(IUpsertHomeCarePackageSlotsUseCase upsertHomeCarePackageSlotsUseCase,
            DatabaseContext context)
        {
            _upsertHomeCarePackageSlotsUseCase = upsertHomeCarePackageSlotsUseCase;
            _context = context;
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
                var homeCarePackageSlotListDomain = homeCarePackageSlotsRequestList.ToDomain();
                var res = await _upsertHomeCarePackageSlotsUseCase.ExecuteAsync(homeCarePackageSlotListDomain)
                    .ConfigureAwait(false);
                var homeCarePackageSlotsResponse = res?.ToResponse();

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

        // TODO remove
        [HttpGet]
        public async Task<IEnumerable<HomeCarePackageSlots>> GetAsync(Guid packageId)
        {
            return await _context.HomeCarePackageSlots.Include(item => item.TimeSlotShift)
                .Where(item => item.HomeCarePackageId == packageId)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
