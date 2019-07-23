using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProAgil.API.Dtos;
using ProAgil.Domain.Identity;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IConfiguration config,
                                UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet("GetUser")]
      

        public async Task<IActionResult> GetUser()
        {
            return Ok(new User());
        }



        [HttpPost("Register")]
          [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);
                var userToReturn = _mapper.Map<UserDto>(user);
                if(result.Succeeded)
                {
                    return Created("GetUser", userToReturn);
                }
                return BadRequest(result.Errors);
            }
            catch (System.Exception ex)
            {
                
               return this.StatusCode (StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }
    }
}