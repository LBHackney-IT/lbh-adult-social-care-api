using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Controllers
{
    [Route("api/v1/package")]
    [Produces("application/json")]
    [ApiController]
    public class PackageController : BaseController
    {
        private readonly IUpsertPackageUseCase _upsertPackageUseCase;
        private readonly IGetPackageUseCase _getPackageUseCase;
        private readonly IGetAllPackageUseCase _getAllPackageUseCase;
        private readonly IDeletePackageUseCase _deletePackageUseCase;

        public PackageController(IUpsertPackageUseCase upsertPackageUseCase, IGetPackageUseCase getPackageUseCase, IGetAllPackageUseCase getAllPackageUseCase, IDeletePackageUseCase deletePackageUseCase)
        {
            _upsertPackageUseCase = upsertPackageUseCase;
            _getPackageUseCase = getPackageUseCase;
            _getAllPackageUseCase = getAllPackageUseCase;
            _deletePackageUseCase = deletePackageUseCase;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<PackageResponse>> Create(PackageResponse packageResponse)
        {
            try
            {
                PackageDomain packageDomain = PackageFactory.ToDomain(packageResponse);
                packageResponse = PackageFactory.ToResponse(await _upsertPackageUseCase.ExecuteAsync(packageDomain).ConfigureAwait(false));
                if (packageResponse == null) return NotFound();
                else if (!packageResponse.Success) return BadRequest(packageResponse.Message);
                return Ok(packageResponse);
            }
            catch (FormatException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{packageId}")]
        public async Task<ActionResult<PackageResponse>> Get(Guid packageId)
        {
            try
            {
                var packageResponse = PackageFactory.ToResponse(await _getPackageUseCase.GetAsync(packageId).ConfigureAwait(false));
                if (packageResponse == null) return NotFound();
                return Ok(packageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<Package>>> GetAll()
        {
            try
            {
                var result = await _getAllPackageUseCase.GetAllAsync().ConfigureAwait(false);
                if (result == null) return NotFound();
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{packageId}")]
        public async Task<ActionResult<bool>> Delete(Guid packageId)
        {
            try
            {
                var result = await _deletePackageUseCase.DeleteAsync(packageId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
