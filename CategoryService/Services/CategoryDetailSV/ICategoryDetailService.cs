using CategoryService.DTO;

namespace CategoryService.Services.CategoryDetailSV
{
    public interface ICategoryDetailService
    {
        Task<ResultResponse> CreateCategoryDetail(CategoryDetailDto categoryDetailDto);
        Task<ResultResponse> UpdateCategoryDetail( string category_detail, CategoryDetailDto categoryDetailDto);
        Task<List<CategoryDetailDto>> GetCategoryDetails(string categoryId);      
        Task<ResultResponse> DeleteCategoryDetail(string categoryDetailId);
       
    }
}
