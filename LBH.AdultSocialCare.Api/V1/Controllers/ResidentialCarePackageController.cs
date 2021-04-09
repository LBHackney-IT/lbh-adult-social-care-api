using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    public class ResidentialCarePackageController : Controller
    {
        //[HttpPost]
        //[Route("create")]
        //public async Task<ActionResult<ResidentialCarePackageResponse>> Create(ResidentialCarePackageRequest residentialCarePackageRequest)
        //{
        //    try
        //    {
        //        HomeCarePackageDomain homeCarePackageDomain = HomeCarePackageFactory.ToDomain(residentialCarePackageRequest);
        //        var homeCarePackageResponse = HomeCarePackageFactory.ToResponse(await _upsertHomeCarePackageUseCase.ExecuteAsync(homeCarePackageDomain).ConfigureAwait(false));
        //        if (homeCarePackageResponse == null) return NotFound();
        //        return Ok(homeCarePackageResponse);
        //    }
        //    catch (FormatException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
