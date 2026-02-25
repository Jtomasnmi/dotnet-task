using task_manager_api.Contracts.Requests.DTO;
using task_manager_api.Models;

namespace task_manager_api.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetTaskAsync(int userId);
        Task<TaskItem> CreateTask(TasksDTO taskdto);
        Task<TaskItem?> UpdateTask(int id, TasksDTO taskdto);
        Task<bool> DeleteTask(int id);
    }
}
