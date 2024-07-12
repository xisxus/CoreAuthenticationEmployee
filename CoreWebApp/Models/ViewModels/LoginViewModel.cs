using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "User Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
