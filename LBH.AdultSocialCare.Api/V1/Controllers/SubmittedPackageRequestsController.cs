using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.SubmittedPackageRequestsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Common.Exceptions.Models;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces;
using Newtonsoft.Json;


namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/submitted-package-requests")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class SubmittedPackageRequestsController : ControllerBase
    {
        private readonly IGetSubmittedPackageRequestsUseCase _getSubmittedPackageRequestsUseCase;

        public SubmittedPackageRequestsController(IGetSubmittedPackageRequestsUseCase getSubmittedPackageRequestsUseCase)
        {
            _getSubmittedPackageRequestsUseCase = getSubmittedPackageRequestsUseCase;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedSubmittedPackageRequestsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedSubmittedPackageRequestsResponse>> GetSubmittedPackageRequests([FromQuery] SubmittedPackageRequestParameters parameters)
        {
            var result = await _getSubmittedPackageRequestsUseCase.GetSubmittedPackageRequests(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }
    }
}