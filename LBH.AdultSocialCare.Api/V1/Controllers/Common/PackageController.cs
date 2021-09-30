using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/package")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class PackageController : BaseController
    {
        private readonly IUpsertPackageUseCase _upsertPackageUseCase;
        private readonly IGetPackageTypeUseCase _getPackageTypeUseCase;
        private readonly IDeletePackageUseCase _deletePackageUseCase;

        public PackageController(IUpsertPackageUseCase upsertPackageUseCase, IGetPackageTypeUseCase getPackageTypeUseCase, IDeletePackageUseCase deletePackageUseCase)
        {
            _upsertPackageUseCase = upsertPackageUseCase;
            _getPackageTypeUseCase = getPackageTypeUseCase;
            _deletePackageUseCase = deletePackageUseCase;
        }

        /// <summary>Creates the specified package request.</summary>
        /// <param name="packageRequest">The package request.</param>
        /// <returns>The created package response.</returns>
        [HttpPost]
        public async Task<ActionResult<PackageResponse>> Create(PackageRequest packageRequest)
        {
            try
            {
                var packageDomain = packageRequest.ToDomain();
                var res = await _upsertPackageUseCase.ExecuteAsync(packageDomain).ConfigureAwait(false);
                var packageResponse = res?.ToResponse();
                if (packageResponse == null) return NotFound();
                return Ok(packageResponse);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the specified package identifier.</summary>
        /// <param name="packageTypeId">The package identifier.</param>
        /// <returns>The package response.</returns>
        [HttpGet]
        [Route("{packageTypeId}")]
        public async Task<ActionResult<PackageResponse>> Get(int packageTypeId)
        {
            var res = await _getPackageTypeUseCase.GetSingleAsync(packageTypeId).EnsureExistsAsync();
            return Ok(res.ToResponse());
        }

        /// <summary>Gets all.</summary>
        /// <returns>List of packages</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IList<Package>>> GetAll()
        {
            try
            {
                IList<Package> result = await _getPackageTypeUseCase.GetAllAsync().ConfigureAwait(false);
                if (result == null) return NotFound();
                return Ok(result.ToList());
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{packageId}")]
        public async Task<ActionResult<bool>> Delete(int packageId)
        {
            try
            {
                bool result = await _deletePackageUseCase.DeleteAsync(packageId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
