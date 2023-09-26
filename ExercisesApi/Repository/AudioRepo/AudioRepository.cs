using ExercisesApi.Data;
using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExercisesApi.Repository.AudioRepo
{
    public class AudioRepository: IAudioRepository
    {
        private readonly DataContext _context;

        public AudioRepository(DataContext context) 
        { 
            _context = context;
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

        public async Task UpdateAudioByExerciseIdAsync(string exerciseId, Audio updatedAudio)
        {
            var audio = await _context.audio.FirstOrDefaultAsync(a => a.exercise_id == exerciseId);
            if (audio != null)
            {
                // Cập nhật thông tin audio
                audio.audio_url = updatedAudio.audio_url;
                // Cập nhật các trường khác nếu cần

                await _context.SaveChangesAsync();
            }
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
