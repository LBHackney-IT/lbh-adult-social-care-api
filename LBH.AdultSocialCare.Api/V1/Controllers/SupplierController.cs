using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using Newtonsoft.Json;

namespace LBH.AdultSocialCare.Api.V1.Controllers
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
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
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
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<PagedResponse<SupplierResponse>>> GetSupplierList([FromQuery] RequestParameters parameters)
        {
            var result = await _getAllSupplierUseCase.GetAllAsync(parameters).ConfigureAwait(false);

            Response.AddPaginationHeaders(result.PagingMetaData);

            return Ok(result);
        }
    }
}
