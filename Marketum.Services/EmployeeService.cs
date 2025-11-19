using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;
using System.Collections.Generic;

namespace Marketum.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Employee AddEmployee(string name, string taxNr, string email, string phone, string address, string roleTitle)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("O nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(taxNr))
                throw new ValidationException("O NIF é obrigatório.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ValidationException("O email é obrigatório.");

            var emp = new Employee
            {
                Name = name,
                TaxNr = taxNr,
                Email = email,
                Phone = phone,
                Address = address,
                RoleTitle = roleTitle
            };

            return _repository.Add(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public Employee GetById(int id)
        {
            var emp = _repository.GetById(id);
            if (emp == null)
                throw new NotFoundException("Funcionário não encontrado.");

            return emp;
        }

        public void UpdateEmployee(Employee employee)
        {
            var existing = _repository.GetById(employee.Id);
            if (existing == null)
                throw new NotFoundException("Funcionário não encontrado.");

            _repository.Update(employee);
        }

        public void RemoveEmployee(int id)
        {
            var emp = _repository.GetById(id);
            if (emp == null)
                throw new NotFoundException("Funcionário não encontrado.");

            _repository.Delete(id);
        }
    }
}
