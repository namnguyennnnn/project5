using CatagoryDetailsManagement;
using CategoryApi.Model;
using CategoryApi.Repository.Category;
using CategoryApi.Repository.CategoryDetails;
using Grpc.Core;

namespace CategoryApi.Services
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
            if(categoryDetail == null || category == null)
            {
                return new GetCatagoryDetailInForResponse { };
            }
            return await Task.FromResult(new GetCatagoryDetailInForResponse
            {
                CategoryDetailId = categoryDetail.category_detail_id,
                CategoryDetailName = categoryDetail.category_detail_name,
                CategoryId = categoryDetail.category_id,
                CategoryName = category.category_name
            });
        }
        public override async Task<GetCatagoryDetailInForByNameResponse> GetCatagoryDetailInForByName(GetCatagoryDetailInForByNameRequest request, ServerCallContext context)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var categoryDetail = await _categoryDetailsRepository.GetCategoryDetailByNameAsync(request.CategoryDetailName);
            
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryDetail.category_id);
            if (categoryDetail == null || category == null)
            {
                category = await _categoryRepository.GetCategoryByNameToeicAsync();
                var newCategoryDetail = new CategoryDetail
                {
                    category_detail_name = request.CategoryDetailName,
                    category_id = category.category_id
                };
            }
            return await Task.FromResult(new GetCatagoryDetailInForByNameResponse
            {
                CategoryDetailId = categoryDetail.category_detail_id,
                CategoryDetailName = categoryDetail.category_detail_name,
                CategoryId = categoryDetail.category_id,
                CategoryName = category.category_name
            });
        }

    }
}
