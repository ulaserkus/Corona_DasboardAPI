using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorldAPI.Data.Abstract;
using WorldAPI.Models;

namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private IUserRepository _UserRepository;
        public AuthController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        
        [HttpGet]
        public ActionResult GetUser()
        {
            return Ok(_UserRepository.GetUser());

        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] User user )
        {
            var userx = _UserRepository.GetUser();
            if (user == null)
            {
                return BadRequest("Invalid client request ");
            }

            if(user.UserName == userx.UserName && user.Password == userx.Password)
            {
               


                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@12345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44350",
                    audience: "https://localhost:44350",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });

            }
            else
            {
               return Unauthorized();
            }

        }

    }


}
