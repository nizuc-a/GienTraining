using System.ComponentModel.DataAnnotations;

namespace TrainingApi.Dto.Training;

public class CreateTrainingPlanDto
{
    [Required]
    [MaxLength(100, ErrorMessage = "Symbol cannot exceed 10 characters.")]
    [MinLength(3, ErrorMessage = "Symbol must be at least 1 character long.")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Symbol cannot exceed 10 characters.")]
    public string? Description { get; set; }
}