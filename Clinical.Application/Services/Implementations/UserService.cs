using Clinical.Application.Services.Interfaces;
using Clinical.Domain.DTOs.User;
using Clinical.Domain.Interfaces;
using Clinical.Domain.Models.User;

namespace Clinical.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByPhoneNumberAsync(int mobile)
        {
            return await _userRepository.GetByPhoneNumberAsync(mobile);
        }

        public async Task<LoginResult> LoginAsync(LoginDTO model)
        {
            var user = await _userRepository.GetByPhoneNumberAsync(model.PhoneNumber);
            if (user == null)
                return LoginResult.UserNotFound;
            var hashPassword = model.Password;
            if (user.PasswordHash != hashPassword)
                return LoginResult.Failure;
            return LoginResult.Success;
        }

        public async Task<RegisterResult> RegisterAsync(RegisterDto model)
        {
            if (await _userRepository.DuplicatedPhoneNumberAsync(model.PhoneNumber))
                return RegisterResult.DuplicatedPhoneNumber;
            var hashPassword = model.Password;
            User user = new User()
            {
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                PasswordHash = hashPassword,
                NationalId = model.NationalId,
                DisplayName = model.DisplayName,
                CreatedAt = DateTime.Now,
            };
            await _userRepository.InsertAsync(user);
            await _userRepository.SaveAsync();
            return RegisterResult.Success;
        }
    }
}
