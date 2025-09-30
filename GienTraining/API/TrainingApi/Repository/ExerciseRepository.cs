using DataModel;
using DataModel.Model;
using Microsoft.EntityFrameworkCore;
using TrainingApi.Interfaces.Repository;

namespace TrainingApi.Repository;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _context;

    public ExerciseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Exercise>> GetAllAsync(int trainingDayId)
    {
        return await _context.Exercises
            .Where(x=> x.TrainingDayId.HasValue)
            .Where(x=> x.TrainingDayId == trainingDayId)
            .ToListAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await _context.Exercises.FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<Exercise> CreateAsync(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }

    public async Task<Exercise> UpdateAsync(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }

    public async Task<Exercise?> DeleteAsync(int id)
    {
        var day = await GetByIdAsync(id);
        
        if (day == null) 
            return null;
        
        _context.Exercises.Remove(day);
        await _context.SaveChangesAsync();
        return day;
    }
}