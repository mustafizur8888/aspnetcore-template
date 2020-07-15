using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Identity;
using Entity.VM.Auth;

namespace Service.Auth
{
    public interface IAuth
    {
        Task<UserVm> LoginAsync(LoginVm model);
        Task<UserVm> RegisterAsync(RegisterVm model);

        Task<IEnumerable<AppUser>> GetAll();
    }
}
