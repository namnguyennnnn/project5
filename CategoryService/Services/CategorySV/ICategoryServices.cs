using CategoryService.DTO;
using CategoryService.Model;

namespace CategoryService.Services.CategorySV
{
    public interface ICategoryServices
    {
        Task<ResultResponse> CreateCategory(string categoryName);
        Task<ResultResponse> UpdateCategory(string categoryId, string categoryName);
        Task<ResultResponse> DeleteCategory(string categoryId);
        Task<List<CategoryDto>> GetCategories();
        
    }
}
