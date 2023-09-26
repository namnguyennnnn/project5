
using ExercisesApi.Model;

namespace ExercisesApi.Repository.AudioRepo
{
    public interface IAudioRepository
    {
        Task AddAudioAsync(Audio audio);
        Task<Audio> GetAudioByExerciseIdAsync(string exerciseId);
        Task UpdateAudioByExerciseIdAsync(string exerciseId, Audio updatedAudio);
        Task DeleteAudioByExerciseIdAsync(string exerciseId);
      
    }
}
