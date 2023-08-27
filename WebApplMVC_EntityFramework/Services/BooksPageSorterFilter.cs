using Microsoft.EntityFrameworkCore;
using WebApplMVC_EntityFramework.Models;

namespace WebApplMVC_EntityFrameworkDZ.Services
{
    public class BooksPageSorterFilter
    {
        const string NameDesc = "name_desc";
        const string NameAsc = "name_asc";
        const string IzdDesc = "izd_desc";
        const string IzdAsc = "izd_asc";
        const string CategoryDesc = "catg_desc";
        const string CategoryAsc = "catg_asc";


        public async Task FilteringResult(string SearchString, BooksContext context)
        {
            var booksNews = from books in context.BooksNews
                            select books;


            if (!string.IsNullOrEmpty(SearchString) && await booksNews.AnyAsync())
            {
                booksNews = booksNews.Where(s => s.Name.Contains(SearchString)
                                       || s.Izd.Izd.ToString().Contains(SearchString)
                                       || s.Kategory.Category.ToString().Contains(SearchString));
            }
        }


        public void SortingResult(ref string sortOrder, IQueryable<BooksNew> books)
        {

            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = NameAsc;
            }
            else if (sortOrder.Equals(NameDesc))
            {
                books.OrderByDescending(b => b.Name);
            }
            else if (sortOrder.Equals(IzdAsc))
            {
                books.OrderBy(b => b.Izd.Izd);
            }
            else if (sortOrder.Equals(IzdDesc))
            {
                books.OrderByDescending(b => b.Izd.Izd);
            }
            else if (sortOrder.Equals(CategoryDesc))
            {
                books.OrderByDescending(b => b.Kategory.Category);
            }
            else if (sortOrder.Equals(CategoryAsc))
            {
                books.OrderBy(b => b.Kategory.Category);
            }
        }
    }
}
