namespace DataModel.Model;

public class AppUser
{
    public string AppUserId { get; set; }
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;

    public double? BenchPressPr { get; set; }
    public double? BarbellSquatPr { get; set; }
    public double? DeadliftPr { get; set; }

    public ICollection<User2Plan>? User2Plans { get; set; }
}