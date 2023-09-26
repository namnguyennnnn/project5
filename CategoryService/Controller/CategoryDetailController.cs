

using CategoryService.DTO;
using CategoryService.Services.CategoryDetailSV;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controller
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

        [HttpGet("get-allCategoryDetails/{categoryId}")]
        public async Task<ActionResult> GetCategoryDetailsByCategoryId([FromRoute] string categoryId)
        {
            var rs = await _categoryDetailService.GetCategoryDetails(categoryId);
            return Ok(rs);
        }

        [HttpPost("create-categoryDetal")]
        public async Task<IActionResult> CreateCategoryDetail([FromForm ]CategoryDetailDto categoryDetailDto)
        {
            var results = await _categoryDetailService.CreateCategoryDetail(categoryDetailDto);
            return Ok(results);
        }

        [HttpPut("update-categoryDetail/{categoryDetailId}")]
        public async Task<IActionResult> UpdateCategoryDetail([FromRoute]string categoryDetailId ,[FromForm] CategoryDetailDto categoryDetailDto)
        {
            var results = await _categoryDetailService.UpdateCategoryDetail(categoryDetailId, categoryDetailDto);
            return Ok(results);
        }    

        [HttpDelete("{categoryDetalId}")]
        public async Task<ActionResult> DeleteCategoryDetail([FromRoute] string categoryDetalId)
        {
            var rs = await _categoryDetailService.DeleteCategoryDetail(categoryDetalId);
            return Ok(rs);
        }
    }
}
