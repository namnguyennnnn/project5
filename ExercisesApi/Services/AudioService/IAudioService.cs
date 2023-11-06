using ExercisesApi.DTO.CreateExerciseDto;

namespace ExercisesApi.Services.AudioService
{
    public interface IAudioService
    {
        Task CreateAudio(CreateAudioDto audioDto, string exerciseId);
        Task CreateAudioByDataFile(CreateAudioDto audioDto, string exerciseId);
    }
}
