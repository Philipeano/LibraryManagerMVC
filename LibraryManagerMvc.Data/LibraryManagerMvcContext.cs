using LibraryManagerMvc.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerMvc.Data
{
    public class LibraryManagerMvcContext : DbContext
    {
        public LibraryManagerMvcContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}