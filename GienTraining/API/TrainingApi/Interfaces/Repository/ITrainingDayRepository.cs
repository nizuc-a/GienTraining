using DataModel.Model;

namespace TrainingApi.Interfaces.Repository;

public interface ITrainingDayRepository
{
    Task<IEnumerable<TrainingDay>> GetAllAsync(int trainingPlanId);
    Task<TrainingDay?> GetByIdAsync(int id);
    Task<TrainingDay> CreateAsync(TrainingDay trainingDay);
    Task<TrainingDay> UpdateAsync(TrainingDay trainingDay);
    Task<TrainingDay?> DeleteAsync(int id);
}