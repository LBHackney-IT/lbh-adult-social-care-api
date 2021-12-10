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
        private readonly IDocumentGetClient _documentGetClient;


        public FileStorage(IDocumentClaimClient documentClaimClient, IDocumentGetClient documentGetClient)
        {
            _documentClaimClient = documentClaimClient;
            _documentGetClient = documentGetClient;
        }

        public async Task<DocumentResponse> SaveFileAsync(string fileContent, string fileName)
        {
            if (fileContent == null)
                return new DocumentResponse();

            var documentClaimRequest = new DocumentClaimRequest()
            {
                ServiceAreaCreatedBy = "hasc-finance-api",
                UserCreatedBy = "hasc-finance-api",
                ApiCreatedBy = "hasc-finance-api",
                ValidUntil = DateTime.Now.AddYears(+10),
                RetentionExpiresAt = DateTime.Now.AddYears(+10),
                Base64Document = fileContent
            };

            var claimResponse = await _documentClaimClient.CreateClaimAndDocument(documentClaimRequest);

            return new DocumentResponse { FileId = new Guid(claimResponse.Document.Id), FileName = fileName };
        }

        public async Task<string> GetFile(Guid documentId)
        {
            return await _documentGetClient.GetDocument(documentId);
        }
    }
}
