using System.ComponentModel.DataAnnotations;

namespace DataModel.Model;

public class ExerciseName
{
    public int Id { get; set; }

    [Required(ErrorMessage = "ExerciseNameRequired")]
    [StringLength(100, ErrorMessage = "NameLength", MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
}