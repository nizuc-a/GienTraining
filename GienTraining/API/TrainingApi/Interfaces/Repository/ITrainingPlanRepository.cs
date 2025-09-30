using DataModel.Model;
using TrainingApi.Dto.Training;
using TrainingApi.Helpers;

namespace TrainingApi.Interfaces.Repository;

public interface ITrainingPlanRepository
{
    Task<IEnumerable<TrainingPlan>> GetAllAsync(TrainingQueryObject query);
    Task<TrainingPlan?> GetByIdAsync(int id);
    Task<TrainingPlan> CreateAsync(TrainingPlan trainingPlan);
    Task<TrainingPlan> UpdateAsync(TrainingPlan trainingPlan);
    Task<TrainingPlan?> DeleteAsync(int id);
}