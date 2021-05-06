using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApproveBrokeredBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCareApproveBrokered
{
    [Route("api/v1/home-care-approve-brokered")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCareApproveBrokeredController : BaseController
    {
        private readonly IGetHomeCareApproveBrokeredUseCase _getHomeCareApproveBrokeredUseCase;

        public HomeCareApproveBrokeredController(IGetHomeCareApproveBrokeredUseCase getHomeCareApproveBrokeredUseCase)
        {
            _getHomeCareApproveBrokeredUseCase = getHomeCareApproveBrokeredUseCase;
        }

        /// <summary>Gets the specified home care approve package brokered identifier.</summary>
        /// <param name="homeCarePackageId">The home care package identifier.</param>
        /// <returns>The home care approve brokered response.</returns>
        [HttpGet]
        [Route("{homeCarePackageId}")]
        public async Task<ActionResult<HomeCareApproveBrokeredResponse>> GetHomeCareBrokerage(Guid homeCarePackageId)
        {
            var homeCareApprovePackageResponse = await _getHomeCareApproveBrokeredUseCase.Execute(homeCarePackageId).ConfigureAwait(false);
            return Ok(homeCareApprovePackageResponse);
        }
    }
}
