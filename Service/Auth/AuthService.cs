using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Entity.Identity;
using Entity.VM.Auth;
using Microsoft.AspNetCore.Identity;
using Repository.Identity;
using Service.Exception;
using Service.JWT;

namespace Service.Auth
{
    public class AuthService : IAuth
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUser _user;

        public AuthService(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator,
            SignInManager<AppUser> signInManager,
            IUser user

            )
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _signInManager = signInManager;
            _user = user;
        }
        public async Task<UserVm> LoginAsync(LoginVm model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new RestException(HttpStatusCode.Unauthorized);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                return new UserVm
                {
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                };
            }
            throw new RestException(HttpStatusCode.Unauthorized);
        }

        public async Task<UserVm> RegisterAsync(RegisterVm model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) != null)
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already taken" });

            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return new UserVm
                {
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                };
            }
            throw new System.Exception("Failed to create user");
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _user.GetAllAsync();
        }
    }
}
