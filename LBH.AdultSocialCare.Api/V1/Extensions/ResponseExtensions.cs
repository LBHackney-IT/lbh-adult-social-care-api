using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class ResponseExtensions
    {
        /// <summary>
        /// Adds a header with pagination data (page number, size etc.) to a response
        /// </summary>
        public static void AddPaginationHeaders(this HttpResponse response, PagingMetaData pagingMetaData)
        {
            response.Headers.Add(
                ResponseHeadersConstants.XPagination,
                JsonConvert.SerializeObject(pagingMetaData));
        }
    }
}
