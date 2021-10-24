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
            var response = await _riskCategoryService.Add(request);

            return Ok(response);
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
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
