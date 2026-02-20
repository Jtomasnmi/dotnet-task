
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using task_manager_api.Controllers;
using task_manager_api.Interfaces;
using task_manager_api.Models;
using TaskManager.Data;
namespace TaskManager.API
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskItem;

        public TasksController(ITaskService taskItem) => _taskItem = taskItem;

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetTaskByUser(int userId)
        {
            var tasks = await _taskItem.GetAllTaskByUserAsync(userId);
            if (tasks == null || tasks.Count == 0) return NotFound("No tasks found for this user");
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var task = await _taskItem.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound($"Task with Id {id} not found");
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            var createdTask = await _taskItem.CreateTask(task);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdTask.Id },
                createdTask
            );
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> Update(int id, TaskItem updated)
        {
            var task = await _taskItem.UpdateTask(id, updated);
            if (task == null) return NotFound($"Task with Id {id} not found");
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteId = await _taskItem.DeleteTask(id);
            if (!deleteId) return NotFound($"Task with Id {id} not found");
            return NoContent();
        }
    }
}
