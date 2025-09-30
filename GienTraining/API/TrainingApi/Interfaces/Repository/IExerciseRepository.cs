using DataModel.Model;

namespace TrainingApi.Interfaces.Repository;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetAllAsync(int trainingDayId);
    Task<Exercise?> GetByIdAsync(int id);
    Task<Exercise> CreateAsync(Exercise exercise);
    Task<Exercise> UpdateAsync(Exercise exercise);
    Task<Exercise?> DeleteAsync(int id);
}