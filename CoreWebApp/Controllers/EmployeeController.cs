using CoreWebApp.Models;
using CoreWebApp.Models.ViewModels;
using CoreWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private IWebHostEnvironment _environment;

        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment environment)
        {
            _employeeRepository = employeeRepository;
            _environment = environment;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> list=_employeeRepository.GetAllEmployees().ToList();
            ViewBag.Title = "Employee List";
            return View(list);
        }
        public IActionResult Details(int id)
        {
            Employee model= _employeeRepository.GetEmployeeById(id);
            string name= model.Name;
            ViewBag.Title = "Employee Details";
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Employee Create";
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName =ProcessUploadFile(model);
              
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.Save(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });

            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Employee employee=_employeeRepository.GetEmployeeById(id);
            EmployeeEditViewModel model = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotopath = employee.PhotoPath
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            //if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployeeById(model.Id);
                employee.Name= model.Name;
                employee.Email= model.Email;
                employee.Department= model.Department;
                if (model.Photo!=null)
                {
                    if (!string.IsNullOrEmpty(model.ExistingPhotopath))
                    {
                        string filePath1=Path.Combine(_environment.WebRootPath,"images",model.ExistingPhotopath);
                        System.IO.File.Delete(filePath1);
                    }

                    employee.PhotoPath = ProcessUploadFile(model);


                }
                Employee upEmployee = _employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee.Id);
                return RedirectToAction("Index");
            }
            
            return View();
        }

        private string ProcessUploadFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = "";
            if (model.Photo!=null)
            {
                string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream=new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
