using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Identity;

namespace Repository.Identity
{
    public interface IUser
    {
        Task<AppUser> GetByEmailAsync(string email);
        Task<AppUser> GetByIdAsync(string id);
        Task<IEnumerable<AppUser>> GetAllAsync();
    }
}
