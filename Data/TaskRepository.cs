using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using task_manager_api.Interfaces;
using task_manager_api.Models;
using TaskManager.Data;

namespace task_manager_api.Data
{
    public class TaskRepository: ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public TaskRepository(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        //feth all task
        public async Task<List<TaskItem>> GetAllTaskByUserAsync(int id)
        {
            var response = await _context.Tasks.Where(c => c.Id == id).ToListAsync();
            return response;
        }

        //fetch specific task
        public async Task<TaskItem?> GetByIdAsync(int id) => await _context.Tasks.FindAsync(id);

        //create a task
        public async Task<TaskItem> CreateTask(TaskItem taskItem)
        {
            await _context.Tasks.AddAsync(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        //edit task
        public async Task<TaskItem?> UpdateTask(int id, TaskItem taskItem)
        {
            var existingTask = await _context.Tasks.FindAsync(id);

            if (existingTask == null) return null;

            existingTask.Title = taskItem.Title;
            existingTask.IsDone = taskItem.IsDone;
            
            await _context.SaveChangesAsync();
            return existingTask;
        }

        //delete task
        public async Task<bool> DeleteTask(int id)
        {
            var queryId = await _context.Tasks.FindAsync(id);
            if (queryId == null) return false;

            _context.Tasks.Remove(queryId);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
