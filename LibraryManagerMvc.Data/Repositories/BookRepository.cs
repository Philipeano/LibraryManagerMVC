using LibraryManagerMvc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerMvc.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LibraryManagerMvcContext _context;

        public BookRepository(LibraryManagerMvcContext context)
        {
            _context = context;
        }

        public void CreateBook(Book newBook)
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        public void DeleteBook(Guid bookId)
        {
            var bookToDelete = _context.Books.Find(bookId);

            // TODO: Check that the book actually exists, and handle null (not found) case

            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBook(Guid bookId)
        {
            // TODO: Check that the book actually exists, and handle null (not found) case
            return _context.Books.Find(bookId);
        }

        public void UpdateBook(Book book)
        {
            if (book != null)
            {
                _context.Entry(book).State = EntityState.Modified;
                _context.Update(book);
                _context.SaveChanges();
            }
        }
    }
}
