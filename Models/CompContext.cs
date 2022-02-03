using Microsoft.EntityFrameworkCore;

namespace REST_API_DOTNET.Models
{
    public class CompContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        public CompContext(DbContextOptions<CompContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
