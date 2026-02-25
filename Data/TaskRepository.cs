using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using task_manager_api.Contracts.Requests.DTO;
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
        public async Task<List<TaskItem>> GetTaskAsync(int userId)
        {
            var response = await _context.Tasks.Where(c => c.UserId == userId).ToListAsync();
            if (response == null) return null;
            return response;
        }

        //create a task
        public async Task<TaskItem> CreateTask(TasksDTO taskdto)
        {

            var requestTask = new TaskItem { UserId = taskdto.UserId, Title = taskdto.Title!, IsDone = taskdto.isDone};
            await _context.Tasks.AddAsync(requestTask);
            await _context.SaveChangesAsync();
            return requestTask;

        }

        //edit task
        public async Task<TaskItem?> UpdateTask(int id, TasksDTO tasksdto)
        {
            var existingTask = await _context.Tasks.FindAsync(id);

            if (existingTask == null) return null;
            if (tasksdto.Title != null)
            {
                existingTask.Title = tasksdto.Title;
            }
            if (tasksdto.isDone)
            {
                existingTask.IsDone = true;
            }
            
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
