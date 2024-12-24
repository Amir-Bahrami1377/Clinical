using Clinical.Domain.Models.User;

namespace Clinical.Api.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
