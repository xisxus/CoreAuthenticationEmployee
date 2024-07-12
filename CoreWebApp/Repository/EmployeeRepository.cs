using CoreWebApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CoreWebApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public EmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name="Nishat",Email="nishat@gmail.com",Department=Dept.HR},
               
            };
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = this._employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
                return employee;
            else return null;
        }


        public Employee Save(Employee employee)
        {
           employee.Id=_employeeList.Max(e => e.Id)+1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee upEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
