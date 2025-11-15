using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IEmployeeRepository
    {
        Employee? GetByUsername(string username);
        List<Employee> GetAll();
        Employee Add(Employee employee);
    }
}