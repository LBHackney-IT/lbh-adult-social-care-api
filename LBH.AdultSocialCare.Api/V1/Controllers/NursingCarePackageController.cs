using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/nursing-care-package")]
    [Produces("application/json")]
    [ApiController]
    public class NursingCarePackageController : BaseController
    {
        private readonly IUpsertNursingCarePackageUseCase _upsertNursingCarePackageUseCase;
        private readonly IGetNursingCarePackageUseCase _getNursingCarePackageUseCase;

        public NursingCarePackageController(IUpsertNursingCarePackageUseCase upsertNursingCarePackageUseCase,
            IGetNursingCarePackageUseCase getNursingCarePackageUseCase)
        {
            _upsertNursingCarePackageUseCase = upsertNursingCarePackageUseCase;
            _getNursingCarePackageUseCase = getNursingCarePackageUseCase;
        }

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

    }
}
