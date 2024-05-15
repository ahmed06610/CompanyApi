using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SystemEntity : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public SystemEntity(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=AHMED\\SQLEXPRESS;Initial Catalog=SystemWebApi;Integrated Security=True; Encrypt=False");
        }
    }
}
