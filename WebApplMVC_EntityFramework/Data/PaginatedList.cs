﻿using Microsoft.EntityFrameworkCore;

namespace WebApplMVC_EntityFrameworkDZ.Data
{
    public class PaginatedList<T> :List<T>
    {
        public int PageIndex { get;private set; }
        public int TotalPages { get; private set; }
        private int _pageSize = 20;

        public PaginatedList(List<T> items, int count, int pageIndex) { 

            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count/(double)_pageSize);

            AddRange(items);
        }

        public bool HaspreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;  

        
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex-1)*pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex);
        }
    }
}