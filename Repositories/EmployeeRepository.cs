using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository //ER is class and implementing the interface IER
    {
        private readonly AppDbContext _context; //The constructor uses Di to get an instance of AppDbContext(ef)
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
     
        }
        public async Task ADDEmployeeAsync(Employee employee)//Adds a new Employee record to the Employees table.
        {
            await  _context.Employees.AddAsync(employee);
             await _context.SaveChangesAsync();//commit change in the db
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employeeInDb = await _context.Employees.FindAsync(id);

            if (employeeInDb == null)
            {
                throw new KeyNotFoundException($"Employee with id {id} was not found.");
            }
            _context.Employees.Remove(employeeInDb);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public  async Task<Employee ?> GetByIdAsync(int id)
        {
           return await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
         _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        Task IEmployeeRepository.DeleteEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
