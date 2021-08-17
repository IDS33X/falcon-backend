using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Service;
using Util.Exceptions;
using Util.Support.Requests;
using Util.Support.Response;

namespace FalconApi.Controllers
{

    [ApiController]
    [Route("falconapi/[Controller]")]
    public class SessionController : Controller
    {
        private readonly ISessionService _service;
        private readonly IConfiguration _config;
        public SessionController(ISessionService service, IConfiguration configuration){
            _service = service;
            _config = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LogInRequest login){

            try{
                LogInResponse response = new LogInResponse();

                var employeeDto = await _service.Login(login);

                string token = GenerateJSONWebToken(employeeDto.EmployeeRol.Name);

                response.Employee = employeeDto;
                response.Token = token;

                return Ok(response);
            }catch(DoesNotExistException e){
                return BadRequest(e.Message);
            }catch(IncorrectPasswordException e){
                return BadRequest(e.Message);
            }

        }

        private string GenerateJSONWebToken(string rol)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, rol)
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}