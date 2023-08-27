using Microsoft.EntityFrameworkCore;
using WebApplMVC_EntityFramework.Models;


namespace WebApplMVC_EntityFrameworkDZ.Services
{
    public class BooksPageSorterFilter : IBooksPageSorterFilter
    {
        const string NameDesc ="name_desc";
        const string NameAsc = "name_asc";
        const string IzdDesc = "izd_desc";
        const string IzdAsc = "izd_asc";
        const string CategoryDesc = "catg_desc";
        const string CategoryAsc = "catg_asc";


        public async Task<IQueryable<BooksNew>> FilteringResult(string sortOrder, string SearchString, IQueryable<BooksNew> books)
        {
            if (!string.IsNullOrEmpty(SearchString) && await books.AnyAsync())
            {
                books =books.Where(s => s.Name.Contains(SearchString));
            }
             books = SortingResult(sortOrder, books);

            return books;
        }


        private IQueryable<BooksNew> SortingResult(string sortOrder, IQueryable<BooksNew> books) => sortOrder switch
        {
            NameAsc => books.OrderBy(b => b.Name),
            NameDesc => books.OrderByDescending(b => b.Name),
            IzdAsc=> books.OrderBy(b => b.Izd.Izd),
            IzdDesc=> books.OrderByDescending(b => b.Izd.Izd),
            CategoryDesc=> books.OrderByDescending(b => b.Kategory.Category),
            CategoryAsc=> books.OrderBy(b => b.Kategory.Category)
        };
    }
}
