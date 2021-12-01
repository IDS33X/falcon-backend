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
            try
            {
                var response = await _userService.Add(request);

                return Ok(response);
            }
            catch (AlreadyExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = ex.InnerException?.Message;
                bool? missingChild1 = innerExceptionMessage == null ? null : innerExceptionMessage.StartsWith("The MERGE statement conflicted with the FOREIGN KEY constraint");
                bool? missingChild2 = innerExceptionMessage == null ? null : innerExceptionMessage.StartsWith("The INSERT statement conflicted with the FOREIGN KEY constraint");
                if ((missingChild1 != null && missingChild1 == true) || (missingChild2 != null && missingChild2 == true))
                {
                    string aux = innerExceptionMessage.Substring(innerExceptionMessage.IndexOf("dbo.") + 4);
                    int length = aux.LastIndexOf('"');
                    string missingEntityName = aux.Substring(0, length);
                    if (missingEntityName.StartsWith("M") && char.IsUpper(missingEntityName[1]))
                    {
                        missingEntityName = missingEntityName.Substring(1);
                    }
                    string errorMessage = $"Can not find any {missingEntityName} with the {missingEntityName}Id provided";
                    return NotFound(errorMessage);
                }
                return StatusCode(500, $"Exception message: {ex.Message}\n\n{(innerExceptionMessage != null ? $"InnerException message: {innerExceptionMessage}" : "")}");
            }
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception message: {ex.Message}\n\n{(ex.InnerException?.Message != null ? $"InnerException message: {ex.InnerException.Message}" : "")}");
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
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = ex.InnerException?.Message;
                bool? missingChild1 = innerExceptionMessage == null ? null : innerExceptionMessage.StartsWith("The MERGE statement conflicted with the FOREIGN KEY constraint");
                bool? missingChild2 = innerExceptionMessage == null ? null : innerExceptionMessage.StartsWith("The INSERT statement conflicted with the FOREIGN KEY constraint");
                if ((missingChild1 != null && missingChild1 == true) || (missingChild2 != null && missingChild2 == true))
                {
                    string aux = innerExceptionMessage.Substring(innerExceptionMessage.IndexOf("dbo.") + 4);
                    int length = aux.LastIndexOf('"');
                    string missingEntityName = aux.Substring(0, length);
                    if (missingEntityName.StartsWith("M") && char.IsUpper(missingEntityName[1]))
                    {
                        missingEntityName = missingEntityName.Substring(1);
                    }
                    string errorMessage = $"Can not find any {missingEntityName} with the {missingEntityName}Id provided";
                    return NotFound(errorMessage);
                }
                return StatusCode(500, $"Exception message: {ex.Message}\n\n{(innerExceptionMessage != null ? $"InnerException message: {innerExceptionMessage}" : "")}");
            }

        }
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> UpdateLogin(EditUserLoginRequest request)
        {
            try
            {
                var response = await _userService.UpdatePassword(request);

                return Ok(response);
            }
            catch (DoesNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception message: {ex.Message}\n\n{(ex.InnerException?.Message != null ? $"InnerException message: {ex.InnerException.Message}" : "")}");
            }

        }
    }
}
