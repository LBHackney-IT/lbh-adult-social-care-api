using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpServices.Services.Contracts
{
    public interface IDocumentGetClient
    {
        Task<string> GetDocument(Guid documentId);
    }
}
