using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Support.Requests.RiskCategory;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class RiskCategoryController : ControllerBase
    {
        private readonly IRiskCategoryService _riskCategoryService;
        public RiskCategoryController(IRiskCategoryService riskCategoryService)
        {
            _riskCategoryService = riskCategoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddRiskCategoryRequest request)
        {
            try
            {
                var response = await _riskCategoryService.Add(request);

                return Ok(response);
            }
            catch (AlreadyExistException ex)
            {
                return BadRequest(ex.Message);
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

        [HttpGet("GetRiskCategoriesByDepartment")]
        public async Task<IActionResult> GetRiskCategoriesByDepartment([FromQuery] GetRiskCategoriesByDepartmentRequest request)
        {
            var response = await _riskCategoryService.GetRiskCategoriesByDepartment(request);

            return Ok(response);
        }

        [HttpGet("GetSearchRiskCategoriesByDepartment")]
        public async Task<IActionResult> GetRiskCategoriesByDepartmentAndSearch([FromQuery] GetRiskCategoriesByDepartmentSearchRequest request)
        {
            var response = await _riskCategoryService.GetDepartmentsByDivisionAndSearch(request);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EditRiskCategoryRequest request)
        {
            try
            {
                var response = await _riskCategoryService.Update(request);

                return Ok(response);
            }
            catch (DoesNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (AlreadyExistException e)
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
