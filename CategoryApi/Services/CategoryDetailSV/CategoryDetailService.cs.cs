using CategoryApi.DTO;
using CategoryApi.Model;
using CategoryApi.Repository.CategoryDetails;
using ExerciseManagement;
using Grpc.Net.Client;

namespace CategoryApi.Services.CategoryDetailSV
{
    public class CategoryDetailService : ICategoryDetailService
    {
        private readonly ICategoryDetailsRepository _categoryDetailsRepository;
        private readonly GrpcChannel _channel;
        public CategoryDetailService(ICategoryDetailsRepository categoryDetailsRepository)
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
                category_detail_name = categoryDetailDto.category_detail_name.ToUpper(),
                category_id = categoryDetailDto.category_id,
            };

            await _categoryDetailsRepository.AddCategoryDetailAsync(newCategoryDetail);

            return new ResultResponse
            {
                StatusCode = 200,
                StatusDetail = "Success"
            };
        }

       

        public async Task<List<CategoryDetailDto>> GetCategoryDetailsByCategoryId(string categoryId)
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

        public async Task<List<CategoryDetailDto>> GetCategoryDetails()
        {
            var categoryDetails = await _categoryDetailsRepository.GetAllCategoryDetailsAsync();
            List<CategoryDetailDto> categoryDetailDtos = categoryDetails.Select(categoryDetail => new CategoryDetailDto
            {
                category_detail_id = categoryDetail.category_detail_id,
                category_detail_name = categoryDetail.category_detail_name,
                category_id = categoryDetail.category_id
            }).ToList();

            return categoryDetailDtos;
        }

        public async Task<CategoryDetailDto> UpdateCategoryDetail(string categoryDetailId,  CategoryDetailDto categoryDetailDto)
        {
            if (categoryDetailDto == null&& string.IsNullOrEmpty(categoryDetailId) == true)
            {
                throw new ArgumentNullException("Please input valid data");
            }
            var categoryDetail = await _categoryDetailsRepository.GetCategoryDetailByIdAsync(categoryDetailId);

            categoryDetail.category_detail_name = string.IsNullOrEmpty(categoryDetailDto.category_detail_name) ? categoryDetail.category_detail_name : categoryDetailDto.category_detail_name;
            categoryDetail.category_id = string.IsNullOrEmpty(categoryDetailDto.category_id)? categoryDetail.category_id : categoryDetail.category_id;

            await _categoryDetailsRepository.UpdateCategoryDetailAsync(categoryDetail);
            var newcategoryDetail = await _categoryDetailsRepository.GetCategoryDetailByIdAsync(categoryDetailId);
            return new CategoryDetailDto
            {
                category_detail_id = newcategoryDetail.category_detail_id,
                category_detail_name = newcategoryDetail.category_detail_name,
                category_id = newcategoryDetail.category_id
            };
        }
    

        public async Task<ResultResponse> DeleteCategoryDetail(string categoryDetailId)
        {
            await _categoryDetailsRepository.DeleteCategoryDetailAsync(categoryDetailId);
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_channel);
            var respone = client.DeleteExercises(new DeleteExercisesRequest { CategoryDetailId = categoryDetailId });
                          
            return new ResultResponse 
            {
                StatusCode = 200,
                StatusDetail = "Delete Success",
            };
        }

        public async Task<ResultResponse> DeleteCategoryDetails(List<string> categoryDetailIds)
        {
            if (categoryDetailIds == null)
            {
                throw new ArgumentNullException(nameof(categoryDetailIds), "List contains element null or emty");
            }
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_channel);
            await _categoryDetailsRepository.DeleteCategoryDetailsAsync(categoryDetailIds);

            foreach (var categoryDetailId in categoryDetailIds)
            {
              client.DeleteExercises(new DeleteExercisesRequest { CategoryDetailId = categoryDetailId });
            }
            return new ResultResponse
            {
                StatusCode = 200,
                StatusDetail = "Delete Success",
            };
        }
    }
}
