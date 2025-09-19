using System.ComponentModel.DataAnnotations;

namespace DataModel.Model;

public class TrainingDay
{
    public int Id { get; set; }

    [Required(ErrorMessage = "TrainingNameRequired")]
    [StringLength(100, ErrorMessage = "NameLength", MinimumLength = 3)]
    public string TrainingName { get; set; } = string.Empty;
    
    [StringLength(300, ErrorMessage = "DescriptionLength")]
    public string? Description { get; set; }

    public DateTime CreateTime { get; set; } = DateTime.Now;
    
    public ICollection<Exercise>? Exercises { get; set; }
    
    public TrainingPlan? TrainingPlan { get; set; }
    public int? TrainingPlanId { get; set; }
}