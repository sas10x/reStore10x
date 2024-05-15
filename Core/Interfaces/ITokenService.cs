using Core.Entities.Identity;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        string CreateTokenv1(AppUser user);
        string CreateToken(AppUser user);
    }
}