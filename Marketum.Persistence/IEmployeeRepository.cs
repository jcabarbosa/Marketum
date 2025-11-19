using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        Employee? GetById(int id);
        List<Employee> GetAll();
        void Update(Employee employee);
        void Delete(int id);
    }
}