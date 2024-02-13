using LibraryManagerMvc.Data.Entities;
using LibraryManagerMvc.Data.Enums;
using LibraryManagerMvc.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace LibraryManagerMvc.Web.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: BooksController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            var newBook = new Book(); // In future, define a ViewModel for this purpose
            return View(newBook);
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var newBook = new Book()
                {
                    Id = new Guid(),
                    Title = collection["Title"],
                    Author = collection["Author"],
                    Category = Enum.Parse<Category>(collection["Category"]),
                    YearPublished = int.Parse(collection["YearPublished"]),
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                };
                _bookRepository.CreateBook(newBook);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
