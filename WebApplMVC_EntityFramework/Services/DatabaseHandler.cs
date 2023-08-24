﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplMVC_EntityFramework.Models;

namespace WebApplMVC_EntityFramework.Services
{
    public class DatabaseHandler : IDatabaseHandlerRepository
    {
        private readonly BooksContext _context;
        public DatabaseHandler(BooksContext context)
        {
            _context = context;
        }

        public async Task<List<BooksNew>> GetBooksNewsList()
        {
            try
            {
                var booksContext = _context.BooksNews.Include(b => b.Format).
               Include(b => b.Izd).Include(b => b.Kategory).Include(b => b.Themes);

                return await booksContext.ToListAsync();
            }
            catch(SqlException ex)
            {
                throw new Exception($"Error retrieving data from table BooksNews:\n {ex.Message}");
            }
        }


        public async Task<BooksNew>GetDetailsBookNew(int? id)
        {
            try
            {
                var booksNew = await _context.BooksNews
                .Include(b => b.Format)
                .Include(b => b.Izd)
                .Include(b => b.Kategory)
                .Include(b => b.Themes)
                .FirstOrDefaultAsync(m => m.N == id);

                return booksNew;
            }
            catch(SqlException ex)
            {
                throw new Exception($"Error retrieving record by id from table BooksNews:  \n {ex.Message}");
            }
        }


        public async Task<List<SprFormat>> GetFormatsList()
        {
            try
            {
                return await _context.SprFormats.ToListAsync();
            }
            catch(SqlException ex)
            {
                throw new Exception($"Error retrieving record from table SprFormats:  \n {ex.Message}");
            }
        }


        public async Task<List<SprIzd>> GetIzdList()
        {
            try
            {
                return await _context.SprIzds.ToListAsync();
            }
            catch(SqlException ex)
            {
                throw new Exception($"Error retrieving record from table SprIzds:  \n {ex.Message}");
            }
        }


        public async Task<List<SprKategory>> GetCategoriesList()
        {
            try
            {
                return await _context.SprKategories.ToListAsync();
            }
            catch(SqlException ex)
            {
                throw new Exception($"Error retrieving record from table SprKategories: \n{ex.Message}");
            }
        }


        public async Task<List<SprTheme>> GetThemesList()
        {
            try
            {
                return await _context.SprThemes.ToListAsync();
            }
            catch(SqlException ex)
            {
                throw new Exception($"Error retrieving record from table SprThemes: \n{ex.Message}");
            }
        }


        public async Task CreateBookNew(BooksNew book)
        {
            if (book!=null)
            {
                try
                {
                    await _context.AddAsync(book);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException ex)
                {
                    throw new Exception($"Error adding record: \n{ex.Message}");
                }
            }
        }


        public async Task<BooksNew> GetBookById(int? id)
        {
            try
            {
                var booksNew = await _context.BooksNews.FindAsync(id);

                return booksNew;
            }
            catch(SqlException ex)
            {
                throw new Exception($"Error trying to retrieve record by id:  \n {ex.Message}");
            }
        }


        public async Task EditBook(int ?id, BooksNew booksNew)
        {
            try
            {
                _context.Update(booksNew);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                throw new Exception($"Error trying to edit record: \n {ex.Message}");
            }
        }


        public async Task<bool> BooksNewExists(int? id)
        {
            try
            {
                return await _context.BooksNews?.AnyAsync(e => e.N == id);
            }
            catch(SqlException ex)
            {
                throw new Exception($"Error trying to check for recording: \n {ex.Message}");
            }
        }


        public async Task DeleteConfirmed(int ?id)
        {
            try
            {
                var booksNew = await _context.BooksNews.FindAsync(id);
                if (booksNew != null)
                {
                    _context.BooksNews.Remove(booksNew);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error trying to delete record:  \n {ex.Message}");
            }
        }
    }
}