using Microsoft.EntityFrameworkCore;

namespace NZFTC.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		// Example DbSet, replace or extend with real entities
		public DbSet<SampleEntity> SampleEntities { get; set; } = null!;
	}

	public class SampleEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
	}
}