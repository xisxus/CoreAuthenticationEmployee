using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required,MaxLength(50,ErrorMessage ="Name cannot exceed 50 characters")]
        public string Name { get; set; } = "";
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invalid format")]
        [Required]
        public string Email { get; set; } = "";
        public Dept? Department { get; set; }
        public string? PhotoPath { get; set; }

    }
}
