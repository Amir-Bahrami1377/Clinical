using Clinical.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetByPhoneNumberAsync(int mobile);
        Task<User> GetByIdAsync(Guid id);
        Task<bool> DuplicatedPhoneNumberAsync(int phoneNumber);
        Task InsertAsync(User user);
        Task SaveAsync();
    }
}
