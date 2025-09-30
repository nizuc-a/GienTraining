using DataModel.Model;
using TrainingApi.Dto.Training;

namespace TrainingApi.Mappers;

public static class TrainingDayMapper
{
    public static TrainingDayDto ToDto(this TrainingDay trainingDay)
    {
        return new TrainingDayDto
        {
            Id = trainingDay.Id,
            TrainingName = trainingDay.TrainingName,
            Description = trainingDay.Description,
            CreateTime = trainingDay.CreateTime,
        };
    }
    
    public static TrainingDay ToTrainingDay(this CreateTrainingDayDto trainingDayPlan)
    {
        return new TrainingDay
        {
            TrainingName = trainingDayPlan.TrainingName,
            Description = trainingDayPlan.Description,
        };
    }
}