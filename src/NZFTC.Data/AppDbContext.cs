//AppDbContext - Data Mapping and EF Pipe Helper No TOUCH!!!
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZFTC.Data.Entities;

namespace NZFTC.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;
        public DbSet<Payroll> Payrolls { get; set; } = null!;
        public DbSet<Grievance> Grievances { get; set; } = null!;
        public DbSet<Holiday> Holidays { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important for Identity

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payroll>()
                .Property(p => p.GrossPay).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Payroll>()
                .Property(p => p.Tax).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Payroll>()
                .Property(p => p.NetPay).HasColumnType("decimal(18,2)");
        }
    }
}