using DotNet8WebAPI.Model;

namespace DotNet8WebAPI.Services
{
    public interface IEmployeesService
    {
        Task<List<Employees>> GetAllEmployees(bool? isActive);
        Task<Employees?> GetEmployeesByID(int id);
        Task<Employees?> AddEmployees(AddUpdateEmployees obj);
        Task<Employees?> UpdateEmployees(int id, AddUpdateEmployees obj);
        Task<bool> DeleteEmployeesByID(int id);
    }
}
