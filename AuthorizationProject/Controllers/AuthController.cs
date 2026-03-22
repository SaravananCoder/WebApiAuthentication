using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthorizationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //[HttpPost("login")]
        //public IActionResult Login([FromQuery] string username, [FromQuery] string password)
        //{
        //    if (username == "admin" && password == "1234")
        //    {
        //        var token = GenerateToken(username);
        //        return Ok(new { token });
        //    }

        //    return Unauthorized();
        //}


        //[HttpPost("login")]
        //public IActionResult Login(string username, string password)
        //{
        //    if (username == "admin" && password == "1234")
        //    {
        //        var token = GenerateToken(username, "Admin");
        //        return Ok(new { token });
        //    }

        //    if (username == "user" && password == "1234")
        //    {
        //        var token = GenerateToken(username, "User");
        //        return Ok(new { token });
        //    }

        //    return Unauthorized();
        //}
        [HttpPost("login")]
        public IActionResult Login([FromQuery] string username, [FromQuery] string password)
        {
            if (username == "admin" && password == "1234")
            {
                var token = GenerateToken(username, "Admin");
                return Ok(new { token });
            }

            if (username == "user" && password == "1234")
            {
                var token = GenerateToken(username, "User");
                return Ok(new { token });
            }

            return Unauthorized();
        }
        //private string GenerateToken(string username)
        //{
        //    var jwtSettings = _configuration.GetSection("Jwt");

        //    var key = new SymmetricSecurityKey(
        //        Encoding.UTF8.GetBytes(jwtSettings["Key"]));

        //    var credentials = new SigningCredentials(
        //        key, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //    new Claim(ClaimTypes.Name, username)
        //};

        //    var token = new JwtSecurityToken(
        //        issuer: jwtSettings["Issuer"],
        //        audience: jwtSettings["Audience"],
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(
        //            Convert.ToDouble(jwtSettings["DurationInMinutes"])),
        //        signingCredentials: credentials
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        //token generate process
        private string GenerateToken(string username, string role)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

            var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, role) // ROLE ADDED
    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(jwtSettings["DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
