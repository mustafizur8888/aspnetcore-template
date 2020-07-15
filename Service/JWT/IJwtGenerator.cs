using Entity.Identity;

namespace Service.JWT
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
