namespace TrainingApi.Dto.Training;

public class TrainingPlanDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }

    public DateTime CreateTime { get; set; }
}