using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        Task <IEnumerable<Employee>> GetAllAsync();
         Task<Employee ?> GetByIdAsync(int id);   
         Task ADDEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);

        Task DeleteEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
