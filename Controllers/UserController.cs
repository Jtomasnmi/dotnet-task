using Microsoft.AspNetCore.Mvc;
using task_manager_api.Contracts.Requests.DTO;
using task_manager_api.Interfaces;
using task_manager_api.Models;

namespace task_manager_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                return NotFound(new
                {
                    success = false,
                    message = $"User with Id {id} not found"
                });
            }
            return Ok(task);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> AuthenticateUser(UserDTO userdto)
        {
            var get_user_response = await _userDetail.GetUserAsync(userdto.email);
            var auth_response = await _userDetail.GetUserAsync(userdto);

            if (get_user_response == null)
            {
                return BadRequest(new
                    {
                        success = false,
                        message = "Account does not exist."
                    });
            }
            if (auth_response == null)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Incorrect password."
                });
            }
            return Ok(auth_response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var response = await _userDetail.GetUserAsync(user.Email!);
            if (response != null)
            {
                return Conflict(new
                {
                    success = false,
                    message = $"User with this email '{user.Email}' is already exist."
                });
            }
            await _userDetail.CreateUser(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            var task = await _userDetail.UpdateUser(id, user);
            if (task == null) return NotFound(new
            {
                success = false,
                message = $"User with this email {user.Email} not found"
            });
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteId = await _userDetail.DeleteUser(id);
            if (!deleteId) return NotFound(new
            {
                success = false,
                message = $"User with Id {id} not found"
            });
            return NoContent();
        }
    }
}
