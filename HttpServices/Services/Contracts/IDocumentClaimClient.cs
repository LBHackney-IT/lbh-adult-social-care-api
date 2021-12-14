using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;

namespace HttpServices.Services.Contracts
{
    public interface IDocumentClaimClient
    {
        Task<DocumentClaimResponse> CreateClaimAndDocument(DocumentClaimRequest request);
    }
}
