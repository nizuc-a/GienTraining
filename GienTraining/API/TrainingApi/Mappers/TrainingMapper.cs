using DataModel.Model;
using TrainingApi.Dto.Training;

namespace TrainingApi.Mappers;

public static class TrainingMapper
{
    public static TrainingPlanDto ToDto(this TrainingPlan trainingPlan)
    {
        return new TrainingPlanDto
        {
            Id = trainingPlan.Id,
            Name = trainingPlan.Name,
            Description = trainingPlan.Description,
            CreateTime = trainingPlan.CreateTime,
        };
    }
}