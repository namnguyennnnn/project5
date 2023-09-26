using CatagoryDetailsManagement;
using CategoryService.Repository.Category;
using CategoryService.Repository.CategoryDetails;
using Grpc.Core;

namespace CategoryService.Services
{
    public class CategoryDetailGrpcFunction: CatagoryDetailsManagement.CatagoryDetailManager.CatagoryDetailManagerBase
    {
        private readonly ICategoryDetailsRepository _categoryDetailsRepository;
        private readonly ICategoryRepository _categoryRepository;
     
        public CategoryDetailGrpcFunction(ICategoryDetailsRepository categoryDetailsRepository, ICategoryRepository categoryRepository)
        {
            _categoryDetailsRepository = categoryDetailsRepository;
            _categoryRepository = categoryRepository;         
        }

        public override async Task<GetCatagoryDetailInForResponse> GetCatagoryDetailInFor(GetCatagoryDetailInForRequest request, ServerCallContext context)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var categoryDetail = await _categoryDetailsRepository.GetCategoryDetailByIdAsync(request.CategoryDetailId);
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryDetail.category_id);
            return await Task.FromResult(new GetCatagoryDetailInForResponse
            {
                CategoryDetailId = categoryDetail.category_detail_id,
                CategoryDetailName = categoryDetail.category_detail_name,
                CategoryId = categoryDetail.category_id,
                CategoryName = category.category_name
            });
        }
    }
}
