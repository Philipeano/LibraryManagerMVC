using LibraryManagerMvc.Data.Entities;
using LibraryManagerMvc.Data.Enums;
using LibraryManagerMvc.Data.Repositories;
using LibraryManagerMvc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace LibraryManagerMvc.Web.Controllers
{
    // [Route("books/")]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: BooksController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        // GET: BooksController/List
        [Route("books/view-all")]
        public ActionResult List(string? searchTerm)
        {
            var booklistViewModel = new BookListViewModel();

            var booksToDisplay = _bookRepository.GetAllBooks();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                booklistViewModel.Books = booksToDisplay;
                booklistViewModel.SearchTerm = string.Empty;
                return View("ViewAll", booklistViewModel);
            }
            else
            {
                var filteredBooks = booksToDisplay.Where(b => b.Title.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                                                           || b.Author.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
                booklistViewModel.Books = filteredBooks;
                booklistViewModel.SearchTerm = searchTerm;
                return View("ViewAll", booklistViewModel);
            }
        }

        // GET: BooksController/Details/some-guid-value
        [Route("books/details/{id}")]
        public ActionResult Details(Guid id)
        {
            var bookToDisplay = _bookRepository.GetBook(id);

            if (bookToDisplay == null)
            {
                return NotFound();
            }

            return View(bookToDisplay);
        }

        [Authorize(Roles = "Admin")]
        // GET: BooksController/Create
        [Route("books/create")]
        public ActionResult Create()
        {
            var newBook = new Book(); // In future, define a ViewModel for this purpose
            return View(newBook);
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("books/create")]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Book postedBook)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var newBook = new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = postedBook.Title,
                    Author = postedBook.Author,
                    Category = postedBook.Category,
                    YearPublished = postedBook.YearPublished,
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

        // GET: BooksController/Edit/some-guid-value
        [Authorize(Roles = "Admin")]
        [Route("books/edit/{id}")]
        public ActionResult Edit(Guid id)
        {
            var bookToUpdate = _bookRepository.GetBook(id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            return View(bookToUpdate);
        }

        [HttpPost, Route("books/edit/{id}"), ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id, Book postedBook)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (id != postedBook.Id)
                {
                    return BadRequest();
                }

                postedBook.Updated = DateTime.Now;
                _bookRepository.UpdateBook(postedBook);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/some-guid-value
        [Authorize(Roles = "Admin")]
        [Route("books/delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            var bookToDelete = _bookRepository.GetBook(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }
            return View(bookToDelete);
        }

        // POST: BooksController/Delete/some-guid-value
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("books/delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult ConfirmDelete(Guid id)
        {
            try
            {
                var bookToDelete = _bookRepository.GetBook(id);
                if (bookToDelete == null)
                {
                    return NotFound();
                }

                _bookRepository.DeleteBook(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
