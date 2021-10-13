using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Controllers.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCare
{
    [Route("api/v1/funded-nursing-care")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class PackageCostClaimersController : BaseController
    {
        private readonly IGetFundedNursingCarePriceUseCase _getFundedNursingCarePriceUseCase;

        public PackageCostClaimersController(
            IGetFundedNursingCarePriceUseCase getFundedNursingCarePriceUseCase)
        {
            _getFundedNursingCarePriceUseCase = getFundedNursingCarePriceUseCase;
        }

        /// <summary>
        /// Returns FNC price active at current date
        /// </summary>
        /// <returns>Returns FNC price active at current date or 404 Not Found if no price is defined.</returns>
        [ProducesResponseType(typeof(IEnumerable<FundedNursingCareCollectorResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<FundedNursingCareCollectorResponse>), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet("price")]
        public async Task<decimal> GetActiveFundedNursingCarePrice()
        {
            return await _getFundedNursingCarePriceUseCase
                .GetActiveFundedNursingCarePriceAsync()
                .ConfigureAwait(false);
        }
    }
}
