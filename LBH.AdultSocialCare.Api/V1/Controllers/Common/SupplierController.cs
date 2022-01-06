using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/suppliers")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class SupplierController : BaseController
    {
        private readonly ICreateSupplierUseCase _createSupplierUseCase;
        private readonly IGetAllSupplierUseCase _getAllSupplierUseCase;

        public SupplierController(ICreateSupplierUseCase createSupplierUseCase,
            IGetAllSupplierUseCase getAllSupplierUseCase)
        {
            _createSupplierUseCase = createSupplierUseCase;
            _getAllSupplierUseCase = getAllSupplierUseCase;
        }

        [ProducesResponseType(typeof(SupplierResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<SupplierResponse>> CreateSupplier(
            SupplierCreationRequest supplierCreationRequest)
        {
            if (supplierCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var supplierForCreationDomain = supplierCreationRequest.ToDomain();
            var supplierResponse =
                await _createSupplierUseCase.ExecuteAsync(supplierForCreationDomain).ConfigureAwait(false);
            return Ok(supplierResponse);
        }

        [ProducesResponseType(typeof(IEnumerable<SupplierResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        public async Task<ActionResult<PagedResponse<SupplierResponse>>> GetSupplierList([FromQuery] RequestParameters parameters, string supplierName)
        {
            var result = await _getAllSupplierUseCase.GetAllAsync(parameters, supplierName).ConfigureAwait(false);

            Response.AddPaginationHeaders(result.PagingMetaData);

            return Ok(result);
        }

        [ProducesResponseType(typeof(SupplierResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        [HttpGet("{supplierId}")]
        public async Task<ActionResult<SupplierResponse>> GetSingleSupplier(int supplierId)
        {
            var result = await _getAllSupplierUseCase.GetSingleAsync(supplierId);

            return Ok(result);
        }
    }
}
