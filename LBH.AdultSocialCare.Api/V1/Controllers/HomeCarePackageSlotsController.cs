using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/home-care-package-slots")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
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

        /// <summary>Creates the specified home care package slots request list.</summary>
        /// <param name="homeCarePackageSlotsRequestList">The home care package slots request list.</param>
        /// <returns>The created Home Care Package Slots Response model</returns>
        [ProducesResponseType(typeof(HomeCarePackageSlotsResponseList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<HomeCarePackageSlotsResponseList>> Create(HomeCarePackageSlotsRequestList homeCarePackageSlotsRequestList)
        {
            try
            {
                HomeCarePackageSlotsDomain homeCarePackageSlotsDomain = HomeCarePackageSlotsFactory.ToDomain(homeCarePackageSlotsRequestList);
                HomeCarePackageSlotsResponseList homeCarePackageSlotsResponse = HomeCarePackageSlotsFactory.ToResponse(await _upsertHomeCarePackageSlotsUseCase.ExecuteAsync(homeCarePackageSlotsDomain).ConfigureAwait(false));
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
