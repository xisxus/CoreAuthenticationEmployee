using CoreWebApp.Models;

namespace CoreWebApp.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        Employee Save(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Employee Delete(int id);
        Employee Update(Employee upEmployee);
    }
}
