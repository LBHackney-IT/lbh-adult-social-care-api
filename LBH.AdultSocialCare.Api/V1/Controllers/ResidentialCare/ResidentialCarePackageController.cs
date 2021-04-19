using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCare
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCarePackageController : BaseController
    {
        private readonly IUpsertResidentialCarePackageUseCase _upsertResidentialCarePackageUseCase;
        private readonly IGetResidentialCarePackageUseCase _getResidentialCarePackageUseCase;
        private readonly IChangeStatusResidentialCarePackageUseCase _changeStatusResidentialCarePackageUseCase;
        private readonly IGetAllResidentialCarePackageUseCase _getAllResidentialCarePackageUseCase;


        public ResidentialCarePackageController(IUpsertResidentialCarePackageUseCase upsertResidentialCarePackageUseCase,
            IGetResidentialCarePackageUseCase getResidentialCarePackageUseCase,
            IChangeStatusResidentialCarePackageUseCase changeStatusResidentialCarePackageUseCase,
            IGetAllResidentialCarePackageUseCase getAllResidentialCarePackageUseCase)
        {
            _upsertResidentialCarePackageUseCase = upsertResidentialCarePackageUseCase;
            _getResidentialCarePackageUseCase = getResidentialCarePackageUseCase;
            _changeStatusResidentialCarePackageUseCase = changeStatusResidentialCarePackageUseCase;
            _getAllResidentialCarePackageUseCase = getAllResidentialCarePackageUseCase;
        }

        /// <summary>Creates the specified residential care package request.</summary>
        /// <param name="residentialCarePackageRequest">The residential care package request.</param>
        /// <returns>The residential care package created response.</returns>
        [ProducesResponseType(typeof(ResidentialCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<ResidentialCarePackageResponse>> Create(ResidentialCarePackageRequest residentialCarePackageRequest)
        {
            try
            {
                ResidentialCarePackageDomain residentialCarePackageDomain = ResidentialCarePackageFactory.ToDomain(residentialCarePackageRequest);
                var residentialCarePackageResponse = ResidentialCarePackageFactory.ToResponse(await _upsertResidentialCarePackageUseCase.ExecuteAsync(residentialCarePackageDomain).ConfigureAwait(false));
                if (residentialCarePackageResponse == null) return NotFound();
                return Ok(residentialCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified residential care package identifier.</summary>
        /// <param name="residentialCarePackageId">The residential care package identifier.</param>
        /// <returns>The residential care package response.</returns>
        [ProducesResponseType(typeof(ResidentialCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{residentialCarePackageId}")]
        public async Task<ActionResult<ResidentialCarePackageResponse>> Get(Guid residentialCarePackageId)
        {
            try
            {
                var residentialCarePackageResponse = ResidentialCarePackageFactory.ToResponse(await _getResidentialCarePackageUseCase.GetAsync(residentialCarePackageId).ConfigureAwait(false));
                if (residentialCarePackageResponse == null) return NotFound();
                return Ok(residentialCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Change the residential care package status.</summary>
        /// <param name="residentialCarePackageId"></param>
        /// <param name="statusId"></param>
        /// <returns>The residential care package response model.</returns>
        [ProducesResponseType(typeof(ResidentialCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPut]
        [Route("{residentialCarePackageId}/changeStatus/{statusId}")]
        public async Task<ActionResult<ResidentialCarePackageResponse>> ChangeStatus(
            Guid residentialCarePackageId, int statusId)
        {
            try
            {
                ResidentialCarePackageResponse residentialCarePackageResponse =
                    ResidentialCarePackageFactory.ToResponse(await _changeStatusResidentialCarePackageUseCase
                        .UpdateAsync(residentialCarePackageId, statusId)
                        .ConfigureAwait(false));
                if (residentialCarePackageResponse == null) return NotFound();
                return Ok(residentialCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Get all Residential Care Packages</summary>
        /// <returns>The list of Residential Care Package Response model</returns>
        [ProducesResponseType(typeof(IList<ResidentialCarePackageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<ResidentialCarePackageResponse>>> GetAll()
        {
            try
            {
                IList<ResidentialCarePackageResponse> result = ResidentialCarePackageFactory.ToResponse(await _getAllResidentialCarePackageUseCase.
                    GetAllAsync().ConfigureAwait(false));
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
