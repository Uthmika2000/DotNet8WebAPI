using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebAPI.Entity
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options) 
        {
        }

        // Registered DB Model in EmployeesDbContext file
        public DbSet<Employees> Employeess { get; set; }
        public DbSet<User> Users { get; set; }

        /*
         OnModelCreating mainly used to configured our EF model
         And insert master data if required
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in Employees model
            modelBuilder.Entity<Employees>().HasKey(x => x.Id);

            // Inserting record in Employees table
            modelBuilder.Entity<Employees>().HasData(
                new Employees
                {
                    Id = 1,
                    Name = "System",
                    Dob = "",
                    Salary = "",
                    isActive = true,
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "System",
                    Dob = "",
                    Username = "System",
                    Password = "System",
                }
            );
        }
    }
}
