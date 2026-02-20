using task_manager_api.Models;

namespace task_manager_api.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTaskByUserAsync(int id);
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> CreateTask(TaskItem taskItem);
        Task<TaskItem?> UpdateTask(int id, TaskItem taskItem);
        Task<bool> DeleteTask(int id);
    }
}
