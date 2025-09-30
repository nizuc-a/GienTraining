using System.ComponentModel.DataAnnotations;

namespace DataModel.Model;

public class Exercise
{
    public int Id { get; set; }

    [Required(ErrorMessage = "ExerciseNameRequired")]
    public ExerciseName? ExerciseName { get; set; }

    [Required(ErrorMessage = "ExerciseTypeRequired")]
    public ExerciseType? ExerciseType { get; set; }

    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public int? Percent { get; set; }

    public double? Weight { get; set; }

    public int? Repetitions { get; set; }

    public int? Approaches { get; set; }

    public TrainingDay? TrainingDay { get; set; }
    public int? TrainingDayId { get; set; }
}