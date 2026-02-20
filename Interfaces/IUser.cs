using task_manager_api.Models;

namespace task_manager_api.Interfaces
{
    public interface IUser
    {
        Task<User?> GetByIdAsync(int id);
        Task CreateUser(User user);
    }
}
