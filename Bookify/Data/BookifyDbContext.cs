using Bookify.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Data
{
    public class BookifyDbContex : DbContext
    {
        public BookifyDbContex(DbContextOptions<BookifyDbContex> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
