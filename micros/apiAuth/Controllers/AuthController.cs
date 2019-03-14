using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace apiAuth.Controllers
{
    public class LoginDto{
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Auth([FromBody] LoginDto loginDto)
        {
            if(loginDto == null)
                return BadRequest("Invalid client request");
            if(!loginDto.Username.Equals("root")&& !loginDto.Password.Equals("root"))
                return BadRequest("Invalid username or password");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ThisIsSecretVEryVerySecretKEY@3123!@#@#@#SD123123123czsr123!!!");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginDto.Username),
                    new Claim(ClaimTypes.Role, "Root")
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Username = loginDto.Username,
                Role = "Root",
                Token = tokenString
            });

        }

    }
}
