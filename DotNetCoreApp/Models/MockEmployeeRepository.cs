using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApp.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){ ID=1, Name="ADARSH",Email="test@gmail.com",Department=Department.None},
                new Employee(){ ID=2, Name="ADYA",Email="test123@gmail.com",Department=Department.Payroll},
                new Employee(){ ID=3, Name="SANJAY",Email="testSA@gmail.com",Department=Department.HR},
                new Employee(){ ID=4, Name="BANDNA",Email="testBA@gmail.com",Department=Department.IT}

            };
        }

        public Employee AddEmployee(Employee employee)
        {
           employee.ID= _employeeList.Max(e => e.ID) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.ID == Id);
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
