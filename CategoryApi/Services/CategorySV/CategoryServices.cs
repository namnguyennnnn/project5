using CategoryApi.DTO;
using CategoryApi.Model;
using CategoryApi.Repository.Category;
using ExerciseManagement;
using Grpc.Net.Client;

namespace CategoryApi.Services.CategorySV
{

    public class CategoryServices :ICategoryServices
    {
        private readonly GrpcChannel _channel;
        private readonly ICategoryRepository _categoryRepository;
        
        
        public CategoryServices(  ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;          
            _channel = GrpcChannelManager.ExerciseChannel;
        }

        public async Task<ResultResponse> CreateCategory(string categoryName)
        {
            if (categoryName == null)
            {
                throw new ArgumentNullException(nameof(categoryName));
            }
            var newCategory = new Categories
            {
                category_id = Guid.NewGuid().ToString(),
                category_name = categoryName
            };
                    
            await _categoryRepository.AddCategoryAsync(newCategory);

            return new ResultResponse
            {
              StatusCode = 200,
              StatusDetail = "Success"
            };
            
            
        }
        public async Task<List<CategoryDto>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            List<CategoryDto> categoriesDto = categories.Select(category => new CategoryDto
            {
                category_id = category.category_id,
                category_name = category.category_name
            }).ToList();

            return categoriesDto;
        }

        public async Task<ResultResponse> UpdateCategory(string categoryId,string categoryName)
        {
            if (categoryId == null)
            {
                throw new ArgumentException(nameof(categoryId));
            }
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            category.category_name = categoryName;

            await _categoryRepository.UpdateCategoryAsync(category);

            return new ResultResponse
            {
                StatusCode = 200,
                StatusDetail = "Success"
            };

        }

        public async Task<ResultResponse> DeleteCategory(string categoryId)
        {
          
            var client = new ExerciseManagement.ExerciseManager.ExerciseManagerClient(_channel);
            var respone = new DeleteExercisesRequest();
            if (string.IsNullOrEmpty(categoryId))
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            //xóa Category và CategoryDetail và nhận về 1 list CategoryDetailId
            var categorydetailIds = await _categoryRepository.DeleteCategoryAsync(categoryId);

            for (int i = 0; i < categorydetailIds.Count; i++)
            {
                 client.DeleteExercises(new DeleteExercisesRequest{ CategoryDetailId = categorydetailIds[i]});
            }

            return new ResultResponse
            {
                StatusCode = 200,
                StatusDetail = "Delete category Success"
            };
        }


    }
}
