using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplMVC_EntityFramework.Models;

namespace WebApplMVC_EntityFramework.Services
{
    public interface IDatabaseHandlerRepository
    {
        Task<List<BooksNew>> GetBooksNewsList();
        Task<BooksNew> GetDetailsBookNew(int? id);
        Task<List<SprFormat>> GetFormatsList();
        Task<List<SprIzd>> GetIzdList();
        Task<List<SprKategory>> GetCategoriesList();
        Task<List<SprTheme>> GetThemesList();
        Task CreateBookNew(BooksNew book);
        Task<BooksNew> GetBookById(int? id);
        Task EditBook(int ?id, BooksNew booksNew);
        Task<bool> BooksNewExists(int ?id);
        Task DeleteConfirmed(int? id);
    }
}