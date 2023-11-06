
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.AudioRepo
{
    public interface IAudioRepository
    {
        Task AddAudioAsync(Audio audio);
        Task<Audio> GetAudioByExerciseIdAsync(string exerciseId);
        Task UpdateAudioAsync(CreateAudioDto updateAudioDto);
        Task DeleteAudioByExerciseIdAsync(string exerciseId);
      
    }
}
