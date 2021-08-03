using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.ApprovedPackagesBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.BrokeredPackagesBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.StageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.BrokeredPackagesUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.BrokeredPackagesBoundary.Request;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/brokered-packages")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class BrokeredPackagesController : ControllerBase
    {
        private readonly IGetBrokeredPackagesUseCase _getBrokeredPackagesUseCase;
        private readonly IGetAllPackageUseCase _getAllPackageUseCase;
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;
        private readonly IGetAllHomeCareStageUseCase _getAllHomeCareStageUseCase;
        private readonly IAssignToUserUseCase _assignToUserUseCase;

        public BrokeredPackagesController(IGetBrokeredPackagesUseCase getBrokeredPackagesUseCase,
            IGetAllPackageUseCase getAllPackageUseCase,
            IGetAllUsersUseCase getAllUsersUseCase,
            IGetAllHomeCareStageUseCase getAllHomeCareStageUseCase,
            IAssignToUserUseCase assignToUserUseCase)
        {
            _getBrokeredPackagesUseCase = getBrokeredPackagesUseCase;
            _getAllPackageUseCase = getAllPackageUseCase;
            _getAllUsersUseCase = getAllUsersUseCase;
            _getAllHomeCareStageUseCase = getAllHomeCareStageUseCase;
            _assignToUserUseCase = assignToUserUseCase;
        }

        [HttpGet("new")]
        [ProducesResponseType(typeof(PagedBrokeredPackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedBrokeredPackagesResponse>> GetNewPackages([FromQuery] BrokeredPackagesParameters parameters)
        {
            var result = await _getBrokeredPackagesUseCase.GetBrokeredPackages(parameters, ApprovalHistoryConstants.PackageApprovedId).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [HttpGet("in-progress")]
        [ProducesResponseType(typeof(PagedBrokeredPackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedBrokeredPackagesResponse>> GetInProgressPackages([FromQuery] BrokeredPackagesParameters parameters)
        {
            var result = await _getBrokeredPackagesUseCase.GetBrokeredPackages(parameters, ApprovalHistoryConstants.ApprovedForBrokerageId).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [HttpGet("done")]
        [ProducesResponseType(typeof(PagedBrokeredPackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedBrokeredPackagesResponse>> GetDonePackages([FromQuery] BrokeredPackagesParameters parameters)
        {
            var result = await _getBrokeredPackagesUseCase.GetBrokeredPackages(parameters, ApprovalHistoryConstants.PackageBrokeredId).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [HttpGet("package-types")]
        [ProducesResponseType(typeof(IEnumerable<PackageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PackageResponse>> GetPackageTypes()
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
            var result = await _getAllUsersUseCase.GetUsers(UserRoleConstants.SocialWorker).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("stages")]
        [ProducesResponseType(typeof(IEnumerable<StageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<StageResponse>>> GetStages()
        {
            var result = await _getAllHomeCareStageUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPut("assign")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> AssignPackageToUser([FromBody] AssignUserRequest assignUserRequest)
        {
            var result = await _assignToUserUseCase.AssignToUser(assignUserRequest.PackageId, assignUserRequest.UserId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
