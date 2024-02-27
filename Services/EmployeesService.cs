using DotNet8WebAPI.Entity;
using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebAPI.Services
{
    public class EmployeesService:IEmployeesService
    {
        private readonly EmployeesDbContext _db;
        public EmployeesService(EmployeesDbContext db)
        {
            _db = db;
        }

        public async Task<List<Employees>> GetAllEmployees(bool? isActive)
        {
            if (isActive == null) { return await _db.Employeess.ToListAsync(); }

            return await _db.Employeess.Where(obj => obj.isActive == isActive).ToListAsync();
        }

        public async Task<Employees?> GetEmployeesByID(int id)
        {
            return await _db.Employeess.FirstOrDefaultAsync(hero => hero.Id == id);
        }

        public async Task<Employees?> AddEmployees(AddUpdateEmployees obj)
        {
            var addEmployees = new Employees()
            {
                Name = obj.Name,
                Dob = obj.Dob,
                Salary = obj.Salary,
                isActive = obj.isActive,
            };

            _db.Employeess.Add(addEmployees);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addEmployees : null;
        }

        public async Task<Employees?> UpdateEmployees(int id, AddUpdateEmployees obj)
        {
            var employee = await _db.Employeess.FirstOrDefaultAsync(index => index.Id == id);
            if (employee != null)
            {
                employee.Name = obj.Name;
                employee.Dob = obj.Dob;
                employee.Salary = obj.Salary;
                employee.isActive = obj.isActive;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? employee : null;
            }
            return null;
        }

        public async Task<bool> DeleteEmployeesByID(int id)
        {
            var employee = await _db.Employeess.FirstOrDefaultAsync(index => index.Id == id);
            if (employee != null)
            {
                _db.Employeess.Remove(employee);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
