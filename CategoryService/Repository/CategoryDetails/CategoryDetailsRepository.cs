using CategoryService.Data;
using CategoryService.Model;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Repository.CategoryDetails
{
    public class CategoryDetailsRepository : ICategoryDetailsRepository
    {
        private readonly DataContext _context;

        public CategoryDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddCategoryDetailAsync(CategoryDetail categoryDetail)
        {
            _context.category_details.Add(categoryDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryDetailAsync(CategoryDetail categoryDetail)
        {
            _context.category_details.Update(categoryDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryDetailAsync(string categoryDetailId)
        {
            var categoryDetail = await _context.category_details.FindAsync(categoryDetailId);
            if (categoryDetail != null)
            {
                _context.category_details.Remove(categoryDetail);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteCategoryDetailByIdCategoryAsync(string categoryId)
        {
            var categoryDetails = await _context.category_details
            .Where(q => q.category_id == categoryId)
            .ToListAsync();

            foreach (var categoryDetail in categoryDetails)
            {
                _context.category_details.Remove(categoryDetail);
            }

            await _context.SaveChangesAsync();
           
        }

        public async Task<CategoryDetail> GetCategoryDetailByIdAsync(string categoryDetailId)
        {
            return await _context.category_details.FindAsync(categoryDetailId);
        }

        public async Task<List<CategoryDetail>> GetCategoryDetailsByCategoryIdAsync(string categoryId)
        {
            return await _context.category_details
                .Where(cd => cd.category_id == categoryId)
                .ToListAsync();
        }

        public async Task<List<CategoryDetail>> GetAllCategoryDetailsAsync()
        {
            return await _context.category_details.ToListAsync();
        }

       
    }

}
