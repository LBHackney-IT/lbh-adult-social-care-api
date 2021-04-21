using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCare
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCarePackageController : BaseController
    {
        private readonly IUpsertNursingCarePackageUseCase _upsertNursingCarePackageUseCase;
        private readonly IGetNursingCarePackageUseCase _getNursingCarePackageUseCase;
        private readonly IChangeStatusNursingCarePackageUseCase _changeStatusNursingCarePackageUseCase;
        private readonly IGetAllNursingCarePackageUseCase _getAllNursingCarePackageUseCase;
        private readonly IGetAllNursingCareHomeTypeUseCase _getAllNursingCareHomeTypeUseCase;
        private readonly IGetAllNursingCareTypeOfStayOptionUseCase _getAllNursingCareTypeOfStayOptionUseCase;

        public NursingCarePackageController(IUpsertNursingCarePackageUseCase upsertNursingCarePackageUseCase,
            IGetNursingCarePackageUseCase getNursingCarePackageUseCase,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase,
            IGetAllNursingCarePackageUseCase getAllNursingCarePackageUseCase,
            IGetAllNursingCareHomeTypeUseCase getAllNursingCareHomeTypeUseCase,
            IGetAllNursingCareTypeOfStayOptionUseCase getAllNursingCareTypeOfStayOptionUseCase
            )
        {
            _upsertNursingCarePackageUseCase = upsertNursingCarePackageUseCase;
            _getNursingCarePackageUseCase = getNursingCarePackageUseCase;
            _changeStatusNursingCarePackageUseCase = changeStatusNursingCarePackageUseCase;
            _getAllNursingCarePackageUseCase = getAllNursingCarePackageUseCase;
            _getAllNursingCareHomeTypeUseCase = getAllNursingCareHomeTypeUseCase;
            _getAllNursingCareTypeOfStayOptionUseCase = getAllNursingCareTypeOfStayOptionUseCase;
        }

        /// <summary>Creates the specified nursing care package request.</summary>
        /// <param name="nursingCarePackageRequest">The nursing care package request.</param>
        /// <returns>The nursing care package creation response.</returns>
        [ProducesResponseType(typeof(NursingCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<NursingCarePackageResponse>> Create(NursingCarePackageRequest nursingCarePackageRequest)
        {
            try
            {
                NursingCarePackageDomain nursingCarePackageDomain = NursingCarePackageFactory.ToDomain(nursingCarePackageRequest);
                var nursingCarePackageResponse = NursingCarePackageFactory.ToResponse(await _upsertNursingCarePackageUseCase.ExecuteAsync(nursingCarePackageDomain).ConfigureAwait(false));
                if (nursingCarePackageResponse == null) return NotFound();
                return Ok(nursingCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified nursing care package identifier.</summary>
        /// <param name="nursingCarePackageId">The nursing care package identifier.</param>
        /// <returns>The nursing care package response.</returns>
        [HttpGet]
        [Route("{nursingCarePackageId}")]
        public async Task<ActionResult<NursingCarePackageResponse>> Get(Guid nursingCarePackageId)
        {
            try
            {
                var nursingCarePackageResponse = NursingCarePackageFactory.ToResponse(await _getNursingCarePackageUseCase.GetAsync(nursingCarePackageId).ConfigureAwait(false));
                if (nursingCarePackageResponse == null) return NotFound();
                return Ok(nursingCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Change the nursing care package status.</summary>
        /// <param name="nursingCarePackageId"></param>
        /// <param name="statusId"></param>
        /// <returns>The nursing care package response model.</returns>
        [ProducesResponseType(typeof(NursingCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPut]
        [Route("{nursingCarePackageId}/changeStatus/{statusId}")]
        public async Task<ActionResult<NursingCarePackageResponse>> ChangeStatus(
            Guid nursingCarePackageId, int statusId)
        {
            try
            {
                NursingCarePackageResponse nursingCarePackageResponse =
                    NursingCarePackageFactory.ToResponse(await _changeStatusNursingCarePackageUseCase
                        .UpdateAsync(nursingCarePackageId, statusId)
                        .ConfigureAwait(false));
                if (nursingCarePackageResponse == null) return NotFound();
                return Ok(nursingCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Get all Nursing Care Packages</summary>
        /// <returns>The list of Nursing Care Package Response model</returns>
        [ProducesResponseType(typeof(IList<NursingCarePackageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<NursingCarePackageResponse>>> GetAll()
        {
            try
            {
                IList<NursingCarePackageResponse> result = NursingCarePackageFactory.ToResponse(await _getAllNursingCarePackageUseCase.GetAllAsync().ConfigureAwait(false));
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(IList<TypeOfNursingCareHomeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("type-of-nursing-care-home")]
        public async Task<ActionResult<IList<TypeOfNursingCareHomeResponse>>> TypeOfNursingCareHome()
        {
            try
            {
                IList<TypeOfNursingCareHomeResponse> result = NursingCarePackageFactory.ToResponse(await _getAllNursingCareHomeTypeUseCase.GetAllAsync().ConfigureAwait(false));
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(IList<NursingCareTypeOfStayOptionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("type-of-stay-option")]
        public async Task<ActionResult<IList<NursingCareTypeOfStayOptionResponse>>> TypeOfStayOption()
        {
            try
            {
                IList<NursingCareTypeOfStayOptionResponse> result = NursingCarePackageFactory.ToResponse(await _getAllNursingCareTypeOfStayOptionUseCase.GetAllAsync().ConfigureAwait(false));
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
