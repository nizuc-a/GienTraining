using DataModel;
using DataModel.Model;
using Microsoft.EntityFrameworkCore;
using TrainingApi.Interfaces.Repository;

namespace TrainingApi.Repository;

public class TrainingDayRepository : ITrainingDayRepository
{
    private readonly ApplicationDbContext _context;

    public TrainingDayRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TrainingDay>> GetAllAsync(int trainingPlanId)
    {
        var days = _context.TrainingDays.Where(t => t.TrainingPlanId == trainingPlanId);

        return await days.ToListAsync();
    }

    public async Task<TrainingDay?> GetByIdAsync(int id)
    {
        return await _context.TrainingDays
            .Include(x=> x.Exercises)
            .ThenInclude(x=> x.Exercises)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TrainingDay> CreateAsync(TrainingDay trainingDay)
    {
        _context.TrainingDays.Add(trainingDay);
        await _context.SaveChangesAsync();
        return trainingDay;
    }

    public async Task<TrainingDay> UpdateAsync(TrainingDay trainingDay)
    {
        _context.TrainingDays.Update(trainingDay);
        await _context.SaveChangesAsync();
        return trainingDay;
    }

    public async Task<TrainingDay?> DeleteAsync(int id)
    {
        var day = await GetByIdAsync(id);
        
        if (day == null) 
            return null;
        
        _context.TrainingDays.Remove(day);
        await _context.SaveChangesAsync();
        return day;
    }
}