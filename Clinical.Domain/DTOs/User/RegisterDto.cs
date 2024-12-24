using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical.Domain.DTOs.User
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }
        public string Username { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationalId { get; set; }
        public int PhoneNumber { get; set; }
    }
    public enum RegisterResult
    {
        Success,
        Error,
        DuplicatedPhoneNumber
    }
}
