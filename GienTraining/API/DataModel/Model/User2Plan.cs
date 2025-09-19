namespace DataModel.Model;

public class User2Plan
{
    public int Id { get; set; }

    public AppUser? AppUser { get; set; }
    public string? AppUserId { get; set; }
    
    public TrainingPlan? TrainingPlan { get; set; }
    public int? TrainingPlanId { get; set; }
}