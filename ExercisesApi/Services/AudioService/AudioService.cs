using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.Model;
using ExercisesApi.Repository.AudioRepo;
using ExercisesApi.Services.FileService;

namespace ExercisesApi.Services.AudioService
{
    public class AudioService : IAudioService
    {
        private readonly IAudioRepository _audioRepository;
        private readonly IFileService _fileService;
        public AudioService( IFileService fileService, IAudioRepository audioRepository)
        {
            _audioRepository = audioRepository;
            _fileService = fileService;
        }

        public async Task CreateAudio(CreateAudioDto audioDto, string exerciseId)
        {
            var filepath = await _fileService.SaveFile(audioDto.audio_url);

            var newAudio = new Audio
            { 
                audio_id = exerciseId,
                audio_url = filepath,
                part1 = audioDto.part1,
                part2 = audioDto.part2,
                part3 = audioDto.part3,
                part4 = audioDto.part4,
                exercise_id = exerciseId    
            };
            await _audioRepository.AddAudioAsync(newAudio);
        }

       
    }
    
}
