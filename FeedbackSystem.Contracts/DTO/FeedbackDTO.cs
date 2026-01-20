using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Contracts.DTO;

public class FeedbackDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "User name is required")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Feedback text is required")]
    public string FeedbackText { get; set; } = string.Empty;

    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; } = 1;

    public string FeedbackCategory { get; set; } = string.Empty;

    public string? Status { get; set; }
    public DateTime SubmittedOn { get; set; }
}
