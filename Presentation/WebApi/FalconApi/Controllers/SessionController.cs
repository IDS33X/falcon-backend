using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using Util.Exceptions;
using Util.Support;

namespace FalconApi.Controllers
{
    [ApiController]
    [Route("falconapi/[Controller]")]
    public class SessionController : Controller
    {
        private ISessionService service;

        public SessionController(ISessionService service){
            this.service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody]LogInRequest login){

            try{
                var response = await service.Login(login);
                return Ok(response);
            }catch(DoesNotExistException e){
                return BadRequest(e.Message);
            }catch(IncorrectPasswordException e){
                return BadRequest(e.Message);
            }

        }
    }
}