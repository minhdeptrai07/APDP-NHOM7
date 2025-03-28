using SMS_APDP.Models;

namespace SMS_APDP.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<bool> CreateUserAsync(User user);
    }
}
