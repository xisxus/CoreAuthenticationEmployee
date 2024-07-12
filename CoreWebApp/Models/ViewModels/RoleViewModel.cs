using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
