using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApp.Models
{
    public class AppDBContext:IdentityDbContext<IdentityUser>
    {
        public AppDBContext()
        {
            
        }
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) 
        {
            
        }
        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Seed();

           
        }
    }
}
