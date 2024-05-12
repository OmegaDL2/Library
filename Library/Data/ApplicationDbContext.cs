using Microsoft.EntityFrameworkCore;
using Library.Models;
namespace Library.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<Library.Models.Book> Book { get; set; } = default!;
    }
}
