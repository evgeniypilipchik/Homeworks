using Microsoft.EntityFrameworkCore;

namespace Homework_23.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Reader> Readers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Library2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
    }
}
