using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBillBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierBillUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/supplier-bill")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class SupplierBillController : BaseController
    {
        private readonly IGetSupplierBillUseCase _getSupplierBillUseCase;

        public SupplierBillController(IGetSupplierBillUseCase getSupplierBillUseCase)
        {
            _getSupplierBillUseCase = getSupplierBillUseCase;
        }

        /// <summary>Gets the supplier bill details</summary>
        /// <param name="packageId">The package identifier.</param>
        /// <returns>supplier bill package details</returns>
        /// <response code="200">supplier bill package details</response>
        /// <response code="404">If the package is not found</response>
        [HttpGet("{packageId}")]
        [ProducesResponseType(typeof(SupplierBillResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SupplierBillResponse>> GetSupplierBill(Guid packageId)
        {
            var supplierBill = await _getSupplierBillUseCase.GetSupplierBill(packageId).ConfigureAwait(false);
            return Ok(supplierBill);
        }
    }
}
