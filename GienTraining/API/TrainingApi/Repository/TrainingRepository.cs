using DataModel;
using DataModel.Model;
using Microsoft.EntityFrameworkCore;
using TrainingApi.Dto.Training;
using TrainingApi.Helpers;
using TrainingApi.Interfaces.Repository;
using TrainingApi.Mappers;

namespace TrainingApi.Repository;

public class TrainingRepository : ITrainingRepository
{
    private readonly ApplicationDbContext _context;

    public TrainingRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TrainingPlanDto>> GetAllAsync(TrainingQueryObject query)
    {
        var trainingPlans = _context.TrainingPlans.AsQueryable();
        
        if(!query.IsAscending)
            trainingPlans = trainingPlans.OrderBy(x => -x.Id);
        
        var skipnumber = (query.PageNumber - 1) * query.PageSize;
        
        return await trainingPlans.Skip(skipnumber).Take(query.PageSize).Select(x=> x.ToDto()).ToListAsync();
    }

    public async Task<TrainingPlan?> GetByIdAsync(int id)
    {
        return await _context.TrainingPlans.FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<TrainingPlan> CreateAsync(TrainingPlan trainingPlan)
    {
        _context.TrainingPlans.Add(trainingPlan);
        await _context.SaveChangesAsync();
        return trainingPlan;
    }

    public async Task<TrainingPlan> UpdateAsync(TrainingPlan trainingPlan)
    {
        _context.TrainingPlans.Update(trainingPlan);
        await _context.SaveChangesAsync();
        return trainingPlan;
    }

    public async Task<TrainingPlan> DeleteAsync(int id)
    {
        var stock = await GetByIdAsync(id);
        if (stock != null)
        {
            _context.TrainingPlans.Remove(stock);
            await _context.SaveChangesAsync();
        }
        return stock;
    }
}