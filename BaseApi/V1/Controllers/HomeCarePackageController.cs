using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.Controllers
{
    [Route("api/v1/homeCarePackage")]
    [Produces("application/json")]
    [ApiController]
    public class HomeCarePackageController : Controller
    {
        private readonly IUpsertHomeCarePackageUseCase _upsertHomeCarePackageUseCase;
        private readonly IGetAllHomeCarePackageUseCase _getAllHomeCarePackageUseCase;
        private readonly IUpdateHomeCarePackageUseCase _updateHomeCarePackageUseCase;
        

        public HomeCarePackageController(IUpsertHomeCarePackageUseCase upsertHomeCarePackageUseCase,
            IGetAllHomeCarePackageUseCase getAllHomeCarePackageUseCase,
            IUpdateHomeCarePackageUseCase updateHomeCarePackageUseCase)
        {
            _upsertHomeCarePackageUseCase = upsertHomeCarePackageUseCase;
            _getAllHomeCarePackageUseCase = getAllHomeCarePackageUseCase;
            _updateHomeCarePackageUseCase = updateHomeCarePackageUseCase;
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<HomeCarePackageResponse>> Update(HomeCarePackageResponse homeCarePackageResponse)
        {
            try
            {
                HomeCarePackageDomain homeCarePackageDomain = HomeCarePackageFactory.ToDomain(homeCarePackageResponse);
                homeCarePackageResponse = HomeCarePackageFactory.ToResponse(await _updateHomeCarePackageUseCase.UpdateAsync(homeCarePackageDomain).ConfigureAwait(false));
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
        public async Task<ActionResult<HomeCarePackageResponse>> Create(HomeCarePackageResponse homeCarePackageResponse)
        {
            try
            {
                HomeCarePackageDomain homeCarePackageDomain = HomeCarePackageFactory.ToDomain(homeCarePackageResponse);
                homeCarePackageResponse = HomeCarePackageFactory.ToResponse(await _upsertHomeCarePackageUseCase.ExecuteAsync(homeCarePackageDomain).ConfigureAwait(false));
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
