
using ExercisesApi.DTO.UpdateExerciseRequest;
using ExercisesApi.Model;

namespace ExercisesApi.Repository.AudioRepo
{
    public interface IAudioRepository
    {
        Task AddAudioAsync(Audio audio);
        Task<Audio> GetAudioByExerciseIdAsync(string exerciseId);
        Task UpdateAudioAsync(UpdateAudioDto updateAudioDto);
        Task DeleteAudioByExerciseIdAsync(string exerciseId);
      
    }
}
