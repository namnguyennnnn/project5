using CategoryService.Model;
namespace CategoryService.Repository.CategoryDetails
{
    public interface ICategoryDetailsRepository
    {
        Task AddCategoryDetailAsync(CategoryDetail categoryDetail);
        Task UpdateCategoryDetailAsync(CategoryDetail categoryDetail);
        Task DeleteCategoryDetailAsync(string categoryDetailId);
        Task DeleteCategoryDetailByIdCategoryAsync(string categoryId);
        Task<CategoryDetail> GetCategoryDetailByIdAsync(string categoryDetailId);
        Task<List<CategoryDetail>> GetCategoryDetailsByCategoryIdAsync(string categoryId);
        Task<List<CategoryDetail>> GetAllCategoryDetailsAsync();
        
    }
}
