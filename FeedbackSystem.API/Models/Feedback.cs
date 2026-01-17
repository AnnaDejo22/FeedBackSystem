using System.ComponentModel.DataAnnotations;
using FeedbackSystem.API.Enum;  

namespace FeedbackSystem.API.Models;
public class Feedback
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(2)]
    public string UserName { get; set; }

    [Required]
    public string Feedbacks { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    public FeedBackStatus Status { get; set; } = FeedBackStatus.New;

    [Required]
    public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
}