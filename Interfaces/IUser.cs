using task_manager_api.Contracts.Requests.DTO;
using task_manager_api.Models;

namespace task_manager_api.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(string email);
        Task<User?> GetUserAsync(UserDTO userdto);
        Task<User?> GetByIdAsync(int id);
        Task<User?> CreateUser(User user);
        Task<User?> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
    }
}
