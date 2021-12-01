using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/funded-nursing-care")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class FundedNursingCarePriceController : BaseController
    {
        private readonly IGetFundedNursingCarePriceUseCase _getFundedNursingCarePriceUseCase;

        public FundedNursingCarePriceController(
            IGetFundedNursingCarePriceUseCase getFundedNursingCarePriceUseCase)
        {
            _getFundedNursingCarePriceUseCase = getFundedNursingCarePriceUseCase;
        }

        /// <summary>
        /// Returns FNC price active at current date
        /// </summary>
        /// <returns>Returns FNC price active at current date or 404 Not Found if no price is defined.</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
