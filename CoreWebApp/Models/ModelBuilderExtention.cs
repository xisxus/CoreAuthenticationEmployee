using Microsoft.EntityFrameworkCore;

namespace CoreWebApp.Models
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee { Id = 1, Name = "Nishat", Email = "nishat@gmail.com", Department = Dept.IT }
               );
        }
    }
}
