using CategoryApi.Data;
using CategoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CategoryApi.Repository.CategoryDetails
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
        public async Task DeleteCategoryDetailsAsync(List<string> categoryDetailIds)
        {
            var categoryDetailsToDelete = await _context.category_details
                .Where(cd => categoryDetailIds.Contains(cd.category_detail_id))
                .ToListAsync();

            _context.category_details.RemoveRange(categoryDetailsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoryDetail> GetCategoryDetailByIdAsync(string categoryDetailId)
        {
            return await _context.category_details.FindAsync(categoryDetailId);
        }
        public async Task<CategoryDetail> GetCategoryDetailByNameAsync(string categoryDetailName)
        {
            return await _context.category_details.FirstOrDefaultAsync(cd => cd.category_detail_name== categoryDetailName.ToUpper());
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
