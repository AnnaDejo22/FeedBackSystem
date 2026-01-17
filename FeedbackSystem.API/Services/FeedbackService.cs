using FeedbackSystem.API.Data;
using FeedbackSystem.API.Models;
using FeedbackSystem.API.Services.Interfaces;
using FeedbackSystem.Contracts.DTO;

namespace FeedbackSystem.API.Services;

public class FeedbackService : IFeedbackService
{
    private readonly AppDbContext _context;

    public FeedbackService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<FeedbackDTO> SubmitFeedbackAsync(Feedback feedback)
    {
        feedback.SubmittedOn = DateTime.UtcNow;

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return new FeedbackDTO
        {
            Id = feedback.Id,
            UserName = feedback.UserName,
            FeedbackText = feedback.Feedbacks,
            Rating = feedback.Rating,
            SubmittedOn = feedback.SubmittedOn
        };
    }
}
