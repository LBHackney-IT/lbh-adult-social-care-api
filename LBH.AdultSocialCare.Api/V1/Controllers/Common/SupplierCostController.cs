using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/suppliers/{supplierId}/costs")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class SupplierCostController : Controller
    {
        private readonly ICreateSupplierCostUseCase _createSupplierCostUseCase;
        private readonly IGetSupplierCostUseCase _getSupplierCostUseCase;

        public SupplierCostController(ICreateSupplierCostUseCase createSupplierCostUseCase,
            IGetSupplierCostUseCase getSupplierCostUseCase)
        {
            _createSupplierCostUseCase = createSupplierCostUseCase;
            _getSupplierCostUseCase = getSupplierCostUseCase;
        }

        [ProducesResponseType(typeof(HomeCareSupplierCostResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<HomeCareSupplierCostResponse>> CreateSupplierCost(
            IEnumerable<SupplierCostCreationRequest> supplierCostCreationRequest)
        {
            if (supplierCostCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var supplierForCreationDomain = supplierCostCreationRequest.ToDomain();
            var supplierResponse =
                await _createSupplierCostUseCase.ExecuteAsync(supplierForCreationDomain).ConfigureAwait(false);
            return Ok(supplierResponse);
        }

        /// <summary>Gets the specified supplier costs.</summary>
        /// <param name="supplierId">The supplier identifier.</param>
        /// <returns>The supplier costs response.</returns>
        [ProducesResponseType(typeof(IEnumerable<HomeCareSupplierCostResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeCareSupplierCostResponse>>> GetSupplierCost(int supplierId)
        {
            var result = await _getSupplierCostUseCase.GetAsync(supplierId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}