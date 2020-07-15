using System;
using System.Threading.Tasks;
using Entity.VM.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Auth;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuth _auth;
        private readonly ILogger<UserController> _logger;

        public UserController(IAuth auth,ILogger<UserController> logger)
        {
            _auth = auth;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginVm model)
        {
            var result = await _auth.LoginAsync(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterVm model)
        {
           
            var result = await _auth.RegisterAsync(model);
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("GetUser")]
        public async Task<ActionResult> GetAllUser()
        {
            _logger.LogInformation("User");
            var result = await _auth.GetAll();
            return Ok(result);
        }

    }
}
