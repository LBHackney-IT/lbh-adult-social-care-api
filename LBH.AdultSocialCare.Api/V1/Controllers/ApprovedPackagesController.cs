using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.ApprovedPackagesBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Extensions;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/approved-packages")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ApprovedPackagesController : ControllerBase
    {
        private readonly IGetApprovedPackagesUseCase _getApprovedPackagesUseCase;
        private readonly IGetAllPackageUseCase _getAllPackageUseCase;
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;

        public ApprovedPackagesController(IGetApprovedPackagesUseCase getApprovedPackagesUseCase,
            IGetAllPackageUseCase getAllPackageUseCase,
            IGetAllUsersUseCase getAllUsersUseCase)
        {
            _getApprovedPackagesUseCase = getApprovedPackagesUseCase;
            _getAllPackageUseCase = getAllPackageUseCase;
            _getAllUsersUseCase = getAllUsersUseCase;
        }

        [HttpGet("new")]
        [ProducesResponseType(typeof(PagedApprovedPackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedApprovedPackagesResponse>> GetNewPackages([FromQuery] ApprovedPackagesParameters parameters)
        {
            var result = await _getApprovedPackagesUseCase.GetApprovedPackages(parameters, ApprovalHistoryConstants.SubmittedForApprovalId).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [HttpGet("clarification-need")]
        [ProducesResponseType(typeof(PagedApprovedPackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedApprovedPackagesResponse>> GetClarificationNeededPackages([FromQuery] ApprovedPackagesParameters parameters)
        {
            var result = await _getApprovedPackagesUseCase.GetApprovedPackages(parameters, ApprovalHistoryConstants.RequestMoreInformationId).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [HttpGet("awaiting-brokerage")]
        [ProducesResponseType(typeof(PagedApprovedPackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedApprovedPackagesResponse>> GetAwaitingPackages([FromQuery] ApprovedPackagesParameters parameters)
        {
            var result = await _getApprovedPackagesUseCase.GetApprovedPackages(parameters, ApprovalHistoryConstants.PackageApprovedId).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [HttpGet("review-commercial")]
        [ProducesResponseType(typeof(PagedApprovedPackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedApprovedPackagesResponse>> GetReviewCommercialPackages([FromQuery] ApprovedPackagesParameters parameters)
        {
            var result = await _getApprovedPackagesUseCase.GetApprovedPackages(parameters, ApprovalHistoryConstants.ApprovedForBrokerageId).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [HttpGet("completed")]
        [ProducesResponseType(typeof(PagedApprovedPackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedApprovedPackagesResponse>> GetCompletedApprovedPackages([FromQuery] ApprovedPackagesParameters parameters)
        {
            var result = await _getApprovedPackagesUseCase.GetApprovedPackages(parameters, ApprovalHistoryConstants.PackageBrokeredId).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [HttpGet("package-types")]
        [ProducesResponseType(typeof(IEnumerable<PackageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<PackageResponse>>> GetPackageTypes()
        {
            var result = await _getAllPackageUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("social-workers")]
        [ProducesResponseType(typeof(IEnumerable<UsersMinimalResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<UsersMinimalResponse>>> GetSocialWorkers()
        {
            var result = await _getAllUsersUseCase.GetUsers(RolesEnum.SocialWorker.GetId()).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("approvers")]
        [ProducesResponseType(typeof(IEnumerable<UsersMinimalResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<UsersMinimalResponse>>> GetApprovers()
        {
            var result = await _getAllUsersUseCase.GetUsers(RolesEnum.Approver.GetId()).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
