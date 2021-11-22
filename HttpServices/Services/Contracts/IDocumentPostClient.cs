using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HttpServices.Models.Requests;

namespace HttpServices.Services.Contracts
{
    public interface IDocumentPostClient    
    {
        Task<string> CreateDocument(Guid documentId, DocumentUploadRequest request);
    }
}
