using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplMVC_EntityFramework.Filters;
using WebApplMVC_EntityFramework.Models;
using WebApplMVC_EntityFramework.Services;
using WebApplMVC_EntityFrameworkDZ.Data;

namespace WebApplMVC_EntityFramework.Controllers
{
    [CustomExceptionFilter]
    public class BooksNewsController : Controller
    {
        private readonly IDatabaseHandlerRepository _databaseHandler;

        public BooksNewsController(IDatabaseHandlerRepository databaseHandler)
        {
            _databaseHandler = databaseHandler;
        }

        // GET: BooksNews
        public async Task<IActionResult> Index(string sortOrder,string SearchString,int? pageNumber)
        {
            return View(await PrepareData(sortOrder, SearchString, pageNumber)); ;
        }

        public async Task<IActionResult> Indexdata(string sortOrder,string SearchString,int? pageNumber)
        {

            return PartialView(await PrepareData(sortOrder, SearchString, pageNumber)); ;
        }

        private async Task<PaginatedList<BooksNew>> PrepareData(string sortOrder, string SearchString, 
            int? pageNumber)
        {
            if (sortOrder == null) {

               sortOrder = "name_asc";
            } 

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["IzdSortParam"] = sortOrder == "izd_asc" ? "izd_desc" : "izd_asc";
            ViewData["CategorySortParam"] = sortOrder == "catg_asc" ? "catg_desc" : "catg_asc";
            ViewData["CurrentFilter"] = SearchString;

            var booksNew = await _databaseHandler.GetBooksNewsList(sortOrder, SearchString);

            return await PaginatedList<BooksNew>.CreateAsync(booksNew, pageNumber ?? 1);
        }

        // GET: BooksNews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksNew = await _databaseHandler.GetDetailsBookNew(id);

            if (booksNew == null)
            {
                return NotFound();
            }

            return View(booksNew);
        }

        // GET: BooksNews/Create
        public async Task<IActionResult> Create()
        {
            var listFormats = await _databaseHandler.GetFormatsList();
            var listIzds = await _databaseHandler.GetIzdList();
            var listCategories = await _databaseHandler.GetCategoriesList();
            var listThemes = await _databaseHandler.GetThemesList();

            ViewData["FormatId"] = new SelectList(listFormats, "Id", "Format");
            ViewData["IzdId"] = new SelectList(listIzds, "Id", "Izd");
            ViewData["KategoryId"] = new SelectList(listCategories, "Id", "Category");
            ViewData["ThemesId"] = new SelectList(listThemes, "Id", "Themes");
            return View();
        }

        // POST: BooksNews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BooksNew booksNew)
        {
            if (ModelState.IsValid)
            {
                await _databaseHandler.CreateBookNew(booksNew);
                return RedirectToAction(nameof(Index));
            }
            var listFormats = await _databaseHandler.GetFormatsList();
            var listIzds = await _databaseHandler.GetIzdList();
            var listCategories = await _databaseHandler.GetCategoriesList();
            var listThemes = await _databaseHandler.GetThemesList();

            ViewData["FormatId"] = new SelectList(listFormats, "Id", "Format", booksNew.FormatId);
            ViewData["IzdId"] = new SelectList(listIzds, "Id", "Izd", booksNew.IzdId);
            ViewData["KategoryId"] = new SelectList(listCategories, "Id", "Category", booksNew.KategoryId);
            ViewData["ThemesId"] = new SelectList(listThemes, "Id", "Themes", booksNew.ThemesId);

            return View(booksNew);
        }

        // GET: BooksNews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksNew = await _databaseHandler.GetBookById(id);
            if (booksNew == null)
            {
                return NotFound();
            }
            var listFormats = await _databaseHandler.GetFormatsList();
            var listIzds = await _databaseHandler.GetIzdList();
            var listCategories = await _databaseHandler.GetCategoriesList();
            var listThemes = await _databaseHandler.GetThemesList();

            ViewData["FormatId"] = new SelectList(listFormats, "Id", "Format", booksNew.FormatId);
            ViewData["IzdId"] = new SelectList(listIzds, "Id", "Izd", booksNew.IzdId);
            ViewData["KategoryId"] = new SelectList(listCategories, "Id", "Category", booksNew.KategoryId);
            ViewData["ThemesId"] = new SelectList(listThemes, "Id", "Themes", booksNew.ThemesId);

            return View(booksNew);
        }

        // POST: BooksNews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BooksNew booksNew)
        {
            if (id != booksNew.N)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _databaseHandler.EditBook(id, booksNew);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _databaseHandler.BooksNewExists(booksNew.N))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var listFormats = await _databaseHandler.GetFormatsList();
            var listIzds = await _databaseHandler.GetIzdList();
            var listCategories = await _databaseHandler.GetCategoriesList();
            var listThemes = await _databaseHandler.GetThemesList();


            ViewData["FormatId"] = new SelectList(listFormats, "Id", "Format", booksNew.FormatId);
            ViewData["IzdId"] = new SelectList(listIzds, "Id", "Izd", booksNew.IzdId);
            ViewData["KategoryId"] = new SelectList(listCategories, "Id", "Category", booksNew.KategoryId);
            ViewData["ThemesId"] = new SelectList(listThemes, "Id", "Themes", booksNew.ThemesId);
            return View(booksNew);
        }

        // GET: BooksNews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksNew = await _databaseHandler.GetDetailsBookNew(id);
            if (booksNew == null)
            {
                return NotFound();
            }

            return View(booksNew);
        }

        // POST: BooksNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _databaseHandler.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> VerifyId(int? id)
        {
            if (await _databaseHandler.BooksNewExists(id))
            {
                ///* return Json($"Book with id {id} is already exist"*/);
                return Json(false);
            }

            return Json(true);
        }
    }
}
