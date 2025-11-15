using Marketum.Domain;

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

        public Employee? GetByUsername(string username)
        {
            return _employees.FirstOrDefault(e => e.Username == username);
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>(_employees);
        }

        public Employee Add(Employee emp)
            emp.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
            _employees.Add(emp);
            SaveToFile();
            return emp;
    }

    private List<Employee> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Employee>();

            var employees = new List<Employee>();

            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split(';');
                if (parts.Length == 7)
                {
                    employees.Add(new Employee
                    {
                        Id = int.Parse(parts[0],
                        Name = parts[1],
                        TaxNr = parts[2],
                        Email = parts[3],
                        Phone = parts[4],
                        Adress = parts[5],
                        Role = parts[6].Split('|')[0],
                        Username = parts[6].Split('|')[1],
                        Password = parts[6].Split('|')[2]
                    });
                }
            }

            return employees;
        }

        private void SaveToFile()
        {
            var lines = _employees.Select(e =>
                $"{e.Id};{e.Name};{e.TaxNr};{e.Email};{e.Phone};{e.Adress};{e.Role}|{e.Username}|{e.Password}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}