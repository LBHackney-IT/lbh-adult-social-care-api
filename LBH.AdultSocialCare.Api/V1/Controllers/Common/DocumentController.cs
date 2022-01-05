using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/documents")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DocumentController : ControllerBase
    {
        private readonly IFileStorage _fileStorage;

        public DocumentController(IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }

        /// <summary>Retrieves the document in base64 representation</summary>
        /// <param name="documentId">The document identifier.</param>
        /// <returns>A base64 format of the document</returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [HttpGet("{documentId}")]
        public async Task<ActionResult<string>> GetDocument(Guid documentId)
        {
            var result = await _fileStorage.GetFile(documentId);
            return Ok(result);
        }
    }
}
