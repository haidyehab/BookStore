using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Domain
{
	public class DatabaseContext :DbContext
	{
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
    }
}
