using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/homeCarePackage")]
    [Produces("application/json")]
    [ApiController]
    public class HomeCarePackageController : BaseController
    {
        private readonly IUpsertHomeCarePackageUseCase _upsertHomeCarePackageUseCase;
        private readonly IChangeStatusHomeCarePackageUseCase _updateHomeCarePackageUseCase;


        public HomeCarePackageController(IUpsertHomeCarePackageUseCase upsertHomeCarePackageUseCase,
            IChangeStatusHomeCarePackageUseCase updateHomeCarePackageUseCase)
        {
            _upsertHomeCarePackageUseCase = upsertHomeCarePackageUseCase;
            _updateHomeCarePackageUseCase = updateHomeCarePackageUseCase;
        }

        [HttpPut]
        public async Task<ActionResult<HomeCarePackageResponse>> ChangeStatus(HomeCarePackageRequest homeCarePackageRequest)
        {
            try
            {
                HomeCarePackageDomain homeCarePackageDomain = HomeCarePackageFactory.ToDomain(homeCarePackageRequest);
                var homeCarePackageResponse = HomeCarePackageFactory.ToResponse(await _updateHomeCarePackageUseCase.UpdateAsync(homeCarePackageDomain).ConfigureAwait(false));
                if (homeCarePackageResponse == null) return NotFound();
                return Ok(homeCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<HomeCarePackageResponse>> Create(HomeCarePackageRequest homeCarePackageRequest)
        {
            try
            {
                HomeCarePackageDomain homeCarePackageDomain = HomeCarePackageFactory.ToDomain(homeCarePackageRequest);
                var homeCarePackageResponse = HomeCarePackageFactory.ToResponse(await _upsertHomeCarePackageUseCase.ExecuteAsync(homeCarePackageDomain).ConfigureAwait(false));
                if (homeCarePackageResponse == null) return NotFound();
                return Ok(homeCarePackageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
