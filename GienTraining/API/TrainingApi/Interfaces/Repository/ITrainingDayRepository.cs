using DataModel.Model;

namespace TrainingApi.Interfaces.Repository;

public interface ITrainingDayRepository
{
    Task<IEnumerable<TrainingDay>> GetAllAsync();
    Task<TrainingDay?> GetByIdAsync(int id);
    Task<TrainingDay> CreateAsync(TrainingDay trainingPlan);
    Task<TrainingDay> UpdateAsync(TrainingDay trainingPlan);
    Task<TrainingDay> DeleteAsync(int id);
}