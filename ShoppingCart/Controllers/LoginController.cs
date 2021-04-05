using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] User user)
        {
            // TODO: Authenticate with Database

            var result = new APIResult();

            var Claims = new List<Claim>();

            if (user.UserName.ToLower() == "admin" && user.Password.ToLower()=="admin")
            {
                Claims.Add(new Claim("type", "Admin"));
            }
            else if(user.UserName.ToLower() == "user" && user.Password.ToLower() == "user")
            {
                Claims.Add(new Claim("type", "User"));
            }
            else
            {
                return Unauthorized();
            }

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

            var Token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                Claims,
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(Token) });
        }
    }
}
