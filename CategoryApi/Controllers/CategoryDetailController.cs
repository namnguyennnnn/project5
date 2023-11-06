

using CategoryApi.DTO;
using CategoryApi.Services.CategoryDetailSV;
using Microsoft.AspNetCore.Mvc;

namespace CategoryApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDetailController : ControllerBase
    {
        private readonly ICategoryDetailService _categoryDetailService;

        public CategoryDetailController(ICategoryDetailService categoryDetailService)
        {
            _categoryDetailService = categoryDetailService;
        }

        [HttpGet("get-allCategoryDetailsByIdCategory/{categoryId}")]
        public async Task<ActionResult> GetCategoryDetailsByCategoryId([FromRoute] string categoryId)
        {
            var rs = await _categoryDetailService.GetCategoryDetailsByCategoryId(categoryId);
            return Ok(rs);
        }

        [HttpGet("get-allCategoryDetails")]
        public async Task<ActionResult> GetCategoryDetails()
        {
            var rs = await _categoryDetailService.GetCategoryDetails();
            return Ok(rs);
        }

        [HttpPost("create-categoryDetail")]
        public async Task<IActionResult> CreateCategoryDetail([FromBody]CategoryDetailDto categoryDetailDto)
        {
            var results = await _categoryDetailService.CreateCategoryDetail(categoryDetailDto);
            return Ok(results);
        }

        [HttpPut("update-categoryDetail/{categoryDetailId}")]
        public async Task<IActionResult> UpdateCategoryDetail([FromRoute]string categoryDetailId ,[FromBody] CategoryDetailDto categoryDetailDto)
        {
            var results = await _categoryDetailService.UpdateCategoryDetail(categoryDetailId, categoryDetailDto);
            return Ok(results);
        }    

        [HttpDelete("delete-categoryDetail/{categoryDetailId}")]
        public async Task<ActionResult> DeleteCategoryDetail([FromRoute] string categoryDetailId)
        {
            var rs = await _categoryDetailService.DeleteCategoryDetail(categoryDetailId);
            return Ok(rs);
        }

        [HttpDelete("delete-categoryDetails")]
        public async Task<ActionResult> DeleteCategoryDetails([FromBody] List<string> categoryDetailIds)
        {
            var rs = await _categoryDetailService.DeleteCategoryDetails(categoryDetailIds);
            return Ok(rs);
        }
    }
}
