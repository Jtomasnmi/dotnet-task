using Microsoft.EntityFrameworkCore;
using task_manager_api.Contracts.Requests.DTO;
using task_manager_api.Helpers;
using task_manager_api.Interfaces;
using task_manager_api.Models;
using TaskManager.Data;

namespace task_manager_api.Data
{
    public class UserRepository : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        //find usr by id
        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        //find user by email for non Primary key
        public async Task<User?> GetUserAsync(string email)
        {
            var response = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (response == null) return null;
            return response;
        }

        //i do method overload and use the user dto
        public async Task<User?> GetUserAsync(UserDTO request)
        {
            var response = await _context.Users.Where(u => u.Email == request.email).FirstOrDefaultAsync();

            if (response != null)
            {
                var hashPassword = AuthenticationHelper.VerifyPassword(request.password, response.PasswordHash!);

                if (!hashPassword) return null;
            }

            return response;
        }

        //create new user
        public async Task<User?> CreateUser(User user)
        {
            var hashPassword = AuthenticationHelper.EncryptPassword(user.PasswordHash!);
            user.PasswordHash = hashPassword;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        //edit user
        public async Task<User?> UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null) return null;

            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        //delete user
        public async Task<bool> DeleteUser(int id)
        {
            var queryUser = await _context.Users.FindAsync(id);
            if (queryUser == null) return false;

            _context.Users.Remove(queryUser);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
