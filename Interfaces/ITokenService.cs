using codegym_api.Models;

namespace codegym_api.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}
