using Microsoft.EntityFrameworkCore;

namespace SMS.WebApp.DatabaseContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> ContextOption) : DbContext(ContextOption)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

