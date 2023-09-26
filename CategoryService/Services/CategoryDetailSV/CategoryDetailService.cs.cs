using CategoryService.DTO;
using CategoryService.Model;
using CategoryService.Repository.CategoryDetails;
using ExerciseManagement;
using Grpc.Core;
using Grpc.Net.Client;

namespace CategoryService.Services.CategoryDetailSV
{
    public class CategoryDetailService : ICategoryDetailService
    {
        private readonly ICategoryDetailsRepository _categoryDetailsRepository;
        private readonly GrpcChannel _channel;
        public CategoryDetailService(ICategoryDetailsRepository categoryDetailsRepository, IConfiguration configuration)
        {
            _channel = GrpcChannelManager.ExerciseChannel;
            _categoryDetailsRepository = categoryDetailsRepository;
        }

       
        public async Task<ResultResponse> CreateCategoryDetail(CategoryDetailDto categoryDetailDto)
        {
            if (categoryDetailDto == null)
            {
                throw new ArgumentNullException(nameof(categoryDetailDto));
            }

            var newCategoryDetail = new CategoryDetail
            {
                category_detail_id = Guid.NewGuid().ToString(),
                category_detail_name = categoryDetailDto.category_detail_name,
                category_id = categoryDetailDto.category_id,
            };

            await _categoryDetailsRepository.AddCategoryDetailAsync(newCategoryDetail);

            return new ResultResponse
            {
                StatusCode = 200,
                StatusDetail = "Success"
            };
        }

       

        public async Task<List<CategoryDetailDto>> GetCategoryDetails(string categoryId)
        {
            var categoryDetails = await _categoryDetailsRepository.GetCategoryDetailsByCategoryIdAsync(categoryId);
            List<CategoryDetailDto> categoryDetailDtos = categoryDetails.Select(categoryDetail => new CategoryDetailDto
            {
                category_detail_id = categoryDetail.category_detail_id,
                category_detail_name = categoryDetail.category_detail_name,
                category_id = categoryDetail.category_id
            }).ToList();

            return categoryDetailDtos;
        }

        public async Task<ResultResponse> UpdateCategoryDetail(string category_detail,  CategoryDetailDto categoryDetailDto)
        {
            if (categoryDetailDto == null)
            {
                throw new ArgumentNullException(nameof(categoryDetailDto));
            }
            var categoryDetail = await _categoryDetailsRepository.GetCategoryDetailByIdAsync(categoryDetailDto.category_detail_id);

            categoryDetail.category_detail_name = categoryDetailDto.category_detail_name;
            categoryDetail.category_id = categoryDetailDto.category_id;

            await _categoryDetailsRepository.UpdateCategoryDetailAsync(categoryDetail);

            return new ResultResponse
            {
                StatusCode = 200,
                StatusDetail = "Success"
            };
        }
    

        public async Task<ResultResponse> DeleteCategoryDetail(string categoryDetailId)
        {
            await _categoryDetailsRepository.DeleteCategoryDetailAsync(categoryDetailId);
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_channel);
            var respone = client.DeleteExercises(new DeleteExercisesRequest { CategoryDetailId = categoryDetailId });
                          
            return new ResultResponse 
            {
                StatusCode = respone.Status,
                StatusDetail = "Delete Success",
            };
        }
    }
}
