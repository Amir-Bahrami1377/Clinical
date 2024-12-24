using Clinical.Domain.DTOs.User;
using Clinical.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByPhoneNumberAsync(int mobile);
        Task<User> GetUserByIdAsync(Guid id);
        Task<LoginResult> LoginAsync(LoginDTO model);
        Task<RegisterResult> RegisterAsync(RegisterDto model);
    }
}
