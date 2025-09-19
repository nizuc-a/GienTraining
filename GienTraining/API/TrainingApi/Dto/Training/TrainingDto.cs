namespace TrainingApi.Dto.Training;

public class TrainingDto
{
    public int Id { get; set; }
    
    public string TrainingName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreateTime { get; set; }
}