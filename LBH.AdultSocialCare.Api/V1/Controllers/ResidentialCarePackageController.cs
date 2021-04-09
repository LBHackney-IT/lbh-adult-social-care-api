using Microsoft.AspNetCore.Mvc;

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
