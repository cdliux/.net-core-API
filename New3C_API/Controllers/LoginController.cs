using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using New3C_Model.User;
using New3C_Service;


namespace New3C_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private LoginService _loginService;

        public LoginController(IConfiguration config,LoginService loginService)
        {
            _config = config;
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]User login)
        {
            IActionResult response = Unauthorized();
            var user = _loginService.Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private IActionResult BuildToken(User user)
        {
            //var claims = new[] {
            //    new Claim(JwtRegisteredClaimNames.Sub, user.Name),
            //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
            //    new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            // };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuser"],
              _config["Jwt:Issuser"],
             // claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        //private User Authenticate(User login)
        //{
        //    User user = null;

        //    if (login.UserName == "mario" && login.Password == "secret")
        //    {
        //        user = new User { UserName = "lewis", UserId = "1"};
        //    }
        //    return user;
        //}
    }
}