using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Test.Data;
using Test.Dto;
using System.Text;

namespace Test.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly BaseContext _context;

        public AuthController(BaseContext context)
        {
            _context = context;
        }

        [HttpPost("login")]

        public async Task<IActionResult> login([FromBody] AuthResponse authResponse)
        {
            var token_validation = _context.Users.FirstOrDefault(u => u.Email == authResponse.Email && u.Password == authResponse.Password);

            if(token_validation == null)
            {
                return BadRequest("The email or password isn't valid");
            }
            else
            {
                var secret_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E"));
                var signin_credentials = new SigningCredentials(secret_key, SecurityAlgorithms.HmacSha256);
                var token_options = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signin_credentials
                );
                var token_string = new JwtSecurityTokenHandler().WriteToken(token_options);

                return Ok(new { Token = token_string });
            }

            return Unauthorized();
        }
    }
}