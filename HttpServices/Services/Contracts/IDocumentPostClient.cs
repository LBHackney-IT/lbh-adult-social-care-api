using HttpServices.Models.Requests;
using System;
using System.Threading.Tasks;

namespace HttpServices.Services.Contracts
{
    public interface IDocumentPostClient
    {
        Task<string> CreateDocument(Guid documentId, DocumentUploadRequest request);
    }
}
