using CategoryApi.Model;

namespace CategoryApi.Repository.Category
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Categories category);
        Task UpdateCategoryAsync(Categories category);
        Task<List<string>> DeleteCategoryAsync(string categoryId);
        Task<Categories> GetCategoryByIdAsync(string categoryId);
        Task<Categories> GetCategoryByNameToeicAsync();
        Task<List<Categories>> GetCategoriesAsync();
    }
}
