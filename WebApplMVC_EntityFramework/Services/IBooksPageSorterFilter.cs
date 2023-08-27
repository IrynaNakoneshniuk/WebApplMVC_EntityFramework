using WebApplMVC_EntityFramework.Models;

namespace WebApplMVC_EntityFrameworkDZ.Services
{
    public interface IBooksPageSorterFilter
    {
        Task<IQueryable<BooksNew>> FilteringResult(string sortOrder, string SearchString, IQueryable<BooksNew> books);
    }
}