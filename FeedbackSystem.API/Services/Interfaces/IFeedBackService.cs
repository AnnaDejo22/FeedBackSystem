using FeedbackSystem.API.Models;
using FeedbackSystem.Contracts.DTO;

namespace FeedbackSystem.API.Services.Interfaces;

public interface IFeedbackService
{
    Task<FeedbackDTO> SubmitFeedbackAsync(Feedback feedback);
}
