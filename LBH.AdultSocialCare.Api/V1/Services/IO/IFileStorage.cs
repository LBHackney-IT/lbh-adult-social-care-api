using System;
using System.Threading.Tasks;
using HttpServices.Models.Responses;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Services.IO
{
    public interface IFileStorage
    {
        Task<DocumentResponse> SaveFileAsync(string fileContent, string fileName);
        Task<string> GetFile(Guid documentId);
    }
}
