using AutoMapper;
using ExercisesApi.Data;
using ExercisesApi.DTO.CreateExerciseDto;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExercisesApi.Repository.AudioRepo
{
    public class AudioRepository: IAudioRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AudioRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }


        public async Task AddAudioAsync(Audio audio)
        {
            _context.audio.Add(audio);
            await _context.SaveChangesAsync();
        }

        public async Task<Audio> GetAudioByExerciseIdAsync(string exerciseId)
        {
            return await _context.audio.FirstOrDefaultAsync(a => a.exercise_id == exerciseId);
        }

        public async Task UpdateAudioAsync(CreateAudioDto updateAudioDto)
        {
            var existingAudio = await _context.audio.FirstOrDefaultAsync(a => a.audio_id == updateAudioDto.audio_id);

            if (existingAudio != null)
            {
                existingAudio.audio_url = updateAudioDto.audio_url?? existingAudio.audio_url;
                existingAudio.part1 = updateAudioDto.part1 ?? existingAudio.part1;
                existingAudio.part2 = updateAudioDto.part2?? existingAudio.part2;
                existingAudio.part3 = updateAudioDto.part3 ?? existingAudio.part3;
                existingAudio.part4 = updateAudioDto.part4 ?? existingAudio.part4;
                _context.audio.Update(existingAudio);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAudioByExerciseIdAsync(string exerciseId)
        {
            var audio = await _context.audio.FirstOrDefaultAsync(a => a.exercise_id == exerciseId);
            if (audio != null)
            {
                _context.audio.Remove(audio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
