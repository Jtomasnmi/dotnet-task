using task_manager_api.Models;

namespace task_manager_api.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(int id);
        Task CreateUser(User user);
        Task<User?> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
    }
}
