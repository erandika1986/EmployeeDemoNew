using Demo.Api.Models;
using Demo.Api.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext()
        {

        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=EEGDB;User Id=frsadmin;Password=abc123;");
            }
        }

        public DbSet<User> User { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserDepartmentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
