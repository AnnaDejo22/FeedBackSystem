namespace FeedbackSystem.Contracts.DTO;

public class FeedbackDTO
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? FeedbackText { get; set; }
    public int Rating { get; set; }
    public string? Status { get; set; }
    public DateTime SubmittedOn { get; set; }
}