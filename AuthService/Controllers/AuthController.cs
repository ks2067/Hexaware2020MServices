
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([FromForm] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //check if role exists
                var roleName = roleManager.Roles
                    .FirstOrDefault(r => r.Id == registerDto.Role).NormalizedName;
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {
                    var user = new IdentityUser
                    {
                        UserName = registerDto.Email,
                        Email = registerDto.Email,
                        NormalizedEmail = registerDto.Email
                    };
                    var result = await userManager.CreateAsync(user, registerDto.Password);
                    if (result.Succeeded)
                    {
                        var resultRole = await userManager.AddToRoleAsync(user, roleName);
                        if (resultRole.Succeeded)
                        {
                            return Created("register", "user registered successfully");
                        }
                        return BadRequest(resultRole.Errors);
                    }
                    return BadRequest(result.Errors);
                }
                else
                {
                    return BadRequest("Role does not exist");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromForm] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await signInManager.PasswordSignInAsync(
                loginDto.Email, loginDto.Password, false, false);
            if (result.Succeeded)
            {
                //generate token
                var user = userManager.Users.SingleOrDefault(
                    u => u.Email == loginDto.Email);
                var response = await GenerateJwtToken(user);
                return Ok(response);
            }
            else
            {
                return BadRequest(result);
            }
        }

        private async Task<TokenDto> GenerateJwtToken(IdentityUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var role = roleManager.Roles.SingleOrDefault(r => r.Name == roles.SingleOrDefault());

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            // recommednded is 5 mins
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            //store db/cache

            var response = new TokenDto
            {
                Email = user.Email,
                Token = jwtToken,
                Role = role.Id
            };

            return response;
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            try
            {
                //cache/db
                await signInManager.SignOutAsync();
            }
            catch (Exception)
            {
                //InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Logout failed");
            }

            return Ok();
        }
    }
}
