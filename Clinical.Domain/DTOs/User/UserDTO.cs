using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical.Domain.DTOs.User
{
    public class UserDTO
    {
        public string DisplayName { get; set; }
        //public string Avatar { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
