using CategoryService.Data;
using CategoryService.Model;
using CategoryService.Repository.CategoryDetails;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly ICategoryDetailsRepository _categoryDetailsRepository;

        public CategoryRepository(ICategoryDetailsRepository categoryDetailsRepository ,DataContext context)
        {
            _context = context;
            _categoryDetailsRepository = categoryDetailsRepository;
        }

        public async Task AddCategoryAsync(Categories category)
        {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateCategoryAsync(Categories category)
        {
            _context.categories.Update(category);
            await _context.SaveChangesAsync();
        }


        public async Task<List<string>> DeleteCategoryAsync(string categoryId)
        {
            var categoryToDelete = await _context.categories.FindAsync(categoryId);
            if (categoryToDelete != null)
            {
                
                var CategoryDetailIs = await _context.category_details
                                                .Where(cd => cd.category_id == categoryId)
                                                .Select(cd => cd.category_detail_id)
                                                .ToListAsync();     

                _context.categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();    
                
                return CategoryDetailIs;
            }

            return new List<string>(); 
        }

        public async Task<Categories> GetCategoryByIdAsync(string categoryId)
        {
            return await _context.categories.FindAsync(categoryId);
        }

        public async Task<List<Categories>> GetCategoriesAsync()
        {
            List<Categories> categories = await _context.categories.ToListAsync();

            return categories;
        }

    }
}
