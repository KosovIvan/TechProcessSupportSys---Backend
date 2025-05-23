using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TechProcessSupportSys.Dtos.User;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.Repository;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signinManager;
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        private readonly IAutomapper automapper;

        public UserController(UserManager<User> userManager, SignInManager<User> signinManager, IUserRepository userRepository, ITokenService tokenService, IAutomapper automapper)
        {
            this.userManager = userManager;
            this.signinManager = signinManager;
            this.userRepository = userRepository;
            this.tokenService = tokenService;
            this.automapper = automapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.Users.FirstOrDefaultAsync(u => u.UserName!.ToLower() == loginDto.Login!.ToLower());

            if (user == null) return Unauthorized("Некорректный логин");

            var result = await signinManager.CheckPasswordSignInAsync(user, loginDto.Password!, false);

            if (!result.Succeeded) return Unauthorized("Некорретный логин и/или пароль");

            return Ok(
                new UserTokenDto
                {
                    Login = user.UserName!,
                    Name = user.Name!,
                    Email = user.Email!,
                    Role = (await userManager.IsInRoleAsync(user, "Admin")) ? "Admin" : "User",
                    Token = await tokenService.CreateToken(user)
                });
        }

        [HttpPost("create-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!(await userRepository.CheckLogin(createUserDto.Login!))) return BadRequest("Пользователь с данным логином уже существует");

                var user = new User
                {
                    UserName = createUserDto.Login,
                    Name = createUserDto.Name,
                    Email = createUserDto.Email
                };
                bool isAdmin = createUserDto.IsAdmin;

                var createdUser = await userManager.CreateAsync(user, createUserDto.Password!);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, isAdmin ? "Admin" : "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new UserDto
                        {
                            Login = user.UserName!,
                            Name = user.Name,
                            Email = user.Email!,
                            Role = isAdmin ? "Admin" : "User"
                        });
                    }
                    else return StatusCode(500, roleResult.Errors);
                }
                else return StatusCode(500, createdUser.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!(await userRepository.CheckLogin(registerDto.Login!))) return BadRequest("Пользователь с данным логином уже существует");

                var user = new User
                {
                    UserName = registerDto.Login,
                    Name = registerDto.Name,
                    Email = registerDto.Email
                };

                var createdUser = await userManager.CreateAsync(user, registerDto.Password!);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new UserTokenDto
                        {
                            Login = user.UserName!,
                            Name = user.Name,
                            Email = user.Email!,
                            Role = "User",
                            Token = await tokenService.CreateToken(user)
                        });
                    }
                    else return StatusCode(500, roleResult.Errors);
                }
                else return StatusCode(500, createdUser.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await userManager.Users.ToListAsync();

            var usersDto = new List<UserOutputDto>();
            foreach (var u in users)
            {
                var dto = automapper.Map<UserOutputDto, User>(u);
                dto.Login = u.UserName!;
                dto.Role = (await userManager.IsInRoleAsync(u, "Admin")) ? "Admin" : "User";
                usersDto.Add(dto);
            }

            return Ok(usersDto);
        }

        [HttpGet("{login}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByLogin([FromRoute] string login)
        {
            var user = await userManager.FindByNameAsync(login);

            if (user == null) return NotFound();

            var userDto = automapper.Map<UserOutputDto, User>(user);
            userDto.Login = user.UserName!;
            userDto.Role = (await userManager.IsInRoleAsync(user, "Admin")) ? "Admin" : "User";
            return Ok(userDto);
        }

        [HttpPut("update-data/{login}")]
        [Authorize]
        public async Task<IActionResult> UpdateData([FromRoute] string login, [FromBody] UpdateDataUserDto updateUserDto)
        {
            try
            {
                if ((User.FindFirstValue(ClaimTypes.GivenName) != login) && (User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType) != "Admin")) return Forbid();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await userManager.FindByNameAsync(login);
                if (user == null) return NotFound();

                if (!(await userRepository.CheckLogin(updateUserDto.Login!))&&(updateUserDto.Login! != user.UserName)) return BadRequest("Пользователь с данным логином уже существует");
                if (await userRepository.IsRevoked(login) && (User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType) != "Admin")) return NotFound();

                user.UserName = updateUserDto.Login;
                user.Name = updateUserDto.Name;
                user.Email = updateUserDto.Email;
                var updatedUser = await userManager.UpdateAsync(user);

                if (updatedUser.Succeeded)
                {
                    var userDto = automapper.Map<UserDto, User>(user);
                    userDto.Login = user.UserName;
                    userDto.Role = (await userManager.IsInRoleAsync(user, "Admin")) ? "Admin" : "User";
                    return Ok(userDto);
                }
                else return StatusCode(500, updatedUser.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update-password/{login}")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromRoute] string login, [FromBody] UpdatePasswordUserDto updatePasswordUserDto)
        {
            try
            {
                if ((User.FindFirstValue(ClaimTypes.GivenName) != login) && (User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType) != "Admin")) return Forbid();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await userRepository.IsRevoked(login) && (User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType) != "Admin")) return NotFound();

                var user = await userManager.FindByNameAsync(login);
                if (user == null) return NotFound();

                var updatedUser = await userManager.ChangePasswordAsync(user, updatePasswordUserDto.OldPassword, updatePasswordUserDto.NewPassword);

                if (updatedUser.Succeeded)
                {
                    var userDto = automapper.Map<UserDto, User>(user);
                    userDto.Login = user.UserName!;
                    userDto.Role = (await userManager.IsInRoleAsync(user, "Admin")) ? "Admin" : "User";
                    return Ok(userDto);
                }
                else return StatusCode(500, updatedUser.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{login}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserByLogin([FromRoute] string login)
        {
            var user = await userManager.FindByNameAsync(login);

            if (user == null) return NotFound();
            if (await userManager.IsInRoleAsync(user, "Admin")) return Forbid();

            var deleterLogin = User.FindFirstValue(ClaimTypes.GivenName);
            var deleted = await userRepository.DeleteUserByLogin(user, deleterLogin);

            return Ok();
        }

        [HttpPut("recover-user/{login}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRecover([FromRoute] string login)
        {
            var recoveredUser = await userRepository.UpdateRecover(login);

            if (recoveredUser == null) return NotFound();

            var userDto = automapper.Map<UserDto, User>(recoveredUser);
            return Ok(userDto);
        }
    }
}