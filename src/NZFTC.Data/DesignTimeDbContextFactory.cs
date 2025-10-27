using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NZFTC.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // Local dev Sqlite DB; change connection string if you prefer a different provider
            optionsBuilder.UseSqlite("Data Source=dev.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}