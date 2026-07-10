using Microsoft.EntityFrameworkCore;
using librosApi.Domain;

namespace librosApi.Repository
{
    public class DbcontextBooks: DbContext
    {
        public DbcontextBooks(DbContextOptions<DbcontextBooks> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
