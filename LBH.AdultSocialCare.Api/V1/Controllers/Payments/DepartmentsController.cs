using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Payments
{
    [Route("api/v1/departments")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DepartmentsController : ControllerBase
    {
        /// <summary>
        /// Gets payment departments.
        /// </summary>
        /// <param name="useCase">Use case to get departments.</param>
        /// <returns>List of payment departments</returns>
        [ProducesResponseType(typeof(IEnumerable<DepartmentFlatResponse>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentFlatResponse>>> GetPaymentDepartments([FromServices] IGetDepartmentUseCase useCase)
        {
            var res = await useCase.GetAll();
            return Ok(res);
        }
    }
}
