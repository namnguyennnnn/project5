using CategoryApi.Model;
namespace CategoryApi.Repository.CategoryDetails
{
    public interface ICategoryDetailsRepository
    {
        Task<CategoryDetail> GetCategoryDetailByIdAsync(string categoryDetailId);
        Task<CategoryDetail> GetCategoryDetailByNameAsync(string categoryDetailName);
        Task<List<CategoryDetail>> GetCategoryDetailsByCategoryIdAsync(string categoryId);
        Task<List<CategoryDetail>> GetAllCategoryDetailsAsync();
        Task AddCategoryDetailAsync(CategoryDetail categoryDetail);
        Task UpdateCategoryDetailAsync(CategoryDetail categoryDetail);
        Task DeleteCategoryDetailAsync(string categoryDetailId);
        Task DeleteCategoryDetailByIdCategoryAsync(string categoryId);
        Task DeleteCategoryDetailsAsync(List<string> categoryDetailIds);
        
    }
}
