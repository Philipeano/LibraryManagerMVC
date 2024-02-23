using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LibraryManagerMvc.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerMvc.Data
{
    public class LibraryManagerMvcContext : IdentityDbContext<LibraryManagerUser, LibraryManagerRole, string>
    {
        public LibraryManagerMvcContext(DbContextOptions<LibraryManagerMvcContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Book> Books { get; set; }
    }
}