using ShopYenSao.Application.Models.Identity;

namespace ShopYenSao.Application.Identity;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(string userId);
}