using SMS_APDP.DTO;
using SMS_APDP.Models;

namespace SMS_APDP.Sevices
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(UserRegisterDto userDto);
        void Logout();

    }
}
