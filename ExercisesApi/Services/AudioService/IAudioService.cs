using ExercisesApi.DTO;

namespace ExercisesApi.Services.AudioService
{
    public interface IAudioService
    {
        Task CreateAudio(CreateAudioDto audioDto, string exerciseId);
    }
}
