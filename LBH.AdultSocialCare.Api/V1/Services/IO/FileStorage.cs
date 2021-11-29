using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HttpServices.Helpers;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LBH.AdultSocialCare.Api.V1.Services.IO
{
    public class FileStorage : IFileStorage
    {
        private readonly IDocumentClaimClient _documentClaimClient;
        private readonly IDocumentPostClient _documentPostClient;
        private readonly IDocumentGetClient _documentGetClient;
        private readonly ILogger<FileStorage> _logger;


        public FileStorage(IDocumentClaimClient documentClaimClient, IDocumentPostClient documentPostClient,
            IDocumentGetClient documentGetClient, ILogger<FileStorage> logger)
        {
            _documentClaimClient = documentClaimClient;
            _documentPostClient = documentPostClient;
            _documentGetClient = documentGetClient;
            _logger = logger;
        }

        public async Task<DocumentResponse> SaveFileAsync(string fileContent, string fileName)
        {
            //var fileContent = ConvertCarePlan(carePlanFile);

            // log to check file content
            _logger.LogCritical(fileContent);
            _logger.LogCritical(fileName);

            if (fileContent == null)
                return new DocumentResponse();

            var documentClaimRequest = new DocumentClaimRequest()
            {
                ServiceAreaCreatedBy = "hasc-finance-api",
                UserCreatedBy = "hasc-finance-api",
                ApiCreatedBy = "hasc-finance-api",
                ValidUntil = DateTime.Now.AddYears(+10),
                RetentionExpiresAt = DateTime.Now.AddYears(+10)
            };

            var claimResponse = await _documentClaimClient.CreateClaim(documentClaimRequest);

            var documentUploadRequest = new DocumentUploadRequest() { base64Document = fileContent };

            await _documentPostClient.CreateDocument(new Guid(claimResponse.Document.Id), documentUploadRequest);

            return new DocumentResponse { FileId = new Guid(claimResponse.Document.Id), FileName = fileName };
        }

        public async Task<string> GetFile(Guid documentId)
        {
            return await _documentGetClient.GetDocument(documentId);
        }

        private static string ConvertCarePlan(IFormFile carePlanFile)
        {
            if (carePlanFile != null)
            {
                using (var stream = new MemoryStream())
                {
                    carePlanFile.CopyTo(stream);

                    var bytes = stream.ToArray();
                    return $"data:{carePlanFile.ContentType};base64,{Convert.ToBase64String(bytes)}";
                }
            }

            return null;
        }
    }
}
