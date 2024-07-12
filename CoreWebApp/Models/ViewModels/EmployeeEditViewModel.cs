using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models.ViewModels
{
    public class EmployeeEditViewModel:EmployeeCreateViewModel
    {
        public string ExistingPhotopath { get; set; }
    }
}
