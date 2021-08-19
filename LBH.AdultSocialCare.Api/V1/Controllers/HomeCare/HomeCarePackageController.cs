using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.HomeCare;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCarePackageController : BaseController
    {
        private readonly IUpsertHomeCarePackageUseCase _upsertHomeCarePackageUseCase;
        private readonly IChangeStatusHomeCarePackageUseCase _changeStatusHomeCarePackageUseCase;
        private readonly IGetAllHomeCarePackageUseCase _getAllHomeCarePackageUseCase;
        private readonly IGetAllHomeCareApprovalHistoryUseCase _getAllHomeCareApprovalHistoryUseCases;

        // TODO remove
        private readonly DatabaseContext _context;

        public HomeCarePackageController(IUpsertHomeCarePackageUseCase upsertHomeCarePackageUseCase,
            IChangeStatusHomeCarePackageUseCase changeStatusHomeCarePackageUseCase,
            IGetAllHomeCarePackageUseCase getAllHomeCarePackageUseCase,
            IGetAllHomeCareApprovalHistoryUseCase getAllHomeCareApprovalHistoryUseCases, DatabaseContext context)
        {
            _upsertHomeCarePackageUseCase = upsertHomeCarePackageUseCase;
            _changeStatusHomeCarePackageUseCase = changeStatusHomeCarePackageUseCase;
            _getAllHomeCarePackageUseCase = getAllHomeCarePackageUseCase;
            _getAllHomeCareApprovalHistoryUseCases = getAllHomeCareApprovalHistoryUseCases;
            _context = context;
        }

        // TODO remove
        [HttpGet("{id}")]
        public async Task<HomeCarePackage> GetAsync(Guid id)
        {
            return await _context.HomeCarePackage.FirstOrDefaultAsync(item => item.Id == id).ConfigureAwait(false);
        }

        /// <summary>Change the home care package status.</summary>
        /// <param name="homeCarePackageId"></param>
        /// <param name="statusId"></param>
        /// <returns>The home care package response model.</returns>
        [ProducesResponseType(typeof(HomeCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPut]
        [Route("{homeCarePackageId}/changeStatus/{statusId}")]
        public async Task<ActionResult<HomeCarePackageResponse>> ChangeStatus(Guid homeCarePackageId, int statusId)
        {
            try
            {
                var res = await _changeStatusHomeCarePackageUseCase.UpdateAsync(homeCarePackageId, statusId)
                    .ConfigureAwait(false);
                var homeCarePackageResponse = res.ToResponse();

                if (homeCarePackageResponse == null) return NotFound();

                return Ok(homeCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates the specified home care package request.
        /// </summary>
        /// <param name="homeCarePackageRequest">The home care package request.</param>
        /// <returns>The home care package creation response.</returns>
        [ProducesResponseType(typeof(HomeCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<HomeCarePackageResponse>> Create(
            [FromBody] HomeCarePackageRequest homeCarePackageRequest)
        {
            try
            {
                // TODO remove
                var anyClient = await _context.Clients.FirstOrDefaultAsync().ConfigureAwait(false);

                if (anyClient == null)
                {
                    await _context.Clients.AddAsync(new Client
                    {
                        HackneyId = 4817,
                        FirstName = "Furkan",
                        LastName = "Kayar",
                        DateOfBirth = DateTime.UtcNow,
                        AddressLine1 = "Westminister Abbey",
                        PostCode = "W11"
                    })
                        .ConfigureAwait(false);
                    anyClient = await _context.Clients.FirstAsync().ConfigureAwait(false);
                }

                homeCarePackageRequest.ClientId = anyClient.Id;
                var homeCarePackageDomain = homeCarePackageRequest.ToDomain();

                var res = await _upsertHomeCarePackageUseCase.ExecuteAsync(homeCarePackageDomain).ConfigureAwait(false);

                var homeCarePackageResponse = res.ToResponse();

                if (homeCarePackageResponse == null)
                {
                    return NotFound();
                }

                //Change status of package
                await _changeStatusHomeCarePackageUseCase
                    .UpdateAsync(homeCarePackageResponse.Id, ApprovalHistoryConstants.NewPackageId)
                    .ConfigureAwait(false);

                await _changeStatusHomeCarePackageUseCase
                    .UpdateAsync(homeCarePackageResponse.Id, ApprovalHistoryConstants.SubmittedForApprovalId)
                    .ConfigureAwait(false);

                return Ok(homeCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception exc)
            {
                // TODO remove
                Debugger.Break();

                return BadRequest(exc.Message);
            }
        }

        /// <summary>Get all Home Care Packages</summary>
        /// <returns>The list of Home Care Package Response model</returns>
        [ProducesResponseType(typeof(IList<HomeCarePackageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<HomeCarePackage>>> GetAll()
        {
            try
            {
                var result = await _getAllHomeCarePackageUseCase.GetAllAsync().ConfigureAwait(false);

                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(IEnumerable<HomeCareApprovalHistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("approval-history/{homeCarePackageId}")]
        public async Task<ActionResult<IEnumerable<HomeCareApprovalHistoryResponse>>> GetApprovalHistoryList(
            Guid homeCarePackageId)
        {
            var result = await _getAllHomeCareApprovalHistoryUseCases.GetAllAsync(homeCarePackageId)
                .ConfigureAwait(false);

            return Ok(result);
        }
    }
}
