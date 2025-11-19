using Marketum.Domain;
using System.Collections.Generic;

namespace Marketum.Services
{
    public interface IEmployeeService
    {
        Employee AddEmployee(string name, string taxNr, string email, string phone, string address, string roleTitle);
        List<Employee> GetAllEmployees();
        Employee GetById(int id);
        void UpdateEmployee(Employee employee);
        void RemoveEmployee(int id);
    }
}
