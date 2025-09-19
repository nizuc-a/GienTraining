using DataModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataModel;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseName> ExerciseNames { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<TrainingPlan> TrainingPlans { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<User2Plan> User2Plans { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User2Plan>(x => x.HasKey(k => new { k.AppUserId, k.TrainingPlanId }));

        builder.Entity<User2Plan>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.User2Plans)
            .HasForeignKey(p => p.AppUserId);

        builder.Entity<User2Plan>()
            .HasOne(u => u.TrainingPlan)
            .WithMany(u => u.User2Plans)
            .HasForeignKey(p => p.TrainingPlanId);
    }
}