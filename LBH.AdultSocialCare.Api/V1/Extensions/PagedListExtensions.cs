using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Data.Extensions;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class PagedListExtensions
    {
        public static PagedResponse<TResponse> ToPagedResponse<T, TResponse>(this PagedList<T> pagedList, Func<IEnumerable<T>, IEnumerable<TResponse>> converter)
        {
            return new PagedResponse<TResponse>
            {
                PagingMetaData = pagedList.PagingMetaData,
                Data = converter.Invoke(pagedList)
            };
        }
    }
}
