using Marketum.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Marketum.Persistence
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _filePath = "employees.txt";
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = LoadFromFile();
        }

        public Employee Add(Employee emp)
        {
            emp.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
            _employees.Add(emp);
            SaveToFile();
            return emp;
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>(_employees);
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing == null) return;

            existing.Name = employee.Name;
            existing.TaxNr = employee.TaxNr;
            existing.Email = employee.Email;
            existing.Phone = employee.Phone;
            existing.Address = employee.Address;
            existing.RoleTitle = employee.RoleTitle;

            SaveToFile();
        }

        public void Delete(int id)
        {
            var emp = GetById(id);
            if (emp == null) return;

            _employees.Remove(emp);
            SaveToFile();
        }

        private List<Employee> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Employee>();

            var list = new List<Employee>();

            foreach (var line in File.ReadAllLines(_filePath))
            {
                var p = line.Split(';');
                if (p.Length >= 7)
                {
                    list.Add(new Employee
                    {
                        Id = int.Parse(p[0]),
                        Name = p[1],
                        TaxNr = p[2],
                        Email = p[3],
                        Phone = p[4],
                        Address = p[5],
                        RoleTitle = p[6]
                    });
                }
            }

            return list;
        }

        private void SaveToFile()
        {
            var lines = _employees.Select(e =>
                $"{e.Id};{e.Name};{e.TaxNr};{e.Email};{e.Phone};{e.Address};{e.RoleTitle}");

            File.WriteAllLines(_filePath, lines);
        }
    }
}
