using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/residentialCarePackage")]
    [Produces("application/json")]
    [ApiController]
    public class ResidentialCarePackageController : BaseController
    {
        private readonly IUpsertResidentialCarePackageUseCase _upsertResidentialCarePackageUseCase;
        private readonly IGetResidentialCarePackageUseCase _getResidentialCarePackageUseCase;


        public ResidentialCarePackageController(IUpsertResidentialCarePackageUseCase upsertResidentialCarePackageUseCase,
            IGetResidentialCarePackageUseCase getResidentialCarePackageUseCase)
        {
            _upsertResidentialCarePackageUseCase = upsertResidentialCarePackageUseCase;
            _getResidentialCarePackageUseCase = getResidentialCarePackageUseCase;
        }

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

    }
}
