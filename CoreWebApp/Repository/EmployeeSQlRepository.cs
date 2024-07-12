using CoreWebApp.Models;

namespace CoreWebApp.Repository
{
    public class EmployeeSQlRepository : IEmployeeRepository
    {
        private readonly AppDBContext _context;

        public EmployeeSQlRepository(AppDBContext context)
        {
            _context = context;
        }



        public IEnumerable<Employee> GetAllEmployees()
        {
           return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee Save(Employee employee)
        {
           _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        public Employee Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }
        public Employee Update(Employee upEmployee)
        {
            var employee=_context.Employees.Attach(upEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return upEmployee;
        }
    }
}
