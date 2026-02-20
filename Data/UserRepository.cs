using task_manager_api.Interfaces;
using task_manager_api.Models;
using TaskManager.Data;

namespace task_manager_api.Data
{
    public class UserRepository : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
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
