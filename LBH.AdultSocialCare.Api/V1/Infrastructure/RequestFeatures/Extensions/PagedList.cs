using HttpServices.Models.Features;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions
{
    public class PagedList<T> : List<T>
    {
        public PagingMetaData PagingMetaData { get; set; }

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            PagingMetaData = new PagingMetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int) Math.Ceiling(count / (double) pageSize)
            };
            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int count, int pageNumber, int pageSize)
        {
            var items = source.ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
