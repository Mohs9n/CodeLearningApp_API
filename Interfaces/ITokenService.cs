using codegym_api.Entities;

namespace codegym_api.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}
