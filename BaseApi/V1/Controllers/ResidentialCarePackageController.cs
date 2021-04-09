using BaseApi.V1.Boundary.Request;
using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Controllers
{
    [Route("api/v1/residentialCarePackage")]
    [Produces("application/json")]
    [ApiController]
    public class ResidentialCarePackageController : BaseController
    {
        private readonly IUpsertResidentialCarePackageUseCase _upsertResidentialCarePackageUseCase;

        public ResidentialCarePackageController(IUpsertResidentialCarePackageUseCase upsertResidentialCarePackageUseCase)
        {
            _upsertResidentialCarePackageUseCase = upsertResidentialCarePackageUseCase;
        }

        [HttpPost]
        [Route("create")]
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
    }
}
