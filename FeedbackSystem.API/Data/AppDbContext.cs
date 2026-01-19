using Microsoft.EntityFrameworkCore;
using FeedbackSystem.API.Enum;
using FeedbackSystem.API.Models;

namespace FeedbackSystem.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Feedback> Feedbacks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(f => f.Id);

            entity.Property(f => f.UserName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(f => f.Feedbacks)
                  .IsRequired()
                  .HasMaxLength(1000);

            entity.Property(f => f.Rating).IsRequired();
            entity.HasCheckConstraint(
                "CK_Feedback_Rating",
                "[Rating] >= 1 AND [Rating] <= 5"
            );

            entity.Property(f => f.Status)
                  .IsRequired()
                  .HasDefaultValue(FeedBackStatus.New);

            entity.Property(f => f.SubmittedOn)
                  .IsRequired();
        });
    }
}
