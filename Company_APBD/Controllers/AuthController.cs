using CodeFirst.Helpers;
using Company_APBD.Models;
using Company_APBD.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Company_APBD.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILoginService _dbService;

        public AuthController(IConfiguration configuration, ILoginService dbService)
        {
            _config = configuration;
            _dbService = dbService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUser employee)
        {
            var hashedPasswordAndSalt = Logger.GetHashedPassword(employee.Password);

            var user = new Employee()
            {
                Login = employee.Login,
                Password = hashedPasswordAndSalt.Item1,
                Salt = hashedPasswordAndSalt.Item2,
                RefreshToken = Logger.GenerateRefreshToken(),
                RoleID = employee.RoleID
            };
            
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]!)),
                    SecurityAlgorithms.HmacSha256
                ),
                expires: DateTime.UtcNow.AddMinutes(15)
            );
            
            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenRef=Logger.GenerateRefreshToken();
            var stringToken = tokenHandler.WriteToken(token);
            
            await _dbService.RegisterUser(user);
            
            await _dbService.SetUserToken(user, tokenRef);
        
            return Ok(new LoginResp
            {
                Token = stringToken,
                RefreshToken = tokenRef
            });
        }

        //login z zapisaniem tokena 
        [HttpPost("login")]
        public async Task<IActionResult> Login(Employee employee)
        {
            Employee user = await _dbService.GetUser(employee.Login);

            if (user == null || user.Password != Logger.GetHashedPasswordWithSalt(employee.Password, user.Salt))
            {
                return Unauthorized();
            }

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]!)),
                    SecurityAlgorithms.HmacSha256
                ),
                expires: DateTime.UtcNow.AddMinutes(15)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenRef = Logger.GenerateRefreshToken();
            var stringToken = tokenHandler.WriteToken(token);

            await _dbService.SetUserToken(user, tokenRef);

            return Ok(new LoginResp
            {
                Token = stringToken,
                RefreshToken = tokenRef
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(Token model)
        {
            Employee user = await _dbService.GetUserByToken(model.RefreshToken);
            if (user == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Login.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["Jwt:RefIssuer"],
                audience: _config["Jwt:RefAudience"],
                claims: claims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:RefKey"]!)),
                    SecurityAlgorithms.HmacSha256
                ),
                expires: DateTime.UtcNow.AddMinutes(15)
            );

            string tokenRef = Logger.GenerateRefreshToken();

            await _dbService.SetUserToken(user, tokenRef);

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                accessToken = tokenHandler,
                refreshToken = tokenRef
            });
        }
    }
}