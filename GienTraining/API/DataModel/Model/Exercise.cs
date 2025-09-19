using System.ComponentModel.DataAnnotations;

namespace DataModel.Model;

public class Exercise
{
    public int Id { get; set; }

    [Required(ErrorMessage = "ExerciseNameRequired")]
    public ExerciseName? ExerciseName { get; set; }

    [Required(ErrorMessage = "ExerciseTypeRequired")]
    public ExerciseType? ExerciseType { get; set; }

    ICollection<Exercise>? Exercises { get; set; }

    public int? Percent { get; set; }

    public double? Weight { get; set; }

    public int? Repetitions { get; set; }

    public int? Approaches { get; set; }
}