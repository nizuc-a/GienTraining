using System.ComponentModel.DataAnnotations;

namespace DataModel.Model;

public class TrainingPlan
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "NameLength", MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "DescriptionLength")]
    public string? Description { get; set; }

    public DateTime CreateTime { get; set; } = DateTime.Now;

    public ICollection<TrainingDay>? Trainings { get; set; }
    
    public ICollection<User2Plan>? User2Plans { get; set; }
}