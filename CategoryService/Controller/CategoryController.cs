using CategoryService.DTO;
using CategoryService.Services.CategorySV;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       private readonly ICategoryServices _categoryService;
       
       public CategoryController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;             
        }

        [HttpGet("get-categories")]
        public  async Task<ActionResult> GetCategories()
        {
           var result = await _categoryService.GetCategories();
           return Ok(result);
        }

        [HttpPost("create-category")]
        public async Task<ActionResult> CreateCategory([FromForm] string categoryName)
        {
            var result = await _categoryService.CreateCategory(categoryName);
            return Ok(result);
        }

        [HttpPut("update-category/{categoryId}")]
        public async Task<ActionResult> UpdateCategory([FromRoute] string categoryId,[FromForm] string categoryName)
        {
            var result = await _categoryService.UpdateCategory(categoryId, categoryName);
            return Ok(result);
        }

        [HttpDelete("delete-category/{categoryId}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] string categoryId)
        {
            var result = await _categoryService.DeleteCategory(categoryId);
            return Ok(result);
        }
    }
}
