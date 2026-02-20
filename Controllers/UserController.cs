using Microsoft.AspNetCore.Mvc;
using task_manager_api.Interfaces;
using task_manager_api.Models;

namespace task_manager_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userDetail;

        public UserController(IUserService userDetail) => _userDetail = userDetail;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var task = await _userDetail.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound($"User with Id {id} not found");
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {

            await _userDetail.CreateUser(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            var task = await _userDetail.UpdateUser(id, user);
            if (task == null) return NotFound($"User with Id {id} not found");
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteId = await _userDetail.DeleteUser(id);
            if (!deleteId) return NotFound($"User with Id {id} not found");
            return NoContent();
        }
    }
}
