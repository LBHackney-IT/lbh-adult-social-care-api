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

namespace LBH.AdultSocialCare.Api.V1.Services.IO
{
    public class FileStorage : IFileStorage
    {
        private readonly IDocumentClaimClient _documentClaimClient;
        private readonly IDocumentPostClient _documentPostClient;
        private readonly IDocumentGetClient _documentGetClient;

        public FileStorage(IDocumentClaimClient documentClaimClient, IDocumentPostClient documentPostClient, IDocumentGetClient documentGetClient)
        {
            _documentClaimClient = documentClaimClient;
            _documentPostClient = documentPostClient;
            _documentGetClient = documentGetClient;
        }

        public async Task<DocumentResponse> SaveFileAsync(IFormFile carePlanFile)
        {
            var fileContent = ConvertCarePlan(carePlanFile);
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

            return new DocumentResponse { FileId = new Guid(claimResponse.Document.Id)};
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
                    return $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
                }
            }

            return null;
        }
    }
}
