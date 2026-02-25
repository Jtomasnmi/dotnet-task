
using Microsoft.AspNetCore.Mvc;
using task_manager_api.Models;
using task_manager_api.Interfaces;
using task_manager_api.Contracts.Requests.DTO;

namespace TaskManager.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskItem;

        public TasksController(ITaskService taskItem) => _taskItem = taskItem;

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<TaskItem>>> GetTaskByUser(int userId)
        {
            var tasks = await _taskItem.GetTaskAsync(userId);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(TasksDTO taskdto)
        {
            var createdTask = await _taskItem.CreateTask(taskdto);

            if (createdTask == null) return NotFound(new
            {
                success = false,
                message = "Task not created."
            });

            return Ok(createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TasksDTO taskdto)
        {
            var task = await _taskItem.UpdateTask(id, taskdto);
            if (task == null) return NotFound(new
            {
                success = false,
                message = $"Task id {id} was not found"
            });
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteId = await _taskItem.DeleteTask(id);
            if (!deleteId) return NotFound(new
            {
                success = false,
                message = $"Task with Id {id} not found"
            });
            return Ok(new
            {
                success = true,
                message = $"Task id {id} deleted successfully"
            });
        }
    }
}
