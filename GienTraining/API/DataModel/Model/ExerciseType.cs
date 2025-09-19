using System.ComponentModel.DataAnnotations;

namespace DataModel.Model
{
    public class ExerciseType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ExerciseTypeRequired")]
        [StringLength(100, ErrorMessage = "NameLength", MinimumLength = 3)]
        public string TypeName { get; set; } = string.Empty;
    }
}