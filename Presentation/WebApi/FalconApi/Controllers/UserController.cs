using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Support.Requests.User;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddUserRequest request)
        {
            var response = await _userService.Add(request);

            return Ok(response);
        }

        [HttpGet("GetUsersByDepartment")]
        public async Task<IActionResult> GetUsersByDepartment([FromQuery] UsersByDepartmentRequest request)
        {
            var response = await _userService.GetUsersByDepartment(request);

            return Ok(response);
        }
        [HttpGet("SearchUsersByDepartment")]
        public async Task<IActionResult> GetUsersByDepartmentAndSearch([FromQuery] UsersByDepartmentSearchRequest request)
        {
            var response = await _userService.GetUsersByDepartmentAndSearch(request);

            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var userDto = await _userService.GetById(id);

                return Ok(userDto);
            }
            catch (DoesNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //[HttpDelete("Remove")]
        //public async Task<IActionResult> Remove(int id)
        //{
        //    try
        //    {
        //        var isRemoved = await _userService.Removed(id);

        //        return Ok(isRemoved);

        //    }
        //    catch (DoesNotExistException e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(EditUserProfileRequest request)
        {
            try
            {
                var response = await _userService.UpdateProfile(request);

                return Ok(response);
            }
            catch (DoesNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPut("UpdateLogin")]
        public async Task<IActionResult> UpdateLogin(EditUserLoginRequest request)
        {
            try
            {
                var response = await _userService.UpdateLogin(request);

                return Ok(response);
            }
            catch (DoesNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
