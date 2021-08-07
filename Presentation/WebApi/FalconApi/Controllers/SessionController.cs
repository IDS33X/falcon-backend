using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Service;
using Util.dto;
using Util.exceptions;

namespace FalconApi.Controllers
{
    [ApiController]
    [Route("falconapi/[controller]")]
    public class SessionController : ControllerBase
    {
        
        private ISessionService sessionService;

        public SessionController(ISessionService sessionService){
            this.sessionService = sessionService;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<Employee>> LogIn([FromBody] DtoLogin dto){

            Employee response = new Employee();
            //Employee test = new Employee(1,"Adriel","Rosario","1234","abcd");

            try{
                response = await sessionService.LogIn(dto);
            }
            catch(DoesNotExistException e){
                return NotFound(e.Message);
            }
            catch(IncorrectPasswordException e){
                return NotFound(e.Message);
            }
            
            return response;
            
        }
        
    }
}