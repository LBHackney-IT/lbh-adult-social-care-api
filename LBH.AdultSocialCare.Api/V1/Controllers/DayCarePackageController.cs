using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.DataTransferObjects.DayCarePackageDtos;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/day-care-packages")]
    [Produces("application/json")]
    [ApiController]
    public class DayCarePackageController : ControllerBase
    {
        private readonly ICreateDayCarePackageUseCase _createdDayCarePackageUseCase;

        public DayCarePackageController(ICreateDayCarePackageUseCase createdDayCarePackageUseCase)
        {
            _createdDayCarePackageUseCase = createdDayCarePackageUseCase;
        }

        [HttpPost]
        // [Route("new")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateDayCarePackage([FromBody] DayCarePackageForCreationDto dayCarePackageForCreation)
        {
            try
            {
                if (dayCarePackageForCreation == null)
                {
                    return UnprocessableEntity("Object for creation cannot be null.");
                }

                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }

                Guid result = await _createdDayCarePackageUseCase.Execute(dayCarePackageForCreation.ToDb()).ConfigureAwait(false);
                return Ok(result);
            }
            catch (NotSupportedException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
