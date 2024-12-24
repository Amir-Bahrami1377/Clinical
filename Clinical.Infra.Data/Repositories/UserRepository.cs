using Clinical.Domain.Interfaces;
using Clinical.Domain.Models.User;
using Clinical.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical.Infra.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        #region Constructor
        private readonly ClinicalContext _context;

        public UserRepository(ClinicalContext context)
        {
            _context = context;
        }
        #endregion
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByPhoneNumberAsync(int mobile)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.PhoneNumber == mobile);
        }
        public async Task<bool> DuplicatedPhoneNumberAsync(int phoneNumber)
        {
            return await _context.Users.AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
