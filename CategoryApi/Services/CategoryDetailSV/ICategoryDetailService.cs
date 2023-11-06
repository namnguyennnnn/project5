using CategoryApi.DTO;

namespace CategoryApi.Services.CategoryDetailSV
{
    public interface ICategoryDetailService
    {

        Task<ResultResponse> CreateCategoryDetail(CategoryDetailDto categoryDetailDto);
        Task<CategoryDetailDto> UpdateCategoryDetail( string category_detail, CategoryDetailDto categoryDetailDto);
        Task<List<CategoryDetailDto>> GetCategoryDetailsByCategoryId(string categoryId);      
        Task<List<CategoryDetailDto>> GetCategoryDetails();
        Task<ResultResponse> DeleteCategoryDetail(string categoryDetailId);
        Task<ResultResponse> DeleteCategoryDetails(List<string> categoryDetailId);
    }
}
