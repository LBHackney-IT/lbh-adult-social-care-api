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
        private readonly IRestClient _restClient;

        public FileStorage(HttpClient httpClient, IRestClient restClient)
        {
            _restClient = restClient;
            restClient.Init(httpClient);
        }

        public async Task<DocumentResponse> SaveFileAsync(IFormFile carePlanFile)
        {
            var fileContent = ConvertCarePlan(carePlanFile);
            if (fileContent == null)
                return new DocumentResponse();

            var documentClaimRequest = new DocumentClaimRequest()
            {
                ServiceAreaCreatedBy = "hasc-finance-api",
                UserCreatedBy = "furkan",
                ApiCreatedBy = "furkan",
                ValidUntil = DateTime.Now.AddDays(+365),
                RetentionExpiresAt = DateTime.Now.AddDays(+365)
            };

            var claimResponse = await _restClient
                .PostAsync<DocumentClaimResponse>("claims", documentClaimRequest, "Failed to create document claim");

            var documentUploadRequest = new DocumentUploadRequest() {base64Document = fileContent};

            await _restClient
                .PostAsync<string>($"documents/{claimResponse.Document.Id}", documentUploadRequest, "Failed to create document");

            return new DocumentResponse { FileId = claimResponse.Document.Id };
        }

        public async Task<string> GetFile(Guid documentId)
        {
            return await _restClient
                .GetAsync<string>($"documents/{documentId}", "Failed to retrieve document");
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
