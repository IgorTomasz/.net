using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Perscription.Models;
using Perscription.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Perscription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountsController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("refresh")]
        public IActionResult Refresh(string refToken) {


            AppUser user = _context.AppUser.Where(u=>u.RefToken==refToken).FirstOrDefault();

            if (user.RefToken!=null || user.ExpiresAt<DateTime.Now) {
                Claim[] userClaim = new[]
                {
                new Claim(ClaimTypes.Name, "Adam"),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "admin")
                };

                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));

                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:5131",
                    audience: "https://localhost:5131",
                    claims: userClaim,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                user.RefToken = Guid.NewGuid().ToString();
                user.ExpiresAt = DateTime.Now.AddDays(1);
                _context.SaveChanges();

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    refreshToken = user.RefToken
                });
            }
            return BadRequest("Login again");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            AppUser user =  _context.AppUser.Where(u => u.Login == loginRequest.Login).FirstOrDefault();

            if (user == null)
            {
                return NotFound("User not found");
            }

            string passwordHash = user.Password;
            string curHashedPassword = HashPassw(loginRequest.Password,user.Salt);

            //Walidacja hasła


            if (passwordHash != curHashedPassword)
            {
                return Unauthorized();
            }

            Claim[] userClaim = new[]
            {
                new Claim(ClaimTypes.Name, "Adam"),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "admin")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:5131",
                audience: "https://localhost:5131",
                claims: userClaim,
                expires: DateTime.Now.AddMinutes(0.5),
                signingCredentials: creds
                );

            user.RefToken = Guid.NewGuid().ToString();
            user.ExpiresAt = DateTime.Now.AddDays(1);
            _context.SaveChanges();

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = user.RefToken
            });
        }

        public static string HashPassw(string password,string salt)
        {
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
